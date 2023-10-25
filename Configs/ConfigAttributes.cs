using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DmigotoModStudio.Configs
{
    internal class ConfigAttributes
    {

        public string FrameAnalysisFolder {  get; set; }
        public string LoaderFolder { get; set; }
        public string OutputFolder { get; set; }
        public string DrawIndexBufferHash { get; set; }
        public string Engine {  get; set; }
        public string ModName {  get; set; }
        public string VertexShaderCheckSlots {  get; set; }
        public string SkipIndexBufferHashList {  get; set; }
        public string AnimationVertexShader {  get; set; }
        public string BlendDrawCategory {  get; set; }
        public string BlendOriginalCategory {  get; set; }
        public string SetColor_rgb_R {  get; set; }
        public string SetColor_rgb_G {  get; set; }
        public string SetColor_rgb_B {  get; set; }
        public string SetColor_rgb_A {  get; set; }
        public string TextureDiffuseHash {  get; set; }
        public string TextureNormalHash {  get; set; }
        public string TextureLightmapHash {  get; set; }

    }
}
