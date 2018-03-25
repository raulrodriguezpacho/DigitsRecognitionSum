using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DigitsRecognitionSum.Services;

namespace DigitsRecognitionSum.Droid.Services
{
    public class DigitClassifierService : IDigitClassifierService
    {
        public async Task<int> Classify(string imageFile)
        {            
            await Task.Delay(2000);
            return await Task.Run(() => C());
        }

        int C()
        {
            Random r = new Random();
            return r.Next(0, 9);
        }
    }
}