using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ViewPoints.DependencyServices;
using ViewPoints.Droid.DependencyServices;
using Xamarin.Forms;
using Application = Android.App.Application;
using Environment = Android.OS.Environment;

[assembly: Dependency(typeof(PathHelper))]
namespace ViewPoints.Droid.DependencyServices
{
    /// <summary>
    /// Třída pro získání cest ke speciálním složkám na daném systému
    /// </summary>
    class PathHelper : IPathHelper
    {
        public string GetDocumentsDirectoryPath()
        {
            return Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDocuments).AbsolutePath;
        }
    }
}