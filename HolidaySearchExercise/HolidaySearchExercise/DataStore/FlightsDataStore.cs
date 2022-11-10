using System.Reflection;
using HolidaySearchExercise.Models;
using System.Text.Json;

namespace HolidaySearchExercise.DataStore;

public class FlightsDataStore
{
    protected string resourceName = "HolidaySearchExercise.Resources.FlightDataJson.json"; 
    static FlightsDataStore instance;
    private List<Flight> flights;

    public FlightsDataStore()
    {
        var assembly = Assembly.GetExecutingAssembly();
        string jsonFile;
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            jsonFile = reader.ReadToEnd();
        }

        flights = JsonSerializer.Deserialize<List<Flight>>(jsonFile);
    }

    public List<Flight> GetFlightData() => flights;
}