using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    //izinler normalde arayüzde tanımlanır.
    public enum Permission
    {
        CreditCardGetAll = 1,
        CreditCardGetById,
        CreditCardPost,
        CreditCardGetPut,
        CreditCardDelete,

        HomeGetAll,
        HomePost,
        HomeGetPut,
        HomeDelete,

        BillGetAll,
        BillPost,
        BillGetPut,
        BillDelete,

        MessageGetAll,
        MessagePost,
        MessageDelete,
    }
}
