using System;

namespace MacBookFan // Note: actual namespace depends on the project name.
{
    
    // Useful References:
    // https://github.com/davidfoxcroft/mbpfan/blob/master/src/mbpfan.c
    internal class Program
    {
        static void Main(string[] args)
        {
            // Goals:
            // Disable BD_PROCHOT
            // Manually control CPU speed based on temperature
            // Keep CPU speed as high as possible, at the expense of Power and Noise
            // Only throttle if temps > 90 and fans == 100.

            BD_PROCHOT prochot = new BD_PROCHOT();
            CPUSpeed cpuSpeed = new CPUSpeed();
            fanSpeed fanSpeed = new fanSpeed();
            getCPUTemp cpuTemp = new getCPUTemp();
            prochot.Disable_ProcHot();
            //Now we loop
            bool loop = true;
            while (loop)
            {
                //Check Temperature
                //Adjust fan speed
                //If fan speed > 95% (of max)
                //start slowing down the CPU in... 100Mhz increments? Not sure yet.
                var temp = cpuTemp.getCoreTemps();
                foreach (var i in temp)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Looped");
                loop = false;
            }
        }
    }
}