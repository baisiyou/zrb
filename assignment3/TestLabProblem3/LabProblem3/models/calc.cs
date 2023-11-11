using LabProblem3.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LabProblem3.models
{
    public class calc
    {
        public int CalculatePopulation(int population, double rate, int days)
        {
            int Populations = population;
            for (int i = 1; i <= days; i++)
            {
                double increasePopulation = (Populations * rate / 100);
                Populations = (int)(Populations + increasePopulation);
                MessageBox.Show("Day no" + i + "&predicted population:" + Populations);

            }
            return Populations;
        }
    }
}
