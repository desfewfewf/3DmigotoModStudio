using _3DmigotoModStudio.Configs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DmigotoModStudio
{
    public partial class Studio
    {
        // watch out,we only need to check the whole config when run extractModel and GenerateMod
        // other analysis function won't need this much check, they only need to check what the arguments
        // they are fill in.
        public bool configSanityCheck()
        {
            // TODO I'm lazy to check these value ,maybe later.
            return true;
        }

        //Log output info to RunOutputRichText
        public void LogOutput(string outputText, Color textColor = default)
        {
            if (textColor == default)
            {
                textColor = Color.Lime;
            }
            // log the length when we add ne content
            int startPosition = RichTextRunOutput.TextLength;
            RichTextRunOutput.AppendText(outputText);
            RichTextRunOutput.AppendText(Environment.NewLine);

            int endPosition = RichTextRunOutput.TextLength;

            RichTextRunOutput.Select(startPosition, endPosition - startPosition);
            RichTextRunOutput.SelectionColor = textColor;
        }
        public void readConfigIntoVariables()
        {
            //Reset all config from the GUI
            ConfigAttributes saveConfigAttributes = new ConfigAttributes();
            saveConfigAttributes.FrameAnalysisFolder = TextBoxFrameAnalysisFolder.Text;
            saveConfigAttributes.LoaderFolder = TextBoxLoaderFolder.Text;
            saveConfigAttributes.OutputFolder = TextBoxOutputFolder.Text;
            saveConfigAttributes.DrawIndexBufferHash = TextBoxDrawIndexBufferHash.Text;
            saveConfigAttributes.Engine = ComboBoxGameEngine.Text;
            saveConfigAttributes.ModName = TextBoxModName.Text;
            saveConfigAttributes.VertexShaderCheckSlots = TextBoxVertexShaderCheckSlots.Text;
            saveConfigAttributes.SkipIndexBufferHashList = TextBoxSkipIndexBufferHashList.Text;
            saveConfigAttributes.AnimationVertexShader = TextBoxAnimationVertexShaderHash.Text;
            saveConfigAttributes.BlendDrawCategory = TextBoxBlendDrawCategory.Text;
            saveConfigAttributes.BlendOriginalCategory = TextBoxBlendOriginalCategory.Text;
            saveConfigAttributes.SetColor_rgb_R = TextBoxColorRGB_R.Text;
            saveConfigAttributes.SetColor_rgb_G = TextBoxColorRGB_G.Text;
            saveConfigAttributes.SetColor_rgb_B = TextBoxColorRGB_B.Text;
            saveConfigAttributes.SetColor_rgb_A = TextBoxColorRGB_A.Text;
            saveConfigAttributes.TextureDiffuseHash = TextBoxTextureDiffuseHash.Text;
            saveConfigAttributes.TextureNormalHash = TextBoxTextureNormalHash.Text;
            saveConfigAttributes.TextureLightmapHash = TextBoxTextureLightmapHash.Text;

            configAttributes = saveConfigAttributes;
            //save d3d11 attributes

            List<D3D11ElementAttributes> saveD3D11ElementAttributesList = new List<D3D11ElementAttributes>();
            foreach (DataGridViewRow row in dataGridViewElementList.Rows)
            {
                if (!row.IsNewRow && row.Cells[0].Value != null)
                {
                    D3D11ElementAttributes saveD3D11ElementAttributes = new D3D11ElementAttributes();
                    saveD3D11ElementAttributes.ElementOrder = int.Parse(row.Cells["ElementOrder"].Value.ToString());
                    saveD3D11ElementAttributes.SemanticName = row.Cells["SemanticName"].Value.ToString();
                    saveD3D11ElementAttributes.ExtractSemanticName = row.Cells["ExtractSemanticName"].Value.ToString();
                    saveD3D11ElementAttributes.SemanticIndex = row.Cells["SemanticIndex"].Value.ToString();
                    saveD3D11ElementAttributes.OutputSemanticIndex = row.Cells["OutputSemanticIndex"].Value.ToString();
                    saveD3D11ElementAttributes.Format = row.Cells["Format"].Value.ToString();
                    saveD3D11ElementAttributes.InputSlot = row.Cells["InputSlot"].Value.ToString();
                    saveD3D11ElementAttributes.InputSlotClass = row.Cells["InputSlotClass"].Value.ToString();
                    saveD3D11ElementAttributes.InstanceDataStepRate = row.Cells["InstanceDataStepRate"].Value.ToString();
                    saveD3D11ElementAttributes.ByteWidth = int.Parse(row.Cells["ByteWidth"].Value.ToString());
                    saveD3D11ElementAttributes.ExtractVertexBufferSlot = row.Cells["ExtractVertexBufferSlot"].Value.ToString();
                    saveD3D11ElementAttributes.ExtractTopology = row.Cells["ExtractTopology"].Value.ToString();
                    saveD3D11ElementAttributes.Category = row.Cells["Category"].Value.ToString();
                    saveD3D11ElementAttributesList.Add(saveD3D11ElementAttributes);
                }
            }
            D3D11ElementAttributesList = saveD3D11ElementAttributesList;


        }

        public void saveConfigJson(string saveJsonPath)
        {
            readConfigIntoVariables();

            if (!File.Exists(saveJsonPath))
            {
                //Create a Config.json at runPath.
                File.Create(saveJsonPath).Close();
            }
            //Save all config to Config.json
            JObject jsonObject = JObject.FromObject(this.configAttributes);
            jsonObject["ElementList"] = JArray.FromObject(this.D3D11ElementAttributesList);

            string jsonString = jsonObject.ToString();
            File.WriteAllText(saveJsonPath, jsonString);

            MessageBox.Show("Successfully save to " + saveJsonPath);

        }
        public void initializeConfig()
        {
            dataGridViewElementList.Rows.Clear();

            TextBoxLoaderFolder.Text = string.Empty;
            TextBoxOutputFolder.Text = string.Empty;
            TextBoxFrameAnalysisFolder.Text = string.Empty;

            ComboBoxGameEngine.SelectedIndex = -1;

            TextBoxDrawIndexBufferHash.Text = string.Empty;
            TextBoxModName.Text = string.Empty;

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

            // get ElementList JArray
            JArray elementList = (JArray)configJsonObject["ElementList"];

            // clean all previous rows because we need a new config.
            dataGridViewElementList.Rows.Clear();

            D3D11ElementAttributesList = new List<D3D11ElementAttributes>();

            // here can't use DataSource because we make sure we can modify it after we add it into 
            // dataGridView, if you try to use DataSource it can not be modified later.
            foreach (JObject obj in elementList)
            {
                // we turn it to object first so we can easily add it into DataGridView
                D3D11ElementAttributes d3d11ElementAttributes = obj.ToObject<D3D11ElementAttributes>();
                D3D11ElementAttributesList.Add(d3d11ElementAttributes);

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
            LogOutput(elementList.ToString());

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


            string VertexShaderCheckSlotsString = (string)configJsonObject["VertexShaderCheckSlots"];
            if (string.IsNullOrEmpty(VertexShaderCheckSlotsString))
            {
                CheckBoxGenerateVertexShaderCheck.Checked = false;
            }
            else
            {
                CheckBoxGenerateVertexShaderCheck.Checked = true;
                TextBoxVertexShaderCheckSlots.Text = VertexShaderCheckSlotsString;
                LogOutput("VertexShaderCheckSlots: " + VertexShaderCheckSlotsString);
            }


            string SkipIndexBufferHashListString = (string)configJsonObject["SkipIndexBufferHashList"];
            if (string.IsNullOrEmpty(SkipIndexBufferHashListString))
            {
                CheckBoxSkipIndexBufferHashList.Checked = false;
            }
            else
            {
                CheckBoxSkipIndexBufferHashList.Checked = true;
                TextBoxSkipIndexBufferHashList.Text = SkipIndexBufferHashListString;
                LogOutput("SkipIndexBufferHashListString: " + SkipIndexBufferHashListString);
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


    }
}
