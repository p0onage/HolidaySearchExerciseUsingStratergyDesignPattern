using HolidaySearchExercise.DataStore;
using HolidaySearchExercise.Models;

namespace HolidaySearchExercise.ServicesUnitTests;

public class HolidaySearchFilterServiceUnitTests
{
    
    [Fact]
    public void Filter_Results_By_Departing_From_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            DepartingFrom = "MAN"
        };
            
        var _sut = new HolidaySearchFilterService(new FlightsDataStore(), new HotelDataStore());

        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 8);
    }
    
    [Fact]
    public void Filter_Results_By_Traveling_To_Destination_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            TravelingTo = "TFS"
        };
            
        var _sut = new HolidaySearchFilterService(new FlightsDataStore(), new HotelDataStore());

        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 1);
        Assert.Equal(results.Hotels.Count(), 2);
    }

    
    [Fact]
    public void Filter_Results_By_Customer_One_Should_Return()
    {
        // Expected result
        //Flight 2 and Hotel 9
        throw new NotImplementedException();
    }
    
    [Fact]
    public void Filter_Results_By_Customer_Two_Should_Return()
    {
        // Expected result
        //Flight 6 and Hotel 5
        
        throw new NotImplementedException();
    }
    
    [Fact]
    public void Filter_Results_By_Customer_Three_Should_Return()
    {
        // Expected result
        //Flight 7 and Hotel 6
        
        throw new NotImplementedException();
    }
}