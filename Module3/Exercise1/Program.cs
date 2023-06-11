using Exercise1;
using Exercise1.Services;

Distance distance = Distance.New(100);
Console.WriteLine($"Distance {distance.DisplayAsKilometers()}");
Console.WriteLine($"Distance {distance.DisplayAsMiles()}");
try
{
    License license = new("2023/06/11/1");
    Console.WriteLine($"License: {license}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

UserService userService = new ();
userService.Add(new User { Email = "test@test.com", Name = "Test", Password = "password" });
Console.WriteLine(userService.Get(1));
ProductService productService = new ();
productService.Add(new Product { Name = "Product#1", Category = "Category#1", Description = "Description" });
Console.WriteLine(productService.Get(1));
CartService cartService = new ();
cartService.Add(new Cart { ProductId = 1, UserId = 1 });
Console.WriteLine(cartService.Get(1));
