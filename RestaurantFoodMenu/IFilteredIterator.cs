using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.FoodMenu;

namespace FoodDeliveryApp.RestaurantFoodMenu
{
    public interface IFilteredIterator : IIterator
    {
        void SetFilter(Func<FoodMenuModel, bool> filterCriteria);
    }
}
