using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesAPI.Application.ViewModels
{
    public class SalesConsolidateReportViewModel
    {
        public string ProductId { get; set; }
        public double TotalValue { get; set; }
        public int TotalProductSold { get; set; }
    }
}
