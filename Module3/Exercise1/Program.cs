using Exercise1;
using Exercise1.Services;

Distance distance = new () { Value = -100 };
Console.WriteLine($"Distance {distance}");
License license = new () { Value = "      " };
Console.WriteLine($"License: {license}");

UserService userService = new ();
ProductService productService = new ();
CartService cartService = new ();

