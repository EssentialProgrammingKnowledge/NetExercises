// See https://aka.ms/new-console-template for more information
using Exercise3;

Console.WriteLine("Hello, World!");

var messageHandler = new MessageHandler();
messageHandler.OnSendMessage += (msg) => Console.WriteLine($"OnSendMessage {msg}");
messageHandler.OnSendMessageEventHandler += (sender, eventArgs) => Console.WriteLine($"OnSendMessageEventHandler {sender} {eventArgs}");
messageHandler.SendMessage("Test1234");
messageHandler.SendMessage("Test12345");
messageHandler.SendMessage("Test123456");
messageHandler.SendMessage("Test1234567");
