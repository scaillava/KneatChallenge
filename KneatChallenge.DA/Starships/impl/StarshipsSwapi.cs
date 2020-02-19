using KneatChallenge.DA.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KneatChallenge.DA.Starships.impl
{
    public class StarshipsSwapi : StarshipsApiConsumer
    {
        public StarshipsSwapi(string apiURI) : base(apiURI)
        {

        }

        public override List<Models.Starship> GetStarships()
        {
            try
            {
                List<Models.Starship> starshipsResults = new List<Models.Starship>();
                JObject starshipObject = null;
                string uri = apiURI;
                do
                {
                    var t = Task.Run(() => HttpUtils.GetURI(new Uri(uri)));
                    t.Wait();
                    starshipObject = JObject.Parse(t.Result);
                    // get JSON result objects into a list
                    List<JToken> results = starshipObject["results"].Children().ToList();

                    // serialize JSON results into .NET objects
                    foreach (JToken result in results)
                    {
                        // JToken.ToObject is a helper method that uses JsonSerializer internally
                        Models.Starship searchResult = result.ToObject<Models.Starship>();
                        starshipsResults.Add(searchResult);
                    }
                    uri = (string)starshipObject["next"];
                }
                while (uri != null);

                return starshipsResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override Models.Starship GetStarship(string id)
        {
            throw new NotImplementedException();
        }

    }
}
