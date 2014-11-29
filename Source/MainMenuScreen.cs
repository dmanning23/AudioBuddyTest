using AudioBuddy;
using FilenameBuddy;
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
		public MainMenuScreen() : base("Main Menu")
		{
			// Create our menu entries.
			var menu = new MenuEntry("Sound Test");
			menu.Selected += SoundTestSelected;
			MenuEntries.Add(menu);

			menu = new MenuEntry("Music Test");
			menu.Selected += MusicTestSelected;
			MenuEntries.Add(menu);

			menu = new MenuEntry("Sound Fx Test");
			menu.Selected += SoundFxTestSelected;
			MenuEntries.Add(menu);

			menu = new MenuEntry("Exit");
			menu.Selected += OnExit;
			MenuEntries.Add(menu);
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
			Music = new System.Collections.Generic.List<Filename> ()
			{
				new Filename(@"Music\bathboard.mp3"),
				new Filename(@"Music\credit.mp3"),
				new Filename(@"Music\intro_loop.mp3"),
				new Filename(@"Music\KfCFortress.mp3"),
				new Filename(@"Music\pirate.mp3")
			};

			SoundFx = new System.Collections.Generic.List<Filename>()
			{
				new Filename(@"Sounds\pop.wav"),
				new Filename(@"Sounds\quack.wav"),
				new Filename(@"Sounds\squeak.wav")
			};
		}

		#endregion //Methods

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void SoundTestSelected(object sender, PlayerIndexEventArgs e)
		{
			var screen = new SoundTestScreen();
			screen.AddMusic(Music);
			screen.AddSoundFx(SoundFx);
			ScreenManager.AddScreen(screen, null);
		}

		private void MusicTestSelected(object sender, PlayerIndexEventArgs e)
		{
			var screen = new MusicTestScreen();
			screen.AddMusic(Music);
			ScreenManager.AddScreen(screen, null);
		}

		private void SoundFxTestSelected(object sender, PlayerIndexEventArgs e)
		{
			var screen = new SoundFxTestScreen();
			screen.AddSoundFx(SoundFx);
			ScreenManager.AddScreen(screen, null);
		}

		/// <summary>
		/// When the user cancels the main menu, ask if they want to exit the sample.
		/// </summary>
		protected void OnExit(object sender, PlayerIndexEventArgs e)
		{
			const string message = "Are you sure you want to exit?";
			var confirmExitMessageBox = new MessageBoxScreen(message);
			confirmExitMessageBox.Accepted += ConfirmExitMessageBoxAccepted;
			ScreenManager.AddScreen(confirmExitMessageBox, e.PlayerIndex);
		}

		/// <summary>
		/// Event handler for when the user selects ok on the "are you sure
		/// you want to exit" message box.
		/// </summary>
		private void ConfirmExitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
		{
			ScreenManager.Game.Exit();
		}

		/// <summary>
		/// Ignore the cancel message from the main menu
		/// </summary>
		protected override void OnCancel(PlayerIndex playerIndex)
		{
			//do nothing here!
		}

		#endregion
	}
}