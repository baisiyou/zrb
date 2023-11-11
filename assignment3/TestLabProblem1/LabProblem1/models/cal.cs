using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProblem1.models
{
    public class cal
    {
        public double CalculateServiceFees(double endingBalance, int numberOfChecks)
        {
            const double monthlyCharge = 10.0;
            double checkFee = 0.0;

            if (numberOfChecks < 20)
            {
                checkFee = numberOfChecks * 0.10;
            }
            else if (numberOfChecks >= 20 && numberOfChecks <= 39)
            {
                checkFee = numberOfChecks * 0.08;
            }
            else if (numberOfChecks >= 40 && numberOfChecks <= 59)
            {
                checkFee = numberOfChecks * 0.06;
            }
            else if (numberOfChecks >= 60)
            {
                checkFee = numberOfChecks * 0.10;
            }

            if (endingBalance < 400)
            {
                checkFee += 15.0;
            }

            return monthlyCharge + checkFee;
        }
    }
}
