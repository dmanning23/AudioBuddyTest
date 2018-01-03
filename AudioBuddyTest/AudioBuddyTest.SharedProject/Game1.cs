using AudioBuddy;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AudioBuddyTest
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
#if !__IOS__ && !ANDROID
	public class Game1 : ControllerGame
#else
	public class Game1 : TouchGame
#endif
	{
		public Game1()
		{
			Graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;

			VirtualResolution = new Point(720, 1280);
			ScreenResolution = new Point(720, 1280);

			Fullscreen = false;
			Letterbox = false;
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

