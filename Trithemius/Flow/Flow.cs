using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trithemius.Flow
{
    public class Flow
    {
        public List<char> CoderText(List<char> textChar)
        {
            Coder.Coder coder = new Coder.Coder();
            List<char> coderChar = coder.CoderText(textChar);
            return coderChar;
        }

        public List<char> DecoderText(List<char> textChar)
        {
            Decoder.Decoder decoder = new Decoder.Decoder();
            List<char> coderChar = decoder.DecoderText(textChar);
            return coderChar;
        }
    }
}
