using MenuBuddy;
using System.Collections.Generic;
using AudioBuddy;
using Microsoft.Xna.Framework;

namespace AudioBuddyTest
{
	/// <summary>
	/// The main menu screen is the first thing displayed when the game starts up.
	/// </summary>
	internal class MainMenuScreen : MenuScreen, IMainMenu
	{
		#region Initialization

		/// <summary>
		/// Constructor fills in the menu contents.
		/// </summary>
		public MainMenuScreen() : base("Main Menu")
		{
			// Create our menu entries.
			var soundTest = new MenuEntry("Sound Test");
			var exitMenuEntry = new MenuEntry("Exit");

			// Hook up menu event handlers.
			soundTest.Selected += SoundTestSelected;
			exitMenuEntry.Selected += OnExit;

			// Add entries to the menu.
			MenuEntries.Add(soundTest);
			MenuEntries.Add(exitMenuEntry);
		}

		#endregion //Initialization

		#region Methods

		public override void LoadContent()
		{
		}

		#endregion //Methods

		#region Handle Input

		/// <summary>
		/// Event handler for when the High Scores menu entry is selected.
		/// </summary>
		private void SoundTestSelected(object sender, PlayerIndexEventArgs e)
		{
			var screen = new SoundTestScreen();
			screen.SoundFxCues.AddRange(new List<string>() { "pop", "quack", "squeak" });
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