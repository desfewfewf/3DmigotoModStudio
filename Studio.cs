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

        //Open a json file to read configs.
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show open json file dialog
            DialogResult result = openFileDialogJson.ShowDialog();

            if (result == DialogResult.OK)
            {
                string selectedFilePath = openFileDialogJson.FileName;
                string fileName = System.IO.Path.GetFileName(selectedFilePath);
                // 读取 JSON 文件内容
                string json = File.ReadAllText(fileName);

                // 使用 JObject 解析 JSON
                JObject jObject = JObject.Parse(json);

                // 通过键访问值
                string value = (string)jObject["key"];

            }
            

        }


    }
}
