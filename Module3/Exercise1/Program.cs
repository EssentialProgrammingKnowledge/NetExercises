using Exercise1;
using Exercise1.Services;

Distance distance = Distance.New(100);
Console.WriteLine($"Distance {distance.DisplayAsKilometers()}");
Console.WriteLine($"Distance {distance.DisplayAsMiles()}");
License license = new () { Value = "      " };
Console.WriteLine($"License: {license}");

UserService userService = new ();
userService.Add(new User { Email = "test@test.com", Name = "Test", Password = "password" });
userService.Get(1);
ProductService productService = new ();
productService.Add(new Product { Name = "Product#1", Category = "Category#1", Description = "Description" });
productService.Get(1);
CartService cartService = new ();
cartService.Add(new Cart { ProductId = 1, UserId = 1 });
cartService.Get(1);
