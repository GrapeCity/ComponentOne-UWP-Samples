using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlexChartMvvmDemo.Model;

namespace FlexChartMvvmDemo.Services
{
    public interface IOrderService
    {
        void FetchOrders(IList<OrderModel> list);
    }
}
