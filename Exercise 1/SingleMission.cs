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

        /// <summary>
        ///     Constructor of SingleMission.
        /// </summary>
        /// <param name="func"></param> The function that will be added to the mission.
        /// <param name="name"></param> Title of the mission.
        public SingleMission(Func func, String name)
        {
            // init the mission's details.
            Name = name;
            Type = "Single";
            Function = func;
        }
            
        /// <summary>
        ///     Calculates the value of the single mission.
        /// </summary>
        /// <param name="value"></param> The value that will be assigned for calculation.
        /// <returns> Result of calculation. </returns>
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
