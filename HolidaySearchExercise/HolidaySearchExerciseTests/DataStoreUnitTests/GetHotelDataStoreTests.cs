using HolidaySearchExercise.DataStore;
using HolidaySearchExercise.Models;

namespace HolidaySearchExercise;

public class GetHotelDataStoreTests
{
    
    [Fact]
    public void First_Item_In_Data_Store_Should_Be()
    {
        var _sut = new HotelDataStore();
        var  data = _sut.GetData();
        var firstHotelId = data.First().Id;
        Assert.Equal(firstHotelId,1);
    }
}