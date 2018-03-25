using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using DigitsRecognitionSum.Services;

namespace DigitsRecognitionSum.Droid.Services
{
    public class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);            
            builder.RegisterType<DeviceService>().As<IDeviceService>();
            builder.RegisterType<FileSystemService>().As<IFileSystemService>();
            builder.RegisterType<DigitClassifierService>().As<IDigitClassifierService>();
        }
    }
}