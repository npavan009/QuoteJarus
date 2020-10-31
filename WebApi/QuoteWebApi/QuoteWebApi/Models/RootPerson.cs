using System.Collections.Generic;

namespace QuoteWebApi
{
    public class RootPerson
    {
        public List<Person> persons { get; set; }
    }

    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
    }
}
