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
        
        filterList.SetFilterStrategy(new FilterByDepartingAirport());
        filterList.Filter(holidaySearchFilter);

        return _searchResults;
    }
}


public interface IHolidaySearchFilterService
{
    public SearchResults FilterHolidaySearch(HolidaySearch holidaySearchFilter);
}