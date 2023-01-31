using System.Diagnostics;

namespace MacBookFan;

public class getCPUTemp
{
    public List<int> getCoreTemps()
    {
        List<int> Temperatures = new List<int>();
        List<string> files = new List<string>(); 
        List<string> Directories = new List<string>();
        Directories = Directory.GetDirectories("/sys/devices/platform/coretemp.0/hwmon/").ToList();
        foreach (var d in Directories)
        {
            foreach (var f in Directory.GetFiles(d))
            {
                Debug.WriteLine($"Considering {f}");
                if (f.EndsWith("_input"))
                {
                    files.Add(f);
                    Debug.WriteLine($"Reading {f}");
                }
            }
        }
        foreach (var file in files)
        {
            Debug.WriteLine(file);
            int temp = Int32.Parse(File.ReadAllText(file)) / 1000;
            Temperatures.Add(temp);
        }
        return Temperatures;
    }
}