using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ShoppingManagementApi.Interfaces;
using ShoppingManagementApi.Models;

namespace ShoppingManagementApi.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private List<Drink> drinks = new List<Drink>();
        private int _nextId = 1;

        public DrinkRepository()
        {
            Add(new Drink { Name = "Tomato soup", Quantity = 1 });
            Add(new Drink { Name = "Yo-yo", Quantity = 2 });
            Add(new Drink { Name = "Hammer", Quantity = 3 });
        }

        public IEnumerable<Drink> GetAll()
        {
            return drinks;
        }

        public Drink Get(int id)
        {
            return drinks.Find(p => p.ID == id);
        }

        public Drink Add(Drink item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.ID = _nextId++;

            drinks.Add(item);

            return item;
        }

        public void Remove(int id)
        {
            drinks.RemoveAll(p => p.ID == id);
        }

        public bool Update(Drink item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = drinks.FindIndex(p => p.ID == item.ID);

            if (index == -1)
            {
                return false;
            }

            drinks.RemoveAt(index);
            drinks.Add(item);

            return true;
        }
    }
}