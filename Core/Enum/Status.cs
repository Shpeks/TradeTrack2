using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enum
{
    public enum OrderStatus
    {
        Waiting = 1,     // Заказ в ожидании
        InProgress = 2,  // Заказ в обработке
        Completed = 3    // Заказ завершен
    }
}
