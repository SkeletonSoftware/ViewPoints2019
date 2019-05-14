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
using ViewPoints.DependencyServices;
using ViewPoints.Droid.DependencyServices;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ToastImpl))]
namespace ViewPoints.Droid.DependencyServices
{
    internal class ToastImpl : IToast
    {
        public void ShowToast(string text, Length length)
        {
            Toast.MakeText(Application.Context, text, ConvertLength(length)).Show();
        }

        private ToastLength ConvertLength(Length length)
        {
            if (length == Length.Short)
            {
                return ToastLength.Short;
            }
            else
            {
                return ToastLength.Long;
            }
        }
    }
}