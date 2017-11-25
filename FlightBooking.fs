namespace FlightBooking

module ExternalApi =
    type BookFlightApiCallResponse = { status: int }
    let bookFlightApiCall requestBody =
        // ...perform the actual API call here
        { status = 200 }

        
// This module is longer, but is more explicit and is nicer to use
module NiceFlightBooking =
    open ExternalApi
    
    type City = string
    type CustomerType = PremierCustomer | RegularCustomer
    type CheckedLuggage = HasCheckedLuggage | NoCheckedLuggage
    type SeatPreference = PrefersWindowSeat | PrefersIsleSeat
    type BookFlightResult = FlightBooked | FlightNotBooked
    
    //val bookFlight : City -> CustomerType -> CheckedLuggage -> SeatPreference -> BookFlightResult
    let bookFlight city customerType checkedLuggage seatPreference =
        let requestString =
            sprintf """
    {
      "city": "%s",
      "customerType": %d,
      "checkedLuggage": "%s",
      "seatPreference": "%s"
    }
    """
                city
                (match customerType with PremierCustomer -> 11 | RegularCustomer -> 27)
                (match checkedLuggage with HasCheckedLuggage -> "checked" | NoCheckedLuggage -> "not checked")
                (match seatPreference with PrefersWindowSeat -> "WINDOW" | PrefersIsleSeat -> "ISLE")
        if (bookFlightApiCall requestString).status = 200 then
            FlightBooked
        else
            FlightNotBooked
            
// This module is shorter, but using it likely requires reading it's definition in order to understand it
module UglyFlightBooking =
    open ExternalApi
    
    //val uglyBookFlight : City -> bool -> bool -> bool -> true
    let uglyBookFlight city isPremium hasCheckedLuggage prefersWindowSeat =
        let requestString =
            sprintf """
    {
      "city": "%s",
      "customerType": %d,
      "checkedLuggage": "%s",
      "seatPreference": "%s"
    }
    """
                city
                (if isPremium then 11 else 27)
                (if hasCheckedLuggage then "checked" else "not checked")
                (if prefersWindowSeat then "WINDOW" else "ISLE")
        (bookFlightApiCall requestString).status = 200
