using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DigitsRecognitionSum.Renderers
{
    public class PaintRendererView : View
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
