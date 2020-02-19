using System.Collections.Generic;

namespace KneatChallenge.DA.Starships
{
    public abstract class StarshipsApiConsumer
    {
        protected string apiURI;
        public abstract List<Models.Starship> GetStarships();
        public abstract Models.Starship GetStarship(string id);

        protected StarshipsApiConsumer(string apiURI)
        {
            this.apiURI = apiURI;
        }
    }
}
