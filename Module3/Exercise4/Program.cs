using Exercise4;

var service = new Service<TokenDto>();
var tokenService = new TokenService(service, service, service);
tokenService.Add(new TokenDto
{
    Id = 1,
    Value = "abc"
});
var token = tokenService.Get(1);
Console.WriteLine(token);
tokenService.Delete(token);
token = tokenService.Get(1);
Console.WriteLine(token is null ? "null value" : token);

var messageSender = new MessageSender();
messageSender.SendMail(new EmailMessage("title", "content", "from", "to"));
