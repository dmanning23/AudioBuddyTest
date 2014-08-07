using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ouya.Console.Api;
using Microsoft.Xna.Framework;

namespace AudioBuddyTest
{
	[Activity (Label = "AudioBuddyTest", 
		MainLauncher = true,
		Icon = "@drawable/icon",
		Theme = "@style/Theme.Splash",
		AlwaysRetainTaskState=true,
		LaunchMode=LaunchMode.SingleInstance,
		ScreenOrientation = ScreenOrientation.SensorLandscape,
		ConfigurationChanges = ConfigChanges.Orientation | 
		ConfigChanges.KeyboardHidden | 
		ConfigChanges.Keyboard)]
	[IntentFilter(new[] { Intent.ActionMain }
		, Categories = new[] { Intent.CategoryLauncher, OuyaIntent.CategoryGame })]
	public class Activity1 : AndroidGameActivity
	{
		/// <summary>
		/// The developer ID.  Replace this with your own developer ID from ouya.tv
		/// </summary>
		public const string DEVELOPER_ID = "71ddc61e-7d54-4975-a2d0-dd157e01cb2e";

		/// <summary>
		/// The purchase facade.
		/// </summary>
		public static OuyaFacade PurchaseFacade = null;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create our OpenGL view, and display it
			var g = new Game1();
			SetContentView((View)g.Services.GetService(typeof(View)));
			g.Run();
		}
	}
}


