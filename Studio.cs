using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using _3DmigotoModStudio.Configs;

namespace _3DmigotoModStudio
{
    public partial class Studio : Form
    {
        List<D3D11ElementAttributes> D3D11ElementAttributesList;
        ConfigAttributes configAttributes;
        public Studio()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.NicoLove;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "3Dmigoto Mod Studio " + version.ToString();
            initializeConfig();
            string runPath = Application.StartupPath.ToString() + "\\";
            string defaultConfigPath = runPath + "config.json";
            if (File.Exists(defaultConfigPath))
            {
                readAndSetConfig(defaultConfigPath);
            }
        }

        //Log output info to RunOutputRichText
        public void LogOutput(string outputText, Color textColor= default)
        {
            if (textColor == default)
            {
                textColor = Color.Lime;
            }
            // log the length when we add ne content
            int startPosition = RunOutputRichText.TextLength;
            RunOutputRichText.AppendText(outputText);
            RunOutputRichText.AppendText(Environment.NewLine);

            int endPosition = RunOutputRichText.TextLength;

            RunOutputRichText.Select(startPosition, endPosition - startPosition);
            RunOutputRichText.SelectionColor = textColor;
        }


        //Open a json file to read configs.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show open json file dialog
            DialogResult result = openFileDialogJson.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialogJson.FileName;
                readAndSetConfig(selectedFilePath);
            }

        }

        public void initializeConfig()
        {
            dataGridViewElementList.Rows.Clear();

            TextBoxLoaderFolder.Text = string.Empty;
            TextBoxOutputFolder.Text = string.Empty;
            TextBoxFrameAnalysisFolder.Text = string.Empty;

            ComboBoxGameEngine.SelectedIndex = -1;

            TextBoxDrawIndexBufferHash.Text = string.Empty;
            TextBoxDrawIndexBufferHash.Enabled = false;

            TextBoxModName.Text = string.Empty;
            TextBoxModName.Enabled = false;

            TextBoxVertexShaderCheckSlots.Text = string.Empty;
            TextBoxVertexShaderCheckSlots.Enabled = false;
            CheckBoxGenerateVertexShaderCheck.Checked = false;

            TextBoxSkipIndexBufferHashList.Text = string.Empty;
            TextBoxSkipIndexBufferHashList.Enabled = false;
            CheckBoxSkipIndexBufferHashList.Checked = false;

            TextBoxAnimationVertexShaderHash.Text = string.Empty;
            TextBoxAnimationVertexShaderHash.Enabled = false;
            CheckBoxAnimationVertexShaderHash.Checked = false;

            TextBoxBlendDrawCategory.Text = string.Empty;
            TextBoxBlendDrawCategory.Enabled = false;
            CheckBoxBlendDrawCategory.Checked = false;

            TextBoxBlendOriginalCategory.Text = string.Empty;
            TextBoxBlendOriginalCategory.Enabled = false;
            CheckBoxBlendOriginalCategory.Checked = false;
        
            TextBoxColorRGB_R.Text = string.Empty;
            TextBoxColorRGB_R.Enabled = false;
            CheckBoxColorRGB_R.Checked = false;

            TextBoxColorRGB_G.Text = string.Empty;
            TextBoxColorRGB_G.Enabled = false;
            CheckBoxColorRGB_G.Checked = false;

            TextBoxColorRGB_B.Text = string.Empty;
            TextBoxColorRGB_B.Enabled = false;
            CheckBoxColorRGB_B.Checked = false;

            TextBoxColorRGB_A.Text = string.Empty;
            TextBoxColorRGB_A.Enabled = false;
            CheckBoxColorRGB_A.Checked = false;

            TextBoxTextureDiffuseHash.Text = string.Empty;
            TextBoxTextureDiffuseHash.Enabled = false;
            CheckBoxTextureDiffuseHash.Checked = false;

            TextBoxTextureNormalHash.Text = string.Empty;
            TextBoxTextureNormalHash.Enabled = false;
            CheckBoxTextureNormalHash.Checked = false;

            TextBoxTextureLightmapHash.Text = string.Empty;
            TextBoxTextureLightmapHash.Enabled = false;
            CheckBoxTextureLightmapHash.Checked = false;


        }

        public void readAndSetConfig(string jsonConfigFilePath)
        {
            //we clean all config before we read a new one to make sure all UI work correctly.
            initializeConfig();

            //read json file
            string configJson = File.ReadAllText(jsonConfigFilePath);
            //parse json file
            JObject configJsonObject = JObject.Parse(configJson);

            TabControlModMaking.SelectedIndex = 0;
            JObject elementListObject = (JObject)configJsonObject["ElementList"];
            List<JObject> objectList = elementListObject.Properties().Select(p => (JObject)p.Value).ToList();

            // clean all previous rows because we need a new config.
            dataGridViewElementList.Rows.Clear();

            D3D11ElementAttributesList = new List<D3D11ElementAttributes>();

            // here can't use DataSource because we make sure we can modify it after we add it into 
            // dataGridView, if you try to use DataSource it can not be modified later.
            foreach (JObject obj in objectList)
            {
                // we turn it to object first so we can easily add it into DataGridView
                D3D11ElementAttributes d3d11ElementAttributes = obj.ToObject<D3D11ElementAttributes>();
                D3D11ElementAttributesList.Append(d3d11ElementAttributes);

                dataGridViewElementList.Rows.Add(
                    d3d11ElementAttributes.ElementOrder,
                    d3d11ElementAttributes.SemanticName,
                    d3d11ElementAttributes.ExtractSemanticName,
                    d3d11ElementAttributes.SemanticIndex,
                    d3d11ElementAttributes.OutputSemanticIndex,
                    d3d11ElementAttributes.Format,
                    d3d11ElementAttributes.InputSlot,
                    d3d11ElementAttributes.InputSlotClass,
                    d3d11ElementAttributes.InstanceDataStepRate,
                    d3d11ElementAttributes.ByteWidth,
                    d3d11ElementAttributes.ExtractVertexBufferSlot,
                    d3d11ElementAttributes.ExtractTopology,
                    d3d11ElementAttributes.Category
                );

            }

            // Then we log it into output, comments these lines if you don't like it.
            LogOutput("Reading configs from: " + jsonConfigFilePath);
            LogOutput("Reading D3D11 Elements Setting: ");
            LogOutput(elementListObject.ToString());

            TabControlModMaking.SelectedIndex = 1;
            // Now we read config and set Config tab's every single part.
            string LoaderFolder = (string)configJsonObject["LoaderFolder"];
            TextBoxLoaderFolder.Text = LoaderFolder;
            LogOutput("LoaderFolder: " + LoaderFolder);

            string OutputFolder = (string)configJsonObject["OutputFolder"];
            TextBoxOutputFolder.Text = OutputFolder;
            LogOutput("OutputFolder: " + OutputFolder);

            string FrameAnalysisFolder = (string)configJsonObject["FrameAnalysisFolder"];
            TextBoxFrameAnalysisFolder.Text = FrameAnalysisFolder;
            LogOutput("FrameAnalysisFolder: " + FrameAnalysisFolder);

            string Engine = (string)configJsonObject["Engine"];
            ComboBoxGameEngine.SelectedItem = Engine;
            LogOutput("Engine: " + Engine);

            string DrawIndexBufferHash = (string)configJsonObject["DrawIndexBufferHash"];
            TextBoxDrawIndexBufferHash.Text = DrawIndexBufferHash;
            LogOutput("DrawIndexBufferHash: " + DrawIndexBufferHash);

            string ModName = (string)configJsonObject["ModName"];
            TextBoxModName.Text = ModName;
            LogOutput("ModName: " + ModName);

            bool GenerateVertexShaderCheck = (bool)configJsonObject["GenerateVertexShaderCheck"];
            LogOutput("GenerateVertexShaderCheck: " + GenerateVertexShaderCheck);

            List<string> VertexShaderCheckSlots = configJsonObject["VertexShaderCheckSlots"].ToObject<List<string>>();
            string VertexShaderCheckSlotsString = "";
            if (VertexShaderCheckSlots.Count != 0)
            {
                CheckBoxGenerateVertexShaderCheck.Checked = true;
                foreach (string checkSlot in VertexShaderCheckSlots)
                {
                    VertexShaderCheckSlotsString += checkSlot + ",";
                }
                VertexShaderCheckSlotsString = VertexShaderCheckSlotsString.Substring(0, VertexShaderCheckSlotsString.Length - 1);
                TextBoxVertexShaderCheckSlots.Text = VertexShaderCheckSlotsString;
                LogOutput("VertexShaderCheckSlots: " + VertexShaderCheckSlotsString);
            }
            else
            {
                CheckBoxGenerateVertexShaderCheck.Checked = false;
            }


            List<string> SkipIndexBufferHashList = configJsonObject["SkipIndexBufferHashList"].ToObject<List<string>>();
            string SkipIndexBufferHashListString = "";
            if (SkipIndexBufferHashList.Count != 0)
            {
                CheckBoxSkipIndexBufferHashList.Checked = true;
                foreach (string skipIB in SkipIndexBufferHashList)
                {
                    SkipIndexBufferHashListString += skipIB + ",";
                }
                SkipIndexBufferHashListString = SkipIndexBufferHashListString.Substring(0, SkipIndexBufferHashListString.Length - 1);
                TextBoxSkipIndexBufferHashList.Text = SkipIndexBufferHashListString;
                LogOutput("SkipIndexBufferHashListString: " + SkipIndexBufferHashListString);
            }
            else
            {
                CheckBoxSkipIndexBufferHashList.Checked = false;
            }


            string AimationVertexShader = (string)configJsonObject["AimationVertexShader"];
            if (string.IsNullOrEmpty(AimationVertexShader))
            {
                CheckBoxAnimationVertexShaderHash.Checked = false;
            }
            else
            {
                CheckBoxAnimationVertexShaderHash.Checked = true;
                TextBoxAnimationVertexShaderHash.Text = AimationVertexShader;
                LogOutput("AimationVertexShader: " + AimationVertexShader);
            }

            string BlendDrawCategory = (string)configJsonObject["BlendDrawCategory"];
            if (string.IsNullOrEmpty(BlendDrawCategory))
            {
                CheckBoxBlendDrawCategory.Checked = false;
            }
            else
            {
                CheckBoxBlendDrawCategory.Checked = true;
                TextBoxBlendDrawCategory.Text = BlendDrawCategory;
                LogOutput("BlendDrawCategory: " + BlendDrawCategory);
            }

            string BlendOriginalCategory = (string)configJsonObject["BlendOriginalCategory"];
            if (string.IsNullOrEmpty(BlendOriginalCategory))
            {
                CheckBoxBlendOriginalCategory.Checked = false;
            }
            else
            {
                CheckBoxBlendOriginalCategory.Checked = true;

                TextBoxBlendOriginalCategory.Text = BlendOriginalCategory;
                LogOutput("BlendOriginalCategory: " + BlendOriginalCategory);
            }

            string SetColor_rgb_R = (string)configJsonObject["SetColor_rgb_R"];
            if (string.IsNullOrEmpty(SetColor_rgb_R))
            {
                CheckBoxColorRGB_R.Checked = false;
            }
            else
            {
                CheckBoxColorRGB_R.Checked = true;

                TextBoxColorRGB_R.Text = SetColor_rgb_R;
                LogOutput("SetColor_rgb_R: " + SetColor_rgb_R);
            }
            string SetColor_rgb_G = (string)configJsonObject["SetColor_rgb_G"];
            if (string.IsNullOrEmpty(SetColor_rgb_G))
            {
                CheckBoxColorRGB_G.Checked = false;
            }
            else
            {
                CheckBoxColorRGB_G.Checked = true;

                TextBoxColorRGB_G.Text = SetColor_rgb_G;
                LogOutput("SetColor_rgb_G: " + SetColor_rgb_G);
            }
            string SetColor_rgb_B = (string)configJsonObject["SetColor_rgb_B"];
            if (string.IsNullOrEmpty(SetColor_rgb_B))
            {
                CheckBoxColorRGB_B.Checked = false;
            }
            else
            {
                CheckBoxColorRGB_B.Checked = true;

                TextBoxColorRGB_B.Text = SetColor_rgb_B;
                LogOutput("SetColor_rgb_B: " + SetColor_rgb_B);
            }
            string SetColor_rgb_A = (string)configJsonObject["SetColor_rgb_A"];
            if (string.IsNullOrEmpty(SetColor_rgb_A))
            {
                CheckBoxColorRGB_A.Checked = false;
            }
            else
            {
                CheckBoxColorRGB_A.Checked = true;

                TextBoxColorRGB_A.Text = SetColor_rgb_A;
                LogOutput("SetColor_rgb_A: " + SetColor_rgb_A);
            }

            string TextureDiffuseHash = (string)configJsonObject["TextureDiffuseHash"];
            if (string.IsNullOrEmpty(TextureDiffuseHash))
            {
                CheckBoxTextureDiffuseHash.Checked = false;
            }
            else
            {
                CheckBoxTextureDiffuseHash.Checked = true;

                TextBoxTextureDiffuseHash.Text = TextureDiffuseHash;
                LogOutput("TextureDiffuseHash: " + TextureDiffuseHash);
            }

            string TextureNormalHash = (string)configJsonObject["TextureNormalHash"];
            if (string.IsNullOrEmpty(TextureNormalHash))
            {
                CheckBoxTextureNormalHash.Checked = false;
            }
            else
            {
                CheckBoxTextureNormalHash.Checked = true;

                TextBoxTextureNormalHash.Text = TextureNormalHash;
                LogOutput("TextureNormalHash: " + TextureNormalHash);
            }

            string TextureLightmapHash = (string)configJsonObject["TextureLightmapHash"];
            if (string.IsNullOrEmpty(TextureLightmapHash))
            {
                CheckBoxTextureLightmapHash.Checked = false;
            }
            else
            {
                CheckBoxTextureLightmapHash.Checked = true;

                TextBoxTextureLightmapHash.Text = TextureLightmapHash;
                LogOutput("TextureLightmapHash: " + TextureLightmapHash);
            }

            //set variable to use later in different class.
            configAttributes = new ConfigAttributes();

            configAttributes.FrameAnalysisFolder = FrameAnalysisFolder;
            configAttributes.LoaderFolder = LoaderFolder;
            configAttributes.OutputFolder = OutputFolder;
            configAttributes.DrawIndexBufferHash = DrawIndexBufferHash;
            configAttributes.Engine = Engine;
            configAttributes.ModName = ModName;
            configAttributes.VertexShaderCheckSlots = VertexShaderCheckSlotsString;
            configAttributes.SkipIndexBufferHashList = SkipIndexBufferHashListString;
            configAttributes.AnimationVertexShader = AimationVertexShader;
            configAttributes.BlendDrawCategory = BlendDrawCategory;
            configAttributes.BlendOriginalCategory = BlendOriginalCategory;
            configAttributes.SetColor_rgb_R = SetColor_rgb_R;
            configAttributes.SetColor_rgb_G = SetColor_rgb_G;
            configAttributes.SetColor_rgb_B = SetColor_rgb_B;
            configAttributes.SetColor_rgb_A = SetColor_rgb_A;
            configAttributes.TextureDiffuseHash = TextureDiffuseHash;
            configAttributes.TextureNormalHash = TextureNormalHash;
            configAttributes.TextureLightmapHash = TextureLightmapHash;
        }

        private void CheckBoxGenerateVertexShaderCheck_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxVertexShaderCheckSlots.Enabled = CheckBoxGenerateVertexShaderCheck.Checked;
        }

        private void CheckBoxSkipIndexBufferHashList_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxSkipIndexBufferHashList.Enabled = CheckBoxSkipIndexBufferHashList.Checked;
        }

        private void CheckBoxAnimationVertexShaderHash_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxAnimationVertexShaderHash.Enabled = CheckBoxAnimationVertexShaderHash.Checked;
        }

        private void CheckBoxBlendDrawCategory_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxBlendDrawCategory.Enabled = CheckBoxBlendDrawCategory.Checked;
        }

        private void CheckBoxBlendOriginalCategory_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxBlendOriginalCategory.Enabled = CheckBoxBlendOriginalCategory.Checked;
        }

        private void CheckBoxColorRGB_R_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxColorRGB_R.Enabled = CheckBoxColorRGB_R.Checked;
        }

        private void CheckBoxColorRGB_B_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxColorRGB_B.Enabled = CheckBoxColorRGB_B.Checked;
        }

        private void CheckBoxColorRGB_G_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxColorRGB_G.Enabled = CheckBoxColorRGB_G.Checked;
        }

        private void CheckBoxColorRGB_A_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxColorRGB_A.Enabled = CheckBoxColorRGB_A.Checked;
        }

        private void CheckBoxTextureDiffuseHash_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxTextureDiffuseHash.Enabled = CheckBoxTextureDiffuseHash.Checked;
        }

        private void CheckBoxTextureNormalHash_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxTextureNormalHash.Enabled = CheckBoxTextureNormalHash.Checked;
        }

        private void CheckBoxTextureLightmapHash_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxTextureLightmapHash.Enabled = CheckBoxTextureLightmapHash.Checked;
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initializeConfig();
        }
    }
}
