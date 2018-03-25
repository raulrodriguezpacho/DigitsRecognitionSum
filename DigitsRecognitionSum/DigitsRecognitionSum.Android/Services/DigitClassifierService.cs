using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DigitsRecognitionSum.Services;

namespace DigitsRecognitionSum.Droid.Services
{
    public class DigitClassifierService : IDigitClassifierService
    {
        const string FILENAME = "mnist.frozen.pb";

        public bool IsModelAvalilable
        { 
            get
            {
                try
                {
                    return File.Exists(Android.OS.Environment.ExternalStorageDirectory + "/DCIM/" + FILENAME);                    
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

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

        bool Initialize()
        {
            bool ret = false;
            try
            {


            }
            catch { }
            return ret;
        }
    }
}