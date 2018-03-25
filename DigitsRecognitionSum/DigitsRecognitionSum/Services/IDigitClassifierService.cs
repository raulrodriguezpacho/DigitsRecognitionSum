using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognitionSum.Services
{
    public interface IDigitClassifierService
    {
        Task<int> Classify(string imageFile);
    }
}
