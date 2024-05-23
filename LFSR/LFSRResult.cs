using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFSR
{
    public class LFSRResult
    {
        public int Iteration { get; set; }
        public uint DecimalValue { get; set; }
        public string BinaryValue { get; set; }
        public int OutputBit { get; set; }
    }
}
