using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsControl.Droid
{
    [Activity(Label = "SplashActivity",
        Theme ="@style/SplashTheme",
        Icon = "@mipmap/icon",
        MainLauncher =true,
        NoHistory = true,
        ConfigurationChanges = 
    ConfigChanges.ScreenSize | ConfigChanges.Orientation | 
    ConfigChanges.UiMode | ConfigChanges.ScreenLayout | 
    ConfigChanges.SmallestScreenSize)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            OverridePendingTransition(0, 0);
        }
    }
}