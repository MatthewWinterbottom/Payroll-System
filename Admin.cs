using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class Admin : Staff
    {
        public Admin(string name) : base(name, adminHourlyRate)
        {

        }
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }

        public override void CalculatePay()
        {
            base.CalculatePay();

            if (HoursWorked > 160)
            {
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay += Overtime;
            }
                
        }

        public override String ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff +
                "\nadminHourlyRatee = " + adminHourlyRate +
                "\nOvertime = " + Overtime +
                "\nHoursWorked = " + HoursWorked
                + "\nBasicPay = " + BasicPay +
                "\n\nTotalPay = " + TotalPay;
        }
    }
}
