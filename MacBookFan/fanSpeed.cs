using System.Diagnostics;

namespace MacBookFan;

public class fanSpeed
{
    public List<int> getFanSpeed()
    {
        var Fans = getFans();
        List<int> speedPercents = new List<int>();
        foreach (var fan in Fans)
        {
            int range = fan.max_speed - fan.min_speed;
            int percent = (int)Math.Round((decimal) (range / fan.current_speed * 100));
            speedPercents.Add(percent);
        }

        return speedPercents;
    }

    public List<Fan> getFans()
    {
        string baseDir = "/sys/devices/platform/applesmc.768/";
        var Files = Directory.GetFiles(baseDir);
        List<string> fanBlacklist = new List<string>();
        List<Fan> fans = new List<Fan>();
        foreach (var file in Files)
        {
            Console.WriteLine($"Considering {file}");
            string fi = Path.GetFileName(file);
            if (fi.StartsWith("fan"))
            {
                string fanNumber = fi[3].ToString();
                if (!fanBlacklist.Contains(fanNumber))
                {
                    Console.WriteLine($"Reading {file}");
                    Fan fan = new Fan()
                    {
                        current_speed = int.Parse(File.ReadAllText($"{baseDir}/fan{fanNumber}_output")),
                        max_speed = int.Parse(File.ReadAllText($"{baseDir}/fan{fanNumber}_max")),
                        min_speed = int.Parse(File.ReadAllText($"{baseDir}/fan{fanNumber}_min"))
                    };
                    fanBlacklist.Add(fanNumber);
                }
            }
        }
        return fans;
    }
    public class Fan
    {
        public int min_speed;
        public int max_speed;
        public int current_speed;
    }

    public void setFanSpeed(int Percent)
    {
        //Set Fan Speed
        //"/sys/devices/platform/applesmc.768"
        
    }
}