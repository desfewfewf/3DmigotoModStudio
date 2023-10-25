using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DmigotoModStudio
{
    internal class D3D11ElementAttributes
    {
        public int ElementOrder {  get; set; }
        public string SemanticName {  get; set; }
        public string ExtractSemanticName {  get; set; }
        public string SemanticIndex {  get; set; }
        public string OutputSemanticIndex {  get; set; }
        public string Format {  get; set; }
        public string InputSlot {  get; set; }
        public string InputSlotClass {  get; set; }
        public string InstanceDataStepRate {  get; set; }
        public int ByteWidth {  get; set; }
        public string ExtractVertexBufferSlot {  get; set; }
        public string ExtractTopology {  get; set; }
        public string Category {  get; set; }
    }
}
