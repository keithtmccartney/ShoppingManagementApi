using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingManagementApi.Models;

namespace ShoppingManagementApi.Interfaces
{
    interface IDrinkRepository
    {
        IEnumerable<Drink> GetAll();

        Drink Get(int id);
        Drink Add(Drink item);

        void Remove(int id);

        bool Update(Drink item);
    }
}