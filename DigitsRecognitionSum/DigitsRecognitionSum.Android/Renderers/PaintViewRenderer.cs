using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DigitsRecognitionSum.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PaintRendererView), typeof(PaintViewRenderer))]
namespace DigitsRecognitionSum.Droid.Renderers
{
    public class PaintViewRenderer : ViewRenderer<PaintRendererView, PaintView>
    {
        private Context _context;
        private PaintView _paintView;        

        public PaintViewRenderer(Context context) : base(context)
        {
            _context = context;
            SetWillNotDraw(false);

            MessagingCenter.Subscribe<ViewModelBase, string>(this, "clear", (sender, args) =>
            {
                if (Control != null)
                    if (Control.Tag.ToString() == args)
                        Control.Clear();
            });
            MessagingCenter.Subscribe<ViewModelBase, string>(this, "save", (sender, args) =>
            {
                if (Control != null)
                    if (Control.Tag.ToString() == args)
                        Control.Save(args);
            });
        }

        protected override void OnElementChanged(ElementChangedEventArgs<PaintRendererView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            _paintView = new PaintView(_context);
            _paintView.Tag = Element.DigitOrder;
            SetNativeControl(_paintView);
            Tag = Element.DigitOrder;            
        }

        protected override void Dispose(bool disposing)
        {
            MessagingCenter.Unsubscribe<ViewModelBase, string>(this, "clear");
            MessagingCenter.Unsubscribe<ViewModelBase, string>(this, "save");
        }
    }
}