using System;

namespace SweepStakes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ISweepstakesManager manager = UserInterface.GetManager();
            MarketingFirm marketingFirm = new MarketingFirm(manager);
        }
    }
}
