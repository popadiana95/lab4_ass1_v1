using Ass2_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass2_1.BL
{
    public class Orders
    {
        public string addProduct(Order order, Product product, int quantity, int idUser)
        {
            string message;
            if (product.stock > quantity)
            {
                message = "Produs adaugat la comanda";
                OrderDBManager odbm = new OrderDBManager();
                odbm.AddProductToOrder(order, product, quantity, idUser);
            }
            else
                message = "Stoc insuficient";
            return message;
        }
    }
}