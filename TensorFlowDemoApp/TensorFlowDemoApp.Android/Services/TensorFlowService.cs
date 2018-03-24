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

using Org.Tensorflow;
using Org.Tensorflow.Contrib.Android;

namespace TensorFlowDemoApp.Droid.Services
{
    public class TensorFlowService
    {
        TensorFlowService()
        {
            Graph graph = new Graph();
            Session session = new Session(graph);

            //TensorFlowInferenceInterface i = new TensorFlowInferenceInterface();
            //i.Feed();
            //i.Run();
            //i.Fetch();

        }
    }
}