using System;

namespace KneatChallenge.Services.StopCalculator.impl
{
    public class StopCalculatorImpl : IStopCalculator
    {
        public int getAmountStopRequired(Models.Starship starships, long distance)
        {


            try
            {
                return ((int)((distance) / (consumablesToHours(starships.consumables) * MGLTtoInt(starships.MGLT))));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public long consumablesToHours(string consumables)
        {
            string consumablesNotDefined = "The value of consumables is unndefined";
            if (consumables == "unndefined")
                throw new Exception(consumablesNotDefined);
            else
            {
                try
                {
                    string[] consumablesArray = consumables.Split(" ");
                    long amount = long.Parse(consumablesArray[0]);
                    string timeType = consumablesArray[1].ToLower();
                    //parsing the time's type to get hours
                    if (timeType.Contains("day"))
                    {
                        return amount * 24;
                    }
                    else if (timeType.Contains("week"))
                    {
                        return amount * 24 * 7;
                    }
                    else if (timeType.Contains("month"))
                    {
                        return amount * 24 * 30;
                    }
                    else if (timeType.Contains("year"))
                    {
                        return amount * 24 * 365;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    throw new Exception(consumablesNotDefined);
                }


            }
        }

        public long MGLTtoInt(string MGLT)
        {
            string MGLTNotDefined = "The value of MGLT is unndefined";
            if (MGLT == "unndefined")
                throw new Exception(MGLTNotDefined);
            else
            {
                try
                {
                    return long.Parse(MGLT);
                }
                catch (Exception)
                {
                    throw new Exception(MGLTNotDefined);
                }
            }
        }
    }
}
