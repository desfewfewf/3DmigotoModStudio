using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DmigotoModStudio
{
    public partial class Studio
    {
        public void extractModelUnity()
        {
            //1.Get a work folder.
            string WorkFolder = configAttributes.LoaderFolder + configAttributes.FrameAnalysisFolder + "\\";
            LogOutput("Start to extract model from FrameAnalysisFolder: ");
            LogOutput("WorkFolder: " +  WorkFolder);








            //Swtich to Output tab and jump to end of text
            TabControlModMaking.SelectedIndex = 2;
            RichTextRunOutput.ScrollToCaret();
        }
    }
}
