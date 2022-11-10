using System.Reflection;
using HolidaySearchExercise.Models;
using System.Text.Json;

namespace HolidaySearchExercise.DataStore;

public class HotelDataStore : IHotelDataStore 
{
    protected string resourceName = "HolidaySearchExercise.Resources.HotelDataJson.json"; 
    private List<Hotel> hotels;

    public HotelDataStore()
    {
        var assembly = Assembly.GetExecutingAssembly();
        string jsonFile;
        using (Stream stream = assembly.GetManifestResourceStream(resourceName))
        using (StreamReader reader = new StreamReader(stream))
        {
            jsonFile = reader.ReadToEnd();
        }

        hotels = JsonSerializer.Deserialize<List<Hotel>>(jsonFile);
    }

    public List<Hotel> GetData() => hotels;
}

public interface IHotelDataStore
{
    public List<Hotel> GetData();
}