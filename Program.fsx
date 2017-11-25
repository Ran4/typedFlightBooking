#load "FlightBooking.fs"
open FlightBooking.NiceFlightBooking
open FlightBooking.UglyFlightBooking

// This is easy to understand without reading the definition of bookFlight, and will give us type mismatch
// errors if e.g. the return value of bookFlight changes (which is what we want!
// Not compiling is preferable to introducing bugs!)
match bookFlight "St. Louis" PremierCustomer NoCheckedLuggage PrefersWindowSeat with
| FlightBooked -> printfn "The flight was successfully booked!"
| FlightNotBooked -> printfn "We couldn't book the flight"

// This is harder to understand without reading the type definition
if uglyBookFlight "St. Louis" true false true then
    printfn "The flight was successfully booked!"
else
    printfn "We couldn't book the flight"
