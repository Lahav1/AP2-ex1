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
        
        public ComposedMission(String name)
        {
            // init the mission's details.
            Name = name;
            Type = "Composed";
            MissionList = new List<Func>();
        }

        public ComposedMission Add(Func func)
        {
            MissionList.Add(func);
            return this;
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            foreach (Func mission in MissionList)
            {
                value = mission(value);
            }
            if (OnCalculate != null)
            {
                OnCalculate(this, value);
            }
            return value;
        }
    }
}
