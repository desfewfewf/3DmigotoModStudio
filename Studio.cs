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
        string runPath;
        string defaultConfigPath;

        public Studio()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = Properties.Resources.NicoLove;
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "3Dmigoto Mod Studio " + version.ToString();
            initializeConfig();
            runPath = Application.StartupPath.ToString() + "\\";
            defaultConfigPath = runPath + "Config.json";

            if (File.Exists(defaultConfigPath))
            {
                readAndSetConfig(defaultConfigPath);
            }
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

        //Save to Config.json
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveConfigJson(defaultConfigPath);
        }
       

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show open json file dialog
            DialogResult result = saveFileDialogJson.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedFilePath = saveFileDialogJson.FileName;
                saveConfigJson(selectedFilePath);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save current config?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                saveConfigJson(defaultConfigPath);
                initializeConfig();
            }
            else if (result == DialogResult.No)
            {
                initializeConfig();
            }
        }

        private void ButtonSelectLoaderFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Choose your LoaderFolder";
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFolder = folderBrowserDialog1.SelectedPath + "\\";

                TextBoxLoaderFolder.Text = selectedFolder;
            }
        }

        private void extractModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //read from GUI
            readConfigIntoVariables();

            //then we need to check if all the config is correct.
            //but this is always optional because if you know how it works
            //you will always fill the correct value.
            if (configSanityCheck())
            {
                if (this.configAttributes.Engine == "Unity")
                {
                    extractModelUnity();
                } 
                else if(this.configAttributes.Engine == "UE4")
                {
                    extractModelUE4();
                }
                else
                {
                    MessageBox.Show("No such Engine.");
                }

            }

        }

        private void generateModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateMod();
        }
    }
}
