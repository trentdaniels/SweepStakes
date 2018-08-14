using System;
namespace SweepStakes
{
    public class MarketingFirm
    {
        // Member Variables
        ISweepstakesManager manager;

        // Constructor
        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
            UserInterface.DisplayManagerMenu(manager);
        }

        // Methods

    }
}
