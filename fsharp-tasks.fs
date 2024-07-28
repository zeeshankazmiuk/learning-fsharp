module Sprint3

open System

// Accommodation class created 
type Accommodation(name:string, address:string, doorNum:int, price:decimal, occupantCapacity:int, isBooked:bool) =
    // Attributes declared
    member val Name = name with get
    member val Address = address with get
    member val DoorNum = doorNum with get
    member val Price = price with get
    member val OccupantCapacity = occupantCapacity with get
    member val IsBooked = isBooked with get, set

    abstract member Print : unit -> unit

    // Print method declared and made virtual to be overridden
    default this.Print() =
        Console.WriteLine($"Name: {this.Name}")
        Console.WriteLine($"Address: {this.Address}")
        Console.WriteLine($"Door: {this.DoorNum}")
        Console.WriteLine($"Price: £{this.Price}")
        Console.WriteLine($"Occupant Capacity: {this.OccupantCapacity}")
        Console.WriteLine($"Is booked: {this.IsBooked}")

type House(name:string, address:string, doorNum:int, price:decimal, occupantCapacity:int, isBooked:bool, floorCount:int, bedroomCount:int, bathroomCount:int, hasGarden:bool) =
    inherit Accommodation(name, address, doorNum, price, occupantCapacity, isBooked)
    member val FloorCount = floorCount with get
    member val BedroomCount = bedroomCount with get
    member val BathroomCount = bathroomCount with get
    member val HasGarden = hasGarden with get

    override this.Print() =
        base.Print()
        Console.WriteLine($"Number of Floors: {floorCount}")
        Console.WriteLine($"Bedroom Count: {bedroomCount}")
        Console.WriteLine($"Bathroom Count: {bathroomCount}")
        Console.WriteLine($"Has Garden: {hasGarden} \n\n") 

type Hotel(name:string, address:string, doorNum:int, price:decimal, occupantCapacity:int, isBooked:bool, Floor:int, ServesFood:bool, HasDoublebed:bool, PetsAllowed:bool, HasBalcony:bool) =
    inherit Accommodation(name, address, doorNum, price, occupantCapacity, isBooked)
    member val Floor = Floor with get 
    member val ServesFood = ServesFood with get
    member val HasDoublebed = HasDoublebed with get
    member val PetsAllowed = PetsAllowed with get 
    member val HasBalcony = HasBalcony with get 
    
    override this.Print() =
        base.Print()
        Console.WriteLine($"Floor number: {Floor}")
        Console.WriteLine($"Serves food: {ServesFood}")
        Console.WriteLine($"Has double bed: {HasDoublebed}")
        Console.WriteLine($"Pets allowed: {PetsAllowed}")
        Console.WriteLine($"Has Balcony: {HasBalcony} \n\n") 

type Flat(name:string, address:string, doorNum:int, price:decimal, occupantCapacity:int, isBooked:bool, Floor:int, BedroomCount:int, BathroomCount:int, HasBalcony:bool) =
    inherit Accommodation(name, address, doorNum, price, occupantCapacity, isBooked)
    member val Floor = Floor with get 
    member val BedroomCount = BedroomCount with get 
    member val BathroomCount = BathroomCount with get 
    member val HasBalcony = HasBalcony with get

    override this.Print() =
        base.Print()
        Console.WriteLine($"Floor number: {Floor}")
        Console.WriteLine($"Bedroom Count: {BedroomCount}")
        Console.WriteLine($"Bathroom Count: {BathroomCount}")
        Console.WriteLine($"Has Balcony: {HasBalcony} \n\n")

let wayneManor = House("Wayne Manor", "Negra Arroyo Lane", 308, 69000, 4, false, 2, 3, 2, true)
let transylvania = Hotel("Transylvania", "Spooky Lane", 21, 420000, 2, false, 36, true, true, true, false)
let happyFlat = Flat("Happy Flat", "Happy Street", 1, 99999, 1, false, 0, 1, 1, true)

let accomList =
    [
        wayneManor :> Accommodation
        transylvania :> Accommodation
        happyFlat :> Accommodation
    ]

accomList |> List.iter (fun accommodation -> accommodation.Print())

// task 1
let times5 x = x * 5

// task 2
let task2answer = times5 3
printfn "Multiplied by 5: %d" task2answer

// task 3
let minus5 x = x - 5

// task 4
let task4answer = minus5 15
printfn "Subracting 5: %d" task4answer

// task 5
let product5Sub5 = times5 >> minus5

// task6
let task6answer = product5Sub5 5
printfn "Composition: %d" task6answer

// task 7
let task7answer =
    8
    |> times5
    |> minus5

printfn "Pipeline: %d" task7answer
