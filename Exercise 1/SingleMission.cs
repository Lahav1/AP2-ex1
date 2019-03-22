using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        private Func Function;
        public string Name { get; }
        public string Type { get; }

        public SingleMission(Func func, String name)
        {
            // init the mission's details.
            Name = name;
            Type = "Single";
            Function = func;
        }
            
        public double Calculate(double value)
        {
            double newValue = Function(value);
            if (OnCalculate != null)
            {
                OnCalculate(this, newValue);
            }
            return newValue;
        }
    }
}
