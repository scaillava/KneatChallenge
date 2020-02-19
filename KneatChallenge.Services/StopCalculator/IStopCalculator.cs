using System;
using System.Collections.Generic;
using System.Text;

namespace KneatChallenge.Services.StopCalculator
{
    public interface IStopCalculator
    {
        int getAmountStopRequired(Models.Starship starships, long distance);
    }
}
