using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionSalesCalc
{
    public static class SalesCommission
    {
        public static decimal percent_of_quota(decimal Sales, decimal Quota)
        {
            if (Sales < 0m)
            {
                throw new ArgumentOutOfRangeException("Sales Revenue cannot be negative.");
            }
            if (Quota <= 0m)
            {
                throw new ArgumentOutOfRangeException("Sales Quota must be greater than zero.");
            }
            return Sales / Quota * 100m;
        }
        public static decimal rate(decimal percent_of_quota)
        {
            decimal rate;
            if (percent_of_quota < 95m)
            {
                rate = 0m;
            }
            else if (percent_of_quota < 100m)
            {
                rate = 3m;
            }
            else if (percent_of_quota < 120m)
            {
                rate = (6m + 0.25m * (percent_of_quota - 100));
            }
            else if (percent_of_quota < 150m)
            {
                rate = (11m + 0.35m * (percent_of_quota - 120));
            }
            else
            {
                rate = (21.5m + 0.45m * (percent_of_quota - 150));
            }
            return Math.Round(rate, 2);
        }
    }
}
