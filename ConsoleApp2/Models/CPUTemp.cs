using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Assignment02
{

    /// <summary>
    /// A public list that allows users to take their own computer's temperature. 
    /// This does not output anythingn to the console, but instead just generates the current temperature when activated.
    /// It does also turn it into a useable Celius measurement.
    /// 
    /// Unfortunately, it is non-fuctional due ti a permission error.
    /// 
    /// Parts of code taken from Lasse Rasch and JYelton, 2010, 2015, at 
    /// https://stackoverflow.com/questions/1195112/how-to-get-cpu-temperature
    /// </summary>

    public class CPUTemp
    {

        public double CurrentValue { get; set; }
        public string RequestedName { get; set; }

        public static List<CPUTemp> Temperatures
        {
            get
            {
                List<CPUTemp> result = new List<CPUTemp>();

                ManagementObjectSearcher gettingTemp = new ManagementObjectSearcher(@"root\WMI", "SELECT * FROM MSAcpi_ThermalZoneTemperature");
                foreach (ManagementObject obj in gettingTemp.Get())
                {
                    Double temp = Convert.ToDouble(obj["CurrentTemperature"].ToString());
                    temp = (temp - 2732) / 10.0;

                    result.Add(new CPUTemp { CurrentValue = temp, InstanceName = obj["InstanceName"].ToString() });
                }
                return result;
            }
        }
    }
}
