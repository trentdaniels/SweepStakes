using System;
namespace SweepStakes
{
    public class MarketingFirm
    {
        // Member Variables
        ISweepstakesManager manager;

        // Constructor
        public MarketingFirm()
        {
            manager = UserInterface.GetManager();
            UserInterface.DisplayManagerMenu(manager);
        }

        // Methods

    }
}
