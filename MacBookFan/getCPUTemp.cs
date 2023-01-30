namespace MacBookFan;

public class getCPUTemp
{
    public List<int> getCoreTemps()
    {
        //Read all temperatures
        List<int> Temperatures = new List<int>();
        //string[] files = Directory.GetFiles("/sys/devices/platform/coretemp.0/hwmon/", "*input", SearchOption.AllDirectories);
        //Never completes

        List<string> files = new List<string>(); 
        List<string> Directories = new List<string>();
        Directories = Directory.GetDirectories("/sys/devices/platform/coretemp.0/hwmon/").ToList();
        foreach (var d in Directories)
        {
            foreach (var f in Directory.GetFiles(d))
            {
                if (f.EndsWith("_input"))
                {
                    files.Add(f);
                }
            }
        }
        
        foreach (var file in files)
        {
            Console.WriteLine(file);
            int temp = Int32.Parse(File.ReadAllText(file)) / 1000;
            Temperatures.Add(temp);
        }
        return Temperatures;
    }
}