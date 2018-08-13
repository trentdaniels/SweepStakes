using System;
namespace SweepStakes
{
    public interface ISweepstakesManager
    {
        void InsertSweepStakes(Sweepstakes sweepstakes);

        Sweepstakes GetSweepstakes();
    }
}
