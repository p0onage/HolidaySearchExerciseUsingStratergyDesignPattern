using HolidaySearchExercise.DataStore;
using HolidaySearchExercise.Models;

namespace HolidaySearchExercise;

public class HolidaySearchFilterService : IHolidaySearchFilterService
{
    private readonly SearchResults _searchResults;

    public HolidaySearchFilterService(IFlightsDataStore flightDataStore, IHotelDataStore hotelDataStore)
    {
        _searchResults = new SearchResults(hotelDataStore.GetData(),flightDataStore.GetData());
    }
    
    public SearchResults FilterHolidaySearch(HolidaySearch holidaySearchFilter)
    {
        var filterList = new FilterList(_searchResults);
        
        if (!string.IsNullOrEmpty(holidaySearchFilter.DepartingFrom))
        {
            filterList.SetFilterStrategy(new FilterByDepartingAirport());
            filterList.Filter(holidaySearchFilter);
        }

        if (!string.IsNullOrEmpty(holidaySearchFilter.TravelingTo))
        {
            filterList.SetFilterStrategy(new FilterByTravelingDestination());
            filterList.Filter(holidaySearchFilter);
        }
        
        if (holidaySearchFilter.DepartureDate != default)
        {
            filterList.SetFilterStrategy(new FilterByDepartureDate());
            filterList.Filter(holidaySearchFilter);
        }
        
        if (holidaySearchFilter.Duration != default)
        {
            filterList.SetFilterStrategy(new FilterByDuration());
            filterList.Filter(holidaySearchFilter);
        }
        
        filterList.SetFilterStrategy(new SortByBestValue());
        filterList.Filter(holidaySearchFilter);
        
        return _searchResults;
    }
}


public interface IHolidaySearchFilterService
{
    public SearchResults FilterHolidaySearch(HolidaySearch holidaySearchFilter);
}