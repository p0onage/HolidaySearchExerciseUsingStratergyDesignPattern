using HolidaySearchExercise.DataStore;
using HolidaySearchExercise.Models;

namespace HolidaySearchExercise;

public class GetFlightDataStoreTests
{
    
    [Fact]
    public void First_Item_In_Data_Store_Should_Be()
    {
        var _sut = new FlightsDataStore();
        var  flightData = _sut.GetFlightData();
        var firstFlightId = flightData.First().Id;
        Assert.Equal(firstFlightId,1);
    }
}