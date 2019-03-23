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
        // Use a dictionary as a data structure. 
        private Dictionary<string, Func> FuncMap;
        
        /// <summary>
        ///     Constructor of function container.
        /// </summary>
        public FunctionsContainer()
        {
            FuncMap = new Dictionary<string, Func>();
        }
        
        /// <summary>
        ///     Returns a list of the function titles of the mission.
        /// </summary>
        /// <returns></returns>
        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach(var item in FuncMap.Keys)
            {
                missions.Add(item);
            }
            return missions;
        }
        
        /// <summary>
        ///     Override [] for the ability of accessing/changing elements in the dictionary with it.
        /// </summary>
        /// <param name="FuncName"></param> Adds a new element to the dictionary:
        ///                                 FuncMap[FuncName] = Func.
        ///                                 Also returns Func given FuncMap[funcName].
        public Func this[string FuncName]
        {
            // Returns Func given FuncMap[FuncName].
            get
            {
                //  If the key doesn't exist in the dictionary, add it as the Id function.
                if (!FuncMap.ContainsKey(FuncName))
                {
                    FuncMap[FuncName] = val => val;
                }
                // Return the function that matches the given title.
                return FuncMap[FuncName]; 
            }
            // FuncMap[FuncName] = Func.
            set
            {
                FuncMap[FuncName] = value;
            }
        }
    }
}
