using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;
        public string Name { get; }
        public string Type { get; }
        private List<Func> MissionList;
        
        /// <summary>
        ///     Constructor of a composed mission.
        /// </summary>
        /// <param name="name"></param> Title of the mission.
        public ComposedMission(String name)
        {
            // init the mission's details.
            Name = name;
            Type = "Composed";
            MissionList = new List<Func>();
        }

        /// <summary>
        ///     Add a new single mission to the composed mission.
        /// </summary>
        /// <param name="func"></param> The new function.
        /// <returns> A new ComposedMission for the ability of chaining composed missions. </returns>
        public ComposedMission Add(Func func)
        {
            MissionList.Add(func);
            return this;
        }

        /// <summary>
        ///     Calculates the value of the composed mission.
        /// </summary>
        /// <param name="value"></param> A value to assign in the expression.
        /// <returns> Result of calculation. </returns>
        public double Calculate(double value)
        {
            foreach (Func mission in MissionList)
            {
                value = mission(value);
            }
            // if there are signed delegates to the event, inform them that the calculation was performed.
            if (OnCalculate != null)
            {
                OnCalculate(this, value);
            }
            return value;
        }
    }
}
