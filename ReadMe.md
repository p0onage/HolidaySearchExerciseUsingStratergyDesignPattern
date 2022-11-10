# Holiday Search Algorithm Using Strategy Coding Pattern 

## Description

The solution loads both hotel and flight information using a JSON datastore with local resource files. Using the strategy pattern we can customise our search for both fligths and hotels to return the best result to the customer. 


## Holiday Search

Below in an example of a holiday search 

    var holidaySearch = new HolidaySearch({
      DepartingFrom: 'MAN',
      TravelingTo: 'AGP',
      DepartureDate: '2023/07/01'
      Duration: 7
      });


## Adding a new filter 

Inside of the HolidaySearchFilterService we can add or remove a filter easily. If creating a new filter simply inherit FilterStrategy and override the sort method. 

    if (!string.IsNullOrEmpty(holidaySearchFilter.DepartingFrom))
    {
        filterList.SetFilterStrategy(new FilterByDepartingAirport());
        filterList.Filter(holidaySearchFilter);
    }