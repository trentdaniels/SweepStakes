using System;
namespace SweepStakes
{
    public interface ISweepstakesManager
    {
        void InsertSweepstakes(Sweepstakes sweepstakes);

        Sweepstakes GetSweepstakes();

    }
}
