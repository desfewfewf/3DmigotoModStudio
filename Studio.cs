﻿using System;
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

namespace _3DmigotoModStudio
{
    public partial class Studio : Form
    {
        public Studio()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.NicoLove;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "3Dmigoto Mod Studio " + version.ToString();
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

        public void readAndSetConfig(string jsonConfigFilePath)
        {
            //read json file
            string configJson = File.ReadAllText(jsonConfigFilePath);
            //parse json file
            JObject configJsonObject = JObject.Parse(configJson);

            TabControlModMaking.SelectedIndex = 0;
            JObject elementListObject = (JObject)configJsonObject["ElementList"];
            List<JObject> objectList = elementListObject.Properties().Select(p => (JObject)p.Value).ToList();

            // clean all previous rows because we need a new config.
            dataGridViewElementList.Rows.Clear();

            // here can't use DataSource because we make sure we can modify it after we add it into 
            // dataGridView, if you try to use DataSource it can not be modified later.
            foreach (JObject obj in objectList)
            {
                // we turn it to object first so we can easily add it into DataGridView
                D3D11ElementClass element = obj.ToObject<D3D11ElementClass>();

                dataGridViewElementList.Rows.Add(
                    element.ElementOrder,
                    element.SemanticName,
                    element.ExtractSemanticName,
                    element.SemanticIndex,
                    element.OutputSemanticIndex,
                    element.Format,
                    element.InputSlot,
                    element.InputSlotClass,
                    element.InstanceDataStepRate,
                    element.ByteWidth,
                    element.ExtractVertexBufferSlot,
                    element.ExtractTopology,
                    element.Category
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
            CheckBoxGenerateVertexShaderCheck.Checked = GenerateVertexShaderCheck;
            LogOutput("GenerateVertexShaderCheck: " + GenerateVertexShaderCheck);

            List<string> VertexShaderCheckSlots = configJsonObject["VertexShaderCheckSlots"].ToObject<List<string>>();
            string VertexShaderCheckSlotsString = "";
            foreach (string checkSlot in VertexShaderCheckSlots)
            {
                VertexShaderCheckSlotsString += checkSlot + ",";
            }
            VertexShaderCheckSlotsString = VertexShaderCheckSlotsString.Substring(0, VertexShaderCheckSlotsString.Length - 1);
            TextBoxVertexShaderCheckSlots.Text = VertexShaderCheckSlotsString;
            LogOutput("VertexShaderCheckSlots: " + VertexShaderCheckSlotsString);

            List<string> SkipIndexBufferHashList = configJsonObject["SkipIndexBufferHashList"].ToObject<List<string>>();
            if (SkipIndexBufferHashList.Count != 0)
            {
                CheckBoxSkipIndexBufferHashList.Checked = true;
            }
            else
            {
                CheckBoxSkipIndexBufferHashList.Checked = false;
            }
            string SkipIndexBufferHashListString = "";
            foreach (string skipIB in SkipIndexBufferHashList)
            {
                SkipIndexBufferHashListString += skipIB + ",";
            }
            SkipIndexBufferHashListString = SkipIndexBufferHashListString.Substring(0, SkipIndexBufferHashListString.Length - 1);
            TextBoxSkipIndexBufferHashList.Text = SkipIndexBufferHashListString;
            LogOutput("SkipIndexBufferHashListString: " + SkipIndexBufferHashListString);

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


        }


        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
