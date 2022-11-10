using HolidaySearchExercise.Models;

namespace HolidaySearchExercise;

public abstract class FilterStrategy
{
    public abstract void Sort(SearchResults list, HolidaySearch filter);
}

public class FilterByDepartingAirport : FilterStrategy
{
    public override void Sort(SearchResults searchResults, HolidaySearch filter)
    {
        searchResults.Flights = searchResults.Flights.Where(x => x.From == filter.DepartingFrom).ToList();
    }
}

public class FilterByTravelingDestination : FilterStrategy
{
    public override void Sort(SearchResults searchResults, HolidaySearch filter)
    {
        searchResults.Flights = searchResults.Flights.Where(x => x.To == filter.TravelingTo).ToList();
        searchResults.Hotels = searchResults.Hotels.Where(x => x.LocalAirports.Contains(filter.TravelingTo)).ToList();
    }
}


public class FilterList
{
    private SearchResults searchResults;
    private FilterStrategy filterStrategy;

    public FilterList(SearchResults searchResults)
    {
        this.searchResults = searchResults;
    }
    public void SetFilterStrategy(FilterStrategy filterStrategy)
    {
        this.filterStrategy = filterStrategy;
    }

    public void Filter(HolidaySearch filter)
    {
        filterStrategy.Sort(searchResults, filter);
    }

}