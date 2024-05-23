using Caesar;
using Cryptanalysis.DataAccessAlphabet.Calculete;
using Euclid;
using Lab.Entity;
using Lab.Infastructure;
using Lab.ViewModel.Base;
using LFSR;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab.ViewModel
{
    internal class MainVM : BaseVM
    {
        #region Lab1

        private string _data;
        public string Data { get => _data; set => Set(ref _data, value); }


        private int _step;
        public int Step { get => _step; set => Set(ref _step, value); }


        private Dictionary<int, double> _zxc;
        public Dictionary<int, double> ZXC { get => _zxc; set => Set(ref _zxc, value); }

        #endregion

        #region Lab2

        private string _inputTextLab2;
        public string InputTextLab2 { get => _inputTextLab2; set => Set(ref _inputTextLab2, value); }


        private string _outputTextLab2;
        public string OutputTextLab2 { get => _outputTextLab2; set => Set(ref _outputTextLab2, value); }


        private string _entropyLab2Input;
        public string EntropyLab2Input { get => _entropyLab2Input; set => Set(ref _entropyLab2Input, value); }


        private string _entropyLab2Output;
        public string EntropyLab2Output { get => _entropyLab2Output; set => Set(ref _entropyLab2Output, value); }

        #endregion

        #region Lab3

        public ObservableCollection<Strochechka> Strochechki = new ObservableCollection<Strochechka>();
        private Dictionary<char, string> symbols = new Dictionary<char, string>();

        private string _startMessage;
        public string startMessage { get => _startMessage; set => Set(ref _startMessage, value); }


        private string _cryptoMessage;
        public string cryptoMessage { get => _cryptoMessage; set => Set(ref _cryptoMessage, value); }

        #endregion

        #region Lab4

        private int _inputA;
        public int InputA { get => _inputA; set => Set(ref _inputA, value); }


        private int _inputB;
        public int InputB { get => _inputB; set => Set(ref _inputB, value); }


        private ObservableCollection<EuclidEntity> _euclids = new ObservableCollection<EuclidEntity>();
        public ObservableCollection<EuclidEntity> Euclids { get => _euclids; set => Set(ref _euclids, value); }

        #endregion


        #region Lab5

        private uint _inputValueLab5;


        private string _inputTextLab5;
        public string InputTextLab5 { get => _inputTextLab5; set => Set(ref _inputTextLab5, value); }


        private string _outputTextLab5;
        public string OutputTextLab5 { get => _outputTextLab5; set => Set(ref _outputTextLab5, value); }


        private ObservableCollection<LFSRResult> _lFSRResults = new ObservableCollection<LFSRResult>();
        public ObservableCollection<LFSRResult> LFSRResults { get => _lFSRResults; set => Set(ref _lFSRResults, value); }

        #endregion


        #region Lab1 КОМАНДЫ

        public ICommand GetCoderCommand { get; }

        private bool CanCoderCommand(object p) => true;

        private void OnCoderCommand(object p)
        {
            CaesarProcces caesarProcces = new CaesarProcces(_data);
            Data = caesarProcces.GetCaesar(_data, _step);
            StepSelection stepSelection = new StepSelection(Data);
            ZXC = stepSelection.Probability;
            OnPropertyChanged(nameof(ZXC));
            OnPropertyChanged(nameof(Data));
        }


        public ICommand GetDecoderCommand { get; }

        private bool CanDecoderCommand(object p) => true;

        private void OnDecoderCommand(object p)
        {
            CaesarProcces caesarProcces = new CaesarProcces(_data);
            Data = caesarProcces.GetCaesar(_data, 32 - _step);
            StepSelection stepSelection = new StepSelection(Data);
            ZXC = stepSelection.Probability;
            OnPropertyChanged(nameof(ZXC));
            OnPropertyChanged(nameof(Data));
        }

        #endregion

        #region Lab2 КОМАНДЫ

        public ICommand GetCoderLab2Command { get; }

        private bool CanCoderLab2Command(object p) => string.IsNullOrEmpty(_inputTextLab2) ? false : true;

        private void OnCoderLab2Command(object p)
        {
            Model.Lab2.Coder.Coder coder = new Model.Lab2.Coder.Coder();
            OutputTextLab2 = coder.CoderText(InputTextLab2);

            EntropyLab2Input = Model.Lab2.Entropy.Entropy.CalculateEntropy(_inputTextLab2).ToString();
            EntropyLab2Output = Model.Lab2.Entropy.Entropy.CalculateEntropy(_outputTextLab2).ToString();
        }


        public ICommand GetDecoderLab2Command { get; }

        private bool CanDecoderLab2Command(object p) => string.IsNullOrEmpty(_inputTextLab2) ? false : true;

        private void OnDecoderLab2Command(object p)
        {
            Model.Lab2.Decoder.Decoder decoder = new Model.Lab2.Decoder.Decoder();
            OutputTextLab2 = decoder.DecoderText(InputTextLab2);

            EntropyLab2Input = Model.Lab2.Entropy.Entropy.CalculateEntropy(_inputTextLab2).ToString();
            EntropyLab2Output = Model.Lab2.Entropy.Entropy.CalculateEntropy(_outputTextLab2).ToString();
        }

        #endregion

        #region Lab3 КОМАНДЫ

        #region Расшифровать

        public ICommand GetDecryptCommand { get; }
        private bool CanODecryptCommand(object p)
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnDecryptCommand(object p)
        {
            symbols = GetUniqueChars(_startMessage);
            RunMainCreateDe();
            RunEncript();
        }

        private void RunMainCreateDe()
        {
            Strochechki.Clear();
            foreach (var item in symbols)
            {
                string kod2 = Convert.ToString(item.Key, 2).PadLeft(16, '0');
                int left = item.Key >> 8;
                int right = item.Key & 0xff;
                int xor = left ^ right;
                string kod22 = Convert.ToString(xor, 2).PadLeft(8, '0') + Convert.ToString(left, 2).PadLeft(8, '0');
                Strochechki.Add(new Strochechka(item.Key.ToString(), item.Key, kod2, kod22, left, right, xor));
                symbols[item.Key] = ((char)((xor << 8) | left)).ToString();
            }
        }

        #endregion

        #region  зашифровать

        public ICommand GetOpenTextCommand { get; }
        private bool CanOpenTextCommand(object p)
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnOpenTextCommand(object p)
        {
            symbols = GetUniqueChars(_startMessage);
            RunMainCreate();
            RunEncript();
        }

        private void RunMainCreate()
        {
            Strochechki.Clear();
            foreach (var item in symbols)
            {
                string kod2 = Convert.ToString(item.Key, 2).PadLeft(16, '0');
                int left = item.Key >> 8;
                int right = item.Key & 0xff;
                int xor = left ^ right;
                string kod22 = Convert.ToString(right, 2).PadLeft(8, '0') + Convert.ToString(xor, 2).PadLeft(8, '0');
                Strochechki.Add(new Strochechka(item.Key.ToString(), item.Key, kod2, kod22, left, right, xor));
                symbols[item.Key] = ((char)((right << 8) | xor)).ToString();
            }
        }

        private void RunEncript()
        {
            string message = startMessage;
            _cryptoMessage = "";

            foreach (var item in message)
            {
                _cryptoMessage += symbols[item].ToString();
            }

            OnPropertyChanged(nameof(cryptoMessage));
        }



        static Dictionary<char, string> GetUniqueChars(string input)
        {
            Dictionary<char, string> uniqueChars = new Dictionary<char, string>();

            foreach (char c in input)
            {
                if (!uniqueChars.ContainsKey(c))
                {
                    uniqueChars.Add(c, "");
                }
            }

            return uniqueChars;
        }
        #endregion

        #endregion

        #region Lab4 КОМАНДЫ

        public ICommand GetRegularEuclidCommand { get; }
        private bool CanORegularEuclidCommand(object p)
        {
            if (InputA > 0 && _inputB > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnRegularEuclidCommand(object p)
        {
            RegularEuclid regularEuclid = new RegularEuclid();
            (int nod, Stopwatch time) = regularEuclid.CalculeteRegularEuclid(InputA, InputB);

            EuclidEntity euclidEntity = new EuclidEntity(InputA, InputB, nod, time, 1);
            Euclids.Add(euclidEntity);
            
        }


        public ICommand GetExtendedEuclidFirstCommand { get; }
        private bool CanOExtendedEuclidFirstCommand(object p)
        {
            if (InputA > 0 && _inputB > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnExtendedEuclidFirstCommand(object p)
        {
            ExtendedEuclidFirst extendedEuclidFirst = new ExtendedEuclidFirst();
            (int nod, Stopwatch time) = extendedEuclidFirst.CalculeteExtendedEuclidFirst(InputA, InputB);

            EuclidEntity euclidEntity = new EuclidEntity(InputA, InputB, nod, time, 2);
            Euclids.Add(euclidEntity);

        }


        public ICommand GetExtendedEuclidSecondCommand { get; }
        private bool CanOExtendedEuclidSecondCommand(object p)
        {
            if (InputA > 0 && _inputB > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnExtendedEuclidSecondCommand(object p)
        {
            ExtendedEuclidSecond extendedEuclidSecond = new ExtendedEuclidSecond();
            (int nod, Stopwatch time) = extendedEuclidSecond.CalculeteExtendedEuclidFirst(InputA, InputB);

            EuclidEntity euclidEntity = new EuclidEntity(InputA, InputB, nod, time, 2);
            Euclids.Add(euclidEntity);

        }

        #endregion

        #region Lab5 КОМАНДЫ

        public ICommand GetLFSRCommand { get; }
        private bool CanOLFSRCommand(object p)
        {
            if (uint.TryParse(_inputTextLab5, out _inputValueLab5))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void OnLFSRCommand(object p)
        {
            FlowLFSR flowLFSR = new FlowLFSR(_inputValueLab5);
            LFSRResults = new ObservableCollection<LFSRResult>(flowLFSR.RunLFSR(100));
        }

        #endregion

        public MainVM()
        {
            GetCoderCommand = new LambdaCommand(OnCoderCommand, CanCoderCommand);
            GetDecoderCommand = new LambdaCommand(OnDecoderCommand, CanDecoderCommand);

            GetCoderLab2Command = new LambdaCommand(OnCoderLab2Command, CanCoderLab2Command);
            GetDecoderLab2Command = new LambdaCommand(OnDecoderLab2Command, CanDecoderLab2Command);

            GetOpenTextCommand = new LambdaCommand(OnOpenTextCommand, CanOpenTextCommand);
            GetDecryptCommand = new LambdaCommand(OnDecryptCommand, CanODecryptCommand);

            GetRegularEuclidCommand = new LambdaCommand(OnRegularEuclidCommand, CanORegularEuclidCommand);
            GetExtendedEuclidFirstCommand = new LambdaCommand(OnExtendedEuclidFirstCommand, CanOExtendedEuclidFirstCommand);
            GetExtendedEuclidSecondCommand = new LambdaCommand(OnExtendedEuclidSecondCommand, CanOExtendedEuclidSecondCommand);

            GetLFSRCommand = new LambdaCommand(OnLFSRCommand, CanOLFSRCommand);
        }
    }
}
