using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabProblem2.models
{

    public class calc
    {
        public double CalculateShippingCharges(double weight, double distance)
        {
            double ratePer500Miles = 0.0;

            if (weight <= 2)
            {
                ratePer500Miles = 1.10;
            }
            else if (weight <= 6)
            {
                ratePer500Miles = 2.20;
            }
            else if (weight <= 10)
            {
                ratePer500Miles = 3.70;
            }
            else
            {
                ratePer500Miles = 4.80;
            }

            // Calculate charges for distances greater than 500 miles
            double charges = 0.0;
            if (500 < distance & distance < 1000)
            {
                double extraDistance = 500;
                double extraCharges = (extraDistance / 500) * ratePer500Miles;
                charges = ratePer500Miles + extraCharges;
            }
            else
            {
                charges = ratePer500Miles; // Use the fixed rate for distances less than or equal to 500 miles
            }

            return charges;
        }
    }
}
