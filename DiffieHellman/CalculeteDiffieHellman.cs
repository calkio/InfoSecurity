using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DiffieHellman
{
    public class CalculeteDiffieHellman
    {
        private BigInteger _g = BigInteger.Parse("5"); // Простое число
        private BigInteger _p = BigInteger.Parse("23"); // Сильно простое число (p - простое и (p-1)/2 - тоже простое)

        private BigInteger _privateKeyFirst; 
        private BigInteger _privateKeySecond;

        private BigInteger _publicKeyFirst;
        private BigInteger _publicKeySecond;


        public CalculeteDiffieHellman()
        {
            InitPrivateKey();
            InitPublicKey();
        }

        public DiffieHellmanEntity CalculetePublicFirst()
        {
            BigInteger sharedKey = ModExp(_publicKeySecond, _privateKeyFirst, _p);
            DiffieHellmanEntity diffieHellmanEntity = new DiffieHellmanEntity(1, _privateKeyFirst, _publicKeyFirst, sharedKey);
            return diffieHellmanEntity;
        }

        public DiffieHellmanEntity CalculetePublicSecond()
        {
            BigInteger sharedKey = ModExp(_publicKeyFirst, _privateKeySecond, _p);
            DiffieHellmanEntity diffieHellmanEntity = new DiffieHellmanEntity(2, _privateKeySecond, _publicKeySecond, sharedKey);
            return diffieHellmanEntity;
        }



        private void InitPublicKey()
        {
            _publicKeyFirst = ModExp(_g, _privateKeyFirst, _p);
            _publicKeySecond = ModExp(_g, _privateKeySecond, _p);
        }

        private void InitPrivateKey()
        {
            _privateKeyFirst = GenerateRandomBigInteger(1, _p - 1);
            _privateKeySecond = GenerateRandomBigInteger(1, _p - 1);
        }

        static BigInteger GenerateRandomBigInteger(BigInteger minValue, BigInteger maxValue)
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
        static BigInteger ModExp(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
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
