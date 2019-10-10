using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Employee
    {
        public const double MAX_HOURLY_RATE = 100;
        public const double MAX_HOURS = 80;
        public const double MIN_HOURLY_RATE = 7.45;
        private const double OT_HOURS_AFTER = 40;
        private const double OT_MULTIPLIER = 1.5;
        private string pfvFirstName;
        private double pfvHourlyRate;
        private string pfvLastName;

        public string FirstName
        {
            get
            {
                return pfvFirstName;
            }
            set
            {
                pfvFirstName = value;
            }
        }

        public double HourlyRate
        {
            get
            {
                return pfvHourlyRate;
            }
            set
            {
                if (value > MIN_HOURLY_RATE && value < MAX_HOURLY_RATE)
                {
                    pfvHourlyRate = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return pfvLastName;
            }
            set
            {
                pfvLastName = value;
            }
        }

        public double CalcPay(double hours)
        {
            double pay = hours * pfvHourlyRate;

            if (hours > OT_HOURS_AFTER)
                pay = (pfvHourlyRate * OT_HOURS_AFTER) + (hours-OT_HOURS_AFTER) * OT_MULTIPLIER * pfvHourlyRate;

            return pay;
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
