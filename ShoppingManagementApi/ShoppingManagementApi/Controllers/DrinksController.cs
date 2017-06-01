using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ShoppingManagementApi.Interfaces;
using ShoppingManagementApi.Models;
using ShoppingManagementApi.Repositories;

namespace ShoppingManagementApi.Controllers
{
    public class DrinksController : ApiController
    {
        static readonly IDrinkRepository repository = new DrinkRepository();

        public IEnumerable<Drink> GetAllDrinks()
        {
            return repository.GetAll();
        }

        public Drink GetDrink(int id)
        {
            Drink item = repository.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        public IEnumerable<Drink> GetDrinksByName(string name)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostDrink(Drink item)
        {
            item = repository.Add(item);

            var response = Request.CreateResponse<Drink>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID });

            response.Headers.Location = new Uri(uri);

            return response;
        }

        public void PutDrink(int id, Drink drink)
        {
            drink.ID = id;

            if (!repository.Update(drink))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteDrink(int id)
        {
            Drink item = repository.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }
    }
}