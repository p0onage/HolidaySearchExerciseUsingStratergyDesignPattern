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

public class FilterByDepartureDate : FilterStrategy
{
    public override void Sort(SearchResults searchResults, HolidaySearch filter)
    {
        searchResults.Flights = searchResults.Flights.Where(x => x.DepartureDate == filter.DepartureDate).ToList();
        
        // Potential issue, we don't know how long the flights take to arrive at destination to filter hotels on accurate arrival date.
        searchResults.Hotels = searchResults.Hotels.Where(x => x.ArrivalDate == filter.DepartureDate).ToList();
    }
}

public class FilterByDuration : FilterStrategy
{
    public override void Sort(SearchResults searchResults, HolidaySearch filter)
    {
        //We could have flights without hotels because of this filter.
        searchResults.Hotels = searchResults.Hotels.Where(x => x.Nights == filter.Duration).ToList();
    }
}

public class SortByBestValue : FilterStrategy
{
    public override void Sort(SearchResults searchResults, HolidaySearch filter)
    {
        searchResults.Hotels = searchResults.Hotels.OrderBy(x => x.PricePerNight);
        searchResults.Flights = searchResults.Flights.OrderBy(x => x.Price);
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