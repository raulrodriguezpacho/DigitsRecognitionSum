using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognitionSum.Services
{
    public interface IDigitClassifierService
    {
        bool IsModelAvalilable { get; }
        int? Initialize();
        Task<int> RecognizeDigit(string imageFilePath);
    }
}
