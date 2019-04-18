using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class Manager : Staff
    {
        public Manager(string name) : base(name, managerHourlyRate)
        {

        }

        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay += Allowance;
        }

        public override String ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff
                + "\nAllowance = " + Allowance +
                "\nmanagerHourlyRate = " + managerHourlyRate +
                "\nHoursWorked = " + HoursWorked
                + "\nBasicPay = " + BasicPay +
                "\n\nTotalPay = " + TotalPay;
        }
    }
}
