namespace HolidaySearchExercise.Models;

public class SearchResults
{
    public SearchResults(List<Hotel> Hotels, List<Flight> Flights)
    {
        this.Hotels = Hotels;
        this.Flights = Flights;
    }
    public IEnumerable<Hotel> Hotels { get; set; }
    public IEnumerable<Flight> Flights { get; set; }
}