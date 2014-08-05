using MenuBuddy;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AudioBuddyTest
{
	public class DummyScreenManager : ScreenManager
	{
		#region Properties

		#endregion //Properties

		#region Methods

		/// <summary>
		/// Initializes a new instance of the <see cref="Filibuster.FilibusterScreenManager"/> class.
		/// </summary>
		/// <param name="game">Game.</param>
		public DummyScreenManager(Game game) 
			: base(game,
				"Fonts\\ArialBlack72",
				"Fonts\\ArialBlack48",
				"Fonts\\ArialBlack24",
				"menu move",
				"menu select")
		{
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override GameScreen[] GetMainMenuScreenStack()
		{
			return new GameScreen[] { new MainMenuScreen() };
		}

		public override void Initialize()
		{
			base.Initialize();
		}

		#endregion //Methods
	}
}