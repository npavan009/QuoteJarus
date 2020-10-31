using System.Collections.Generic;

namespace QuoteWebApi
{
    public class RootQuotes
    {
        public List<Quote> quotes { get; set; }
    }
    public class Package
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsSelected { get; set; }
    }

    public class Quote
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Applicant { get; set; }
        public string QuoteDate { get; set; }
        public string EffectiveDate { get; set; }
        public List<Package> Package { get; set; }
        public List<string> Persons { get; set; }
    }

}
