using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class Staff
    {
        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        private float hourlyRate;
        private int hworked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hworked;
            }
            set
            {
                if (value > 0)
                    hworked = value;
                else
                    hworked = 0;
            }
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hworked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override String ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nhourlyRate = " + hourlyRate +
                "\nhWorked = " + hworked
                + "\nBasicPay = " + BasicPay +
                "\n\nTotalPay = " + TotalPay;
        }
    }
}
