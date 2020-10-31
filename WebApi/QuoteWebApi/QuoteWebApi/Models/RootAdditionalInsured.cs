using System.Collections.Generic;

namespace QuoteWebApi
{
    public class RootAdditionalInsured
    {
        public List<AdditionalInsured> AdditionalInsured { get; set; }
    }

    public class AdditionalInsured
    {
        public string Id { get; set; }
        public string QuoteId { get; set; }
        public string PersonId { get; set; }
        public string Coverage { get; set; }
    }
}
