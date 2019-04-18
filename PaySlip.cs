using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    class PaySlip
    {
        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        private int month;
        private int year;

        enum MonthsOfYear
        {
            JAN = 1, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff item in myStaff)
            {
                path = item.NameOfStaff + ".txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("================");
                    sw.WriteLine("PAYSLIP {0} {1}", month, year);
                    sw.WriteLine("==============");
                    sw.WriteLine("Name Of Staff: " + item.NameOfStaff);
                    sw.WriteLine("Hours Worked: " + item.HoursWorked);
                    sw.WriteLine("Basic Pay: {0:C}", item.BasicPay);

                    if (item.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {0:C}", ((Manager)item).Allowance);
                    else if (item.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime: {0:C}", ((Admin)item).Overtime);
                    sw.WriteLine("================");
                    sw.WriteLine("Total Pay: " + item.TotalPay);
                    sw.WriteLine("================");

                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> staff)
        {
            var result = from st in staff
                         where (st.HoursWorked < 10)
                         orderby st.NameOfStaff ascending
                         select new { st.NameOfStaff, st.HoursWorked };

            string path = "summary.txt";

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff working less than 10 hours in last month\n");
                foreach (Staff item in staff)
                {
                    Console.WriteLine("Name of Staff {0}", item.NameOfStaff);
                    Console.WriteLine("Hours worked {0}", item.HoursWorked);
                }
                sw.Close();
            }
        }

        public override string ToString()
        {
            return "Month = " + month + "year = " + year;
        }
    }
}
