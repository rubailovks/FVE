using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVE.Domain.Models.OrderModel
{
    public enum OrderType
    {
        /// <summary>
        /// Интернет-заказ.
        /// </summary>
        Online = 1,

        /// <summary>
        /// Резерв в магазине (отложенный товар).
        /// </summary>
        Reservation = 2,

        /// <summary>
        /// ЭПС - электронный платежный сертификат
        /// </summary>
        EPC = 3
    }
}
