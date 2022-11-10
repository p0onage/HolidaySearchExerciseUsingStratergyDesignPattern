using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using HolidaySearchExercise.DataStore;
using HolidaySearchExercise.Models;

namespace HolidaySearchExercise.ServicesUnitTests;

public class HolidaySearchFilterServiceUnitTests
{
    private HolidaySearchFilterService _sut = new(new FlightsDataStore(), new HotelDataStore());

    [Fact]
    public void Filter_Results_By_Departing_From_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            DepartingFrom = "MAN"
        };
            
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
            
        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 1);
        Assert.Equal(results.Hotels.Count(), 2);
    }

    [Fact]
    public void Filter_Results_By_Duration_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            Duration = 7
        };
            
        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 12);
        Assert.Equal(results.Hotels.Count(), 5);
    }
    
    [Fact]
    public void Filter_Results_By_Departure_Date_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            DepartureDate = new DateTime(2023, 07,01)
        };
            
        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 4);
        Assert.Equal(results.Hotels.Count(), 2);
    }
    
    [Fact]
    public void Hotels_Should_Be_Sorted_By_Best_Value()
    {
        var HolidaySearch = new HolidaySearch();
            
        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Hotels.First().PricePerNight, 45);
    }

    [Fact]
    public void Flights_Should_Be_Sorted_By_Best_Value()
    {
        var HolidaySearch = new HolidaySearch();
            
        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.First().Price, 75);
    }


    [Fact (Skip = "failing, example test case for customer one in exercise don't match actual data.")]
    public void Filter_Results_By_Customer_One_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            DepartingFrom = "MAN",
            TravelingTo = "AGP",
            DepartureDate = new DateTime(2023, 07,01),
            Duration = 7
        };
            
        var _sut = new HolidaySearchFilterService(new FlightsDataStore(), new HotelDataStore());

        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 2);
        Assert.Equal(results.Hotels.Count(), 9);
    }
    
    [Fact (Skip = "failing, example test case for customer two in exercise don't match actual data.")]
    public void Filter_Results_By_Customer_Two_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            TravelingTo = "PMI",
            DepartureDate = new DateTime(2023, 06,15),
            Duration = 10
        };
            
        var _sut = new HolidaySearchFilterService(new FlightsDataStore(), new HotelDataStore());

        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 6);
        Assert.Equal(results.Hotels.Count(), 5);
        
    }
    
    [Fact (Skip = "failing, example test case for customer two in exercise don't match actual data.")]
    public void Filter_Results_By_Customer_Three_Should_Return()
    {
        var HolidaySearch = new HolidaySearch()
        {
            TravelingTo = "LPA",
            DepartureDate = new DateTime(2022, 11,10),
            Duration = 14
        };
            
        var _sut = new HolidaySearchFilterService(new FlightsDataStore(), new HotelDataStore());

        var results = _sut.FilterHolidaySearch(HolidaySearch);
        Assert.Equal(results.Flights.Count(), 7);
        Assert.Equal(results.Hotels.Count(), 6);
        
    }
}