using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Renderers
{
    public class ImageDigitRendererView : Image
    {
        public static readonly BindableProperty DigitOrderProperty =
            BindableProperty.Create("DigitOrder", typeof(string), typeof(PaintRendererView), string.Empty);

        public string DigitOrder
        {
            get { return (string)GetValue(DigitOrderProperty); }
            set { SetValue(DigitOrderProperty, value); }
        }
    }
}
