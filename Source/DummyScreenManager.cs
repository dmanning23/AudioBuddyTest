using MenuBuddy;
using ToastBuddyLib;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using TrialModeBuddy;
using Microsoft.Xna.Framework;
using OuyaTimeTrialBuddy;
using System.Collections.Generic;
using OuyaPurchaseHelper;
#if OUYA
using Ouya.Console.Api;
#endif

namespace RoboJets
{
	public class DummyScreenManager : TimeTrialScreenManager
	{
		#region Properties

		/// <summary>
		/// whether or not the player has purchased the game
		/// </summary>
		private ReceiptBreadCrumb Receipt { get; set; }

		#endregion //Properties

		#region Methods

		/// <summary>
		/// Initializes a new instance of the <see cref="Filibuster.FilibusterScreenManager"/> class.
		/// </summary>
		/// <param name="game">Game.</param>
#if OUYA
		public DummyScreenManager(Game game, IList<Purchasable> purchasables, OuyaFacade purchaseFacade) 
#else
		public DummyScreenManager(Game game) 
#endif
			: base(game,
				"Fonts\\ArialBlack72",
				"Fonts\\ArialBlack48",
				"Fonts\\ArialBlack24",
				"menu move",
				#if OUYA
				"menu select", purchasables, purchaseFacade)
				#else
				"menu select")
				#endif
		{
			Receipt = new ReceiptBreadCrumb("RoboJets", "RoboJetsReceipt.xml");
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override GameScreen[] GetMainMenuScreenStack()
		{
			//return new GameScreen[] { new DebugScreen() };
			return new GameScreen[] { new BackgroundScreen(), new MainMenuScreen() };
		}

		public override void Initialize()
		{
			//Read in the receipt bread crumb
			Receipt.Initialize(Game);
			Receipt.Load();

			//What was the result of that?
			if (Receipt.Purchased)
			{
				Guide.IsTrialMode = false;
			}

			Debug.WriteLine(string.Format("Purchase history loaded, and the result was: {0}", Receipt.Purchased.ToString()));

			base.Initialize();
		}

		/// <summary>
		/// User selected an item to try and buy the full game
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public override void PurchaseFullVersion(object sender, PlayerIndexEventArgs e)
		{
			//Check if it has checked receipts yet
			#if OUYA
			if (!buddy.ReceiptsChecked)
			{
				//Popup a toast notification that it is still checking the receipts
				IServiceProvider services = Game.Services;
				IMessageDisplay messageDisplay = (IMessageDisplay)services.GetService(typeof(IMessageDisplay));
				messageDisplay.ShowMessage("Still checking receipts, please try again in a moment");
			}
			else
			{
				base.PurchaseFullVersion(sender, e);
			}
			#else
			base.PurchaseFullVersion(sender, e);
			#endif
		}

		/// <summary>
		/// Sets the trial mode flag.
		/// </summary>
		/// <param name="IsTrialMode">If set to <c>true</c> is trial mode.</param>
		public override void SetTrialMode(bool bIsTrialMode)
		{
			//save the result out to the receipt file
			Receipt.Purchased = !bIsTrialMode;
			Receipt.Save();

			base.SetTrialMode(bIsTrialMode);
		}

		#endregion //Methods
	}
}