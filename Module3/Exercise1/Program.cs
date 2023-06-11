using Exercise1;
using Exercise1.Services;

Distance distance = Distance.New(100);
Console.WriteLine($"Distance {distance.DisplayAsKilometers()}");
Console.WriteLine($"Distance {distance.DisplayAsMiles()}");
License license = new () { Value = "      " };
Console.WriteLine($"License: {license}");

UserService userService = new ();
ProductService productService = new ();
CartService cartService = new ();

