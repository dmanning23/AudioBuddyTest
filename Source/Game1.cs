using AudioBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AudioBuddyTest
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : ControllerGame
	{
		public Game1()
		{
		}

		protected override void Initialize()
		{
			AudioManager.Initialize(this);

			base.Initialize();
		}

		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new MainMenuScreen() };
		}
	}
}

