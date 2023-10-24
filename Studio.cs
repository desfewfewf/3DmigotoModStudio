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
                //get json path
                string selectedFilePath = openFileDialogJson.FileName;
                //read json file
                string configJson = File.ReadAllText(selectedFilePath);
                //parse json file
                JObject configJsonObject = JObject.Parse(configJson);

                JObject elementListObject = (JObject)configJsonObject["ElementList"];
                List<JObject> objectList = elementListObject.Properties().Select(p => (JObject)p.Value).ToList();

                // clean all previous rows because we need a new config.
                dataGridViewElementList.Rows.Clear();
                LogOutput("Reading configs from: " + selectedFilePath);
                LogOutput("Reading D3D11 Elements Setting: ");
                LogOutput(elementListObject.ToString());

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
    }
}
