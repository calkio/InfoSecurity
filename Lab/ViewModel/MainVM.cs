using Caesar;
using Cryptanalysis.DataAccessAlphabet.Calculete;
using Lab.Infastructure;
using Lab.ViewModel.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

        #region Lab 1

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

        #region Lab2

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



        public MainVM()
        {
            GetCoderCommand = new LambdaCommand(OnCoderCommand, CanCoderCommand);
            GetDecoderCommand = new LambdaCommand(OnDecoderCommand, CanDecoderCommand);
            GetCoderLab2Command = new LambdaCommand(OnCoderLab2Command, CanCoderLab2Command);
            GetDecoderLab2Command = new LambdaCommand(OnDecoderLab2Command, CanDecoderLab2Command);
        }
    }
}
