using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DigitsRecognitionSum.Services;
using Org.Tensorflow;
using Org.Tensorflow.Contrib.Android;
using Org.Tensorflow.Types;
using Plugin.CurrentActivity;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Droid.Services
{
    public class DigitClassifierService : IDigitClassifierService
    {        
        const string FILENAME = "mnist_model_graph.pb";
        const string INPUT_NAME = "input";
        const string OUTPUT_NAME = "output";     
        const int INPUT_SIZE = 28;
        const float THRESHOLD = 0.1f;
        const int MAX_RESULTS = 3;

        private static int? _numClasses = 0;

        private static volatile TensorFlowInferenceInterface _inferenceInterface;
        private static object syncRoot = new Object();        
        public static TensorFlowInferenceInterface InferenceInterface
        {
            get
            {
                if (_inferenceInterface == null)
                {
                    lock (syncRoot)
                    {
                        if (_inferenceInterface == null)
                            _inferenceInterface = new TensorFlowInferenceInterface(Forms.Context.Assets, FILENAME);
                    }
                }
                return _inferenceInterface;
            }
        }

        public bool IsModelAvalilable
        { 
            get
            {
                try
                {
                    //return File.Exists(Android.OS.Environment.ExternalStorageDirectory + "/DCIM/" + FILENAME);                    
                    return (Forms.Context.Assets.List("").FirstOrDefault(a => a.StartsWith("mnist")) != null);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public async Task<int> RecognizeDigit(string imageFilePath)
        {                        
            return await Task.Run(() => Recognize(imageFilePath));
        }

        int Recognize(string imageFilePath)
        {
            int result = 0;            
            try
            {                
                var imageFile = new Java.IO.File(Android.OS.Environment.ExternalStorageDirectory + imageFilePath);
                Bitmap bitmap = BitmapFactory.DecodeFile(imageFile.AbsolutePath);
                var info = bitmap.GetBitmapInfo();
                var pixels = new int[info.Width * info.Height];
                bitmap.GetPixels(pixels, 0, (int)info.Width, 0, 0, (int)info.Width, (int)info.Height);
                float[] pixelsT = new float[pixels.Length];
                for (int i = 0; i < pixels.Length; ++i)
                {                    
                    int pix = pixels[i];
                    int b = pix & 0xff;
                    pixelsT[i] = 0xff - b;
                }

                InferenceInterface.Feed(INPUT_NAME, pixelsT, new long[] { INPUT_SIZE * INPUT_SIZE });

                string[] outputNames = new string[] { OUTPUT_NAME };
                InferenceInterface.Run(outputNames, false);

                float[] outputs = new float[_numClasses.Value];
                InferenceInterface.Fetch(OUTPUT_NAME, outputs);
                
                result = Array.IndexOf(outputs, outputs.Max());
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public int? Initialize()
        {
            int? numClasses = null;
            try
            {
                var graph = InferenceInterface.Graph();
                var operation = graph?.Operation(OUTPUT_NAME);
                var output = operation?.Output(0);
                var shape = output?.Shape();
                _numClasses = numClasses = (int)shape?.Size(1);               
            }
            catch (Exception)
            {
                return null;
            }
            return numClasses;            
        }
    }   
}