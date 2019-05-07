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
using Environment = System.Environment;

[assembly: Dependency(typeof(Settings))]
namespace ViewPoints.Droid.DependencyServices
{
    /// <summary>
    /// Třída pro ukládání hodnot do paměti zařízení
    /// </summary>
    class Settings : ISettings
    {
        #region String

        /// <summary>
        /// Uloží hodnotu do paměti zařízení. Hodnota je tedy dostupná i po vypnutí a zapnutí aplikace
        /// </summary>
        /// <param name="value">Hodnota, kterou chcete uložit</param>
        /// <param name="key">Klíč k hodnotě</param>
        public override void SetVariable(string value, string key)
        {
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            ISharedPreferencesEditor settings = preferences.Edit();
            settings.PutString(key, value);
            settings.Apply();
            preferences.Dispose();
        }

        /// <summary>
        /// Vrátí hodnotu, kterou jste si předtím uložili do paměti zařízení. Pokud hodnota se zadaným klíčem v paměti není, vrátí defaultValue
        /// </summary>
        /// <param name="key">Klíč k hodnotě</param>
        /// <param name="defaultValue">Hodnota, která má být vrácena, pokud nebude zadaný klíč nalezen</param>
        /// <returns>Hodnota patřící k zadanému klíči</returns>
        public override string GetVariable(string key, string defaultValue)
        {
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);
            string output;
            try
            {
                output = preferences.GetString(key, defaultValue);
            }
            catch (ArgumentException)
            {
                output = defaultValue;
            }
            finally
            {
                preferences.Dispose();
            }

            return output;
        }

        #endregion
    }
}