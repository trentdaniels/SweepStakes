using System;
namespace SweepStakes
{
    public class MarketingFirm
    {
        // Member Variables
        private readonly ISweepstakesManager sweepstakesManager;

        // Constructor
        public MarketingFirm()
        {
            sweepstakesManager = UserInterface.GetManager();
        }

        // Methods

    }
}
