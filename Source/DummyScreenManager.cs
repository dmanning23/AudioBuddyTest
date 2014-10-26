using MenuBuddy;
using Microsoft.Xna.Framework;

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
				"MenuMove",
				"MenuSelect")
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

		#endregion //Methods
	}
}