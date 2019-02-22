using System;
using System.Diagnostics;
using System.Timers;
using System.Management;

namespace Assignment02
{
    class Program
    {
        static Timer timer;


        static void Main(string[] args)
        {
            timer = new Timer()
            {
                Interval = 60000, //60 second intervals
                AutoReset = true, //Instructs the Timer to execute the event repeatedly
                Enabled = true //Enable the Timer
            };

            timer.Elapsed += Timer_Elapsed;

            Console.ReadKey();

        }



        ///<summary>
        /// This event activats when the timer passes a tick, writing out both GPS and CPU Temperatures and sending them to CSV files.
        ///</summary>

        private static void Timer_Elapsed(object source, ElapsedEventArgs e)
        {

            Console.WriteLine(CPUTemp.Temperatures);            
        }
    }
}
