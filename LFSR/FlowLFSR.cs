using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFSR
{
    public class FlowLFSR
    {
        private static uint _shiftRegister;

        public FlowLFSR(uint ShiftRegister)
        {
            _shiftRegister = ShiftRegister;
        }

        private int LFSR()
        {
            // Вычисляем новый бит обратной связи на основе отводов
            uint new_bit =
                ((_shiftRegister >> 31) ^ // бит 32 
                 (_shiftRegister >> 26) ^ // бит 27 
                 (_shiftRegister >> 24) ^ // бит 25 
                 (_shiftRegister >> 1) ^  // бит 2  
                 _shiftRegister) & 1;     // бит 0  

            // Обновляем значение регистра
            _shiftRegister = (_shiftRegister >> 1) | (new_bit << 31); // Сдвигаем регистр вправо и вставляем новый бит в старший разряд

            // Возвращаем младший бит
            return (int)(_shiftRegister & 0x00000001);
        }

        public List<LFSRResult> RunLFSR(int cycles)
        {
            List<LFSRResult> results = new List<LFSRResult>();

            for (int i = 0; i < cycles; i++)
            {
                int outputBit = LFSR(); // Обновляем регистр и получаем выходной бит
                _shiftRegister = _shiftRegister ^ (uint)(outputBit == 1 ? uint.MaxValue : 0);
                results.Add(new LFSRResult
                {
                    Iteration = i + 1,
                    DecimalValue = _shiftRegister,
                    BinaryValue = Convert.ToString(_shiftRegister, 2).PadLeft(32, '0'),
                    OutputBit = outputBit
                });
            }

            return results;
        }

    }
}
