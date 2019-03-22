using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double Func(double val);

    public class FunctionsContainer
    {
        private Dictionary<string, Func> FuncMap;
        
        public FunctionsContainer()
        {
            // use a dictionary as a data structure. 
            FuncMap = new Dictionary<string, Func>();
        }

        public Func this[string funcName]
        {
            get
            {
                if (!FuncMap.ContainsKey(funcName))
                {
                    FuncMap[funcName] = val => val;
                }
                return FuncMap[funcName];
                
            }
            set
            {
                FuncMap[funcName] = value;
            }
        }
        
        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach(var item in FuncMap.Keys)
            {
                missions.Add(item);
            }
            return missions;
        }
    }
}
