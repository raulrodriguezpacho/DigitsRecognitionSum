using DigitsRecognitionSum.Services;
using Xamarin.Forms;
using Plugin.CurrentActivity;

namespace DigitsRecognitionSum.Droid.Services
{
    public class DeviceService : IDeviceService
    {
        public Size GetDeviceSize()
        {
            var context = Forms.Context;
            return new Size()
            {
                Width = context.Resources.DisplayMetrics.WidthPixels / context.Resources.DisplayMetrics.Density,
                Height = context.Resources.DisplayMetrics.HeightPixels / context.Resources.DisplayMetrics.Density
            };
        }
    }
}