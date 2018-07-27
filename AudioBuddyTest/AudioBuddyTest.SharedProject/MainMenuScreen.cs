using AudioBuddy;
using FilenameBuddy;
using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AudioBuddyTest
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	internal class MainMenuScreen : MenuScreen, IMainMenu
	{
		#region Properties

		List<Filename> Music;

		List<Filename> SoundFx;

		#endregion //Properties

		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen()
			: base("Main Menu")
		{
		}

		public override void LoadContent()
		{
			base.LoadContent();

			//initialize all the sound data
			Music = new System.Collections.Generic.List<Filename>()
			{
				new Filename(@"Music\bathboard.mp3"),
				new Filename(@"Music\credit.mp3"),
				new Filename(@"Music\intro_loop.mp3"),
				new Filename(@"Music\KfCFortress.mp3"),
				new Filename(@"Music\pirate.mp3")
			};

			SoundFx = new System.Collections.Generic.List<Filename>()
			{
				new Filename(@"Content\SoundFX\pop.wav"),
				new Filename(@"Content\SoundFX\quack.wav"),
				new Filename(@"Content\SoundFX\squeak.wav")
			};

			// Create our menu entries.
			var menu = new MenuEntry("Sound Test", Content);
			menu.OnClick += SoundTestSelected;
			AddMenuEntry(menu);

			menu = new MenuEntry("Music Test", Content);
			menu.OnClick += MusicTestSelected;
			AddMenuEntry(menu);

			menu = new MenuEntry("Sound Fx Test", Content);
			menu.OnClick += SoundFxTestSelected;
			AddMenuEntry(menu);

			menu = new MenuEntry("Exit", Content);
			menu.OnClick += OnExit;
			AddMenuEntry(menu);
		}

		#endregion //Initialization

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void SoundTestSelected(object sender, ClickEventArgs e)
		{
			var screen = new SoundTestScreen();
			screen.AddMusic(Music);
			screen.AddSoundFx(SoundFx);
			ScreenManager.AddScreen(screen, null);
		}

		private void MusicTestSelected(object sender, ClickEventArgs e)
		{
			var screen = new MusicTestScreen();
			screen.AddMusic(Music);
			ScreenManager.AddScreen(screen, null);
		}

		private void SoundFxTestSelected(object sender, ClickEventArgs e)
		{
			var screen = new SoundFxTestScreen();
			screen.AddSoundFx(SoundFx);
			ScreenManager.AddScreen(screen, null);
		}

		public override void Cancelled(object obj, ClickEventArgs e)
		{
		}

		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected void OnExit(object sender, ClickEventArgs e)
		{
#if !__IOS__
			ScreenManager.Game.Exit();
#endif
		}

		#endregion
	}
}