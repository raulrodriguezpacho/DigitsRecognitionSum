using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DigitsRecognitionSum.Services;

namespace DigitsRecognitionSum.Droid.Services
{
    public class FileSystemService : IFileSystemService
    {
        public void LoadImageFile(string tag)
        {
            try
            {                
                var imageFilePath = Android.OS.Environment.ExternalStorageDirectory + "/DCIM/drs_" + tag + ".jpg";
                if (File.Exists(imageFilePath))
                {
                    var imageFile = new Java.IO.File(imageFilePath);
                    Bitmap bitmap = BitmapFactory.DecodeFile(imageFile.AbsolutePath);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}