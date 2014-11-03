using AudioBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ResolutionBuddy;
using TouchScreenBuddy;

namespace AudioBuddyTest
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private readonly DummyScreenManager _ScreenManager;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
			Resolution.Init(ref graphics);

#if ANDROID && !OUYA
            //create the touch manager component
            var touches = new TouchManager(this, Resolution.ScreenToGameCoord);
            Components.Add(touches);
#endif

			Content.RootDirectory = "Content";

			// Create the screen manager component.
			_ScreenManager = new DummyScreenManager(this);

			_ScreenManager.ClearColor = new Color(20, 128, 20);
			Components.Add(_ScreenManager);

			// Activate the first screens.
			_ScreenManager.AddScreen(_ScreenManager.GetMainMenuScreenStack(), null);
		}

		/// <summary>
		/// Get the upper right location for toast notifications
		/// </summary>
		/// <returns>The right.</returns>
		public Vector2 UpperRight()
		{
			return new Vector2(Resolution.TitleSafeArea.Right, Resolution.TitleSafeArea.Top);
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// Change Virtual Resolution
			Resolution.SetDesiredResolution(1280, 720);

			//set the desired resolution
			Resolution.SetScreenResolution(1280, 720, false);

			//setup the audio stuff
			AudioManager.Initialize(this);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//use this.Content to load your game content here 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Allows the game to exit
			if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
				Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
				this.Exit();
			}

			//Add your update logic here

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			// Clear to Black
			graphics.GraphicsDevice.Clear(_ScreenManager.ClearColor);

			// Calculate Proper Viewport according to Aspect Ratio
			Resolution.ResetViewport();

			// The real drawing happens inside the screen manager component.
			base.Draw(gameTime);
		}
	}
}

