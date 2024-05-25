using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LechmanTest
{
    public class CalculeteLechmanTest
    {
        public List<LechmanTestEntity> CheakSimpleValue(BigInteger n, int countIterations)
        {
            List<LechmanTestEntity> lechmanTestEntities = new List<LechmanTestEntity>();
            for (int i = 0; i < countIterations; i++)
            {
                BigInteger a = GenerateRandomBigInteger(1, n - 1); // Случайное число [1;n-1]
                BigInteger exponent = (BigInteger)Math.Pow((int)a, (int)(n - 1) / 2);
                BigInteger r = exponent % n;

                LechmanTestEntity lechmanTestEntity = new LechmanTestEntity(i + 1, a, r, (r == 1 || r == n-1) ? false : true);
                lechmanTestEntities.Add(lechmanTestEntity);
            }

            return lechmanTestEntities;
        }

        private BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = maxValue.ToByteArray();
            BigInteger randomValue;

            do
            {
                rng.GetBytes(bytes);
                bytes[bytes.Length - 1] &= 0x7F; // Убедимся, что число неотрицательное
                randomValue = new BigInteger(bytes);
            } while (randomValue < minValue || randomValue >= maxValue);

            return randomValue;
        }

        // Метод для быстрого возведения в степень по модулю
        // Для вычисления 5^6 mod(23), сначала возводим 5 в степень 6, получаем 15625, затем делим 15625 на 23, получаем целую часть 679, умножаем 679 на 23, получаем 15617, и наконец, вычитаем 15617 из 15625, получаем результат 8.
        private BigInteger ModExp(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
        {
            BigInteger result = 1;
            baseValue = baseValue % modulus;
            while (exponent > 0)
            {
                if ((exponent % 2) == 1) // Если текущий бит равен 1
                {
                    result = (result * baseValue) % modulus;
                }
                exponent = exponent >> 1; // Переходим к следующему биту
                baseValue = (baseValue * baseValue) % modulus;
            }
            return result;
        }
    }
}
