using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace QuoteWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        DataAccessLayer dl;

        public QuotesController()
        {
            dl = new DataAccessLayer();
        }

        /// <summary>
        /// Returns all the quotes 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Quote> GetQuotes()
        {
            RootQuotes root = dl.GetQuotesFromJsonFile();
            return root.quotes;
        }


        /// <summary>
        /// Return quote based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public Quote GetQuote(string id)
        {
            RootQuotes root = dl.GetQuotesFromJsonFile();
            Quote qt= root.quotes.FirstOrDefault(r => r.Id == id);
            return qt == null ? new Quote() : qt;
        }

        /// <summary>
        /// Return Search results
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search")]
        public List<Person> FindPeople([FromBody]Person person)
        {
            RootPerson personList = dl.GetDummyPersonData();
            List<Person> peoplelist= personList.persons.Where(r => (r.FirstName == person.FirstName) || (r.LastName == person.LastName)).ToList();
            return peoplelist;
        }

        /// <summary>
        /// Adds additional insured users
        /// </summary>
        /// <param name="additional"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AdditionalInsured")]
        public bool AddAdditionalInsured([FromBody] AdditionalInsured additional)
        {
           bool status=  dl.AddorDeleteAdditionalInsured(additional,true);
            return status;
        }


        /// <summary>
        /// Deletes additional user
        /// </summary>
        /// <param name="additional"></param>
        /// <returns></returns>
        [HttpDelete("DeleteInsured")]
        public bool Delete([FromBody] AdditionalInsured additional)
        {
            bool status = dl.AddorDeleteAdditionalInsured(additional, false);
            return status;
        }
    }
}
