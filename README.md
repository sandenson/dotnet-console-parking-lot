# DIO - .NET - Fundamentals learning path

<www.dio.me>

## Project challenge

For this challenge, you'll need to use the knowledge you acquired in the fundamentals module of DIO's .NET learning path.

## Context

You've been hired to build a system for a parking lot, which will be used to manage the vehicles parked and perform operations such as add a vehicle, remove a vehicle (and display the amount charged for the period) and list the vehicles.

## Proposal

You'll need to build a class named "ParkingLot", according to the diagram below:
![Parking lot class diagram](parking_lot_class_diagram.png)

The class contains three variables, being:

**starterFare**: Decimal type. It's the amount charged to leave your vehicle parked.

**hourlyRate**: Decimal type. It's the amount charged for each hour that the vehicle stays parked for.

**vehicles**: String list. Represents a collection of parked vehicles. Contains only the vehicle's license plate

The class contains three methods, being:

**AddVehicle**: Method responsible for getting a plate typed by the user and storing it in the **vehicles** variable.

**RemoveVehicle**: Method responsible for verifying whether a specific vehicle is parked, and if true, will ask for the amount of hours it has stayed on the parking lot for. After that, it performs the following calculation: **starterFare** + **hoursStayed** * **hourlyRate**, and displays the result to the user.

**ListVehicles**: Lists all the vehicles currently present in the parking lot. If there are none, display the message "There are no currently parked vehicles".

Finally, an interactive menu must be made with the following actions implemented:

1. Register vehicle
2. Remove vehicle
3. List vehicles
4. Close

## Solution

The code is half finished, and you must continue it while following the rules described above, so that in the and we have a functional program. Look for the commented word "TODO" in the code, then implement according to the rules above.
