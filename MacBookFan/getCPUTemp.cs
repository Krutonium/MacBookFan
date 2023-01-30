namespace MacBookFan;

public class getCPUTemp
{
    public List<int> getCoreTemps()
    {
        //Read all temperatures
        List<int> Temperatures = new List<int>();
        string[] files = Directory.GetFiles("/sys/devices/platform/coretemp.0/hwmon/", "*input", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            Console.WriteLine(file);
            int temp = Int32.Parse(File.ReadAllText(file)) / 1000;
            Temperatures.Add(temp);
        }
        return Temperatures;
    }
}