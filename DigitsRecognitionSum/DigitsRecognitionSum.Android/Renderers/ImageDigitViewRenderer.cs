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
using DigitsRecognitionSum.Droid.Renderers;
using DigitsRecognitionSum.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageDigitRendererView), typeof(ImageDigitViewRenderer))]
namespace DigitsRecognitionSum.Droid.Renderers
{
    public class ImageDigitViewRenderer : ImageRenderer
    {
        private Context _context;

        public ImageDigitViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            var imageFilePath = Android.OS.Environment.ExternalStorageDirectory + "/DCIM/drs_" + ((ImageDigitRendererView)Element).DigitOrder + ".jpg";
            if (Control != null)
            {
                try
                {                    
                    if (File.Exists(imageFilePath))
                    {
                        var imageFile = new Java.IO.File(imageFilePath);
                        Bitmap bitmap = BitmapFactory.DecodeFile(imageFile.AbsolutePath);
                        Control.SetImageBitmap(bitmap);
                    }
                }
                catch (Exception ex)
                {

                }
            }                
        }
    }
}