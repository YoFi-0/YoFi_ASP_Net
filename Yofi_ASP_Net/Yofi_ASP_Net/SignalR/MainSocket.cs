using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Yofi_ASP_Net.Global;
using Yofi_ASP_Net.Types;

namespace Yofi_ASP_Net.SignalR
{
    public class MainSocket : Hub
    {
        // signalR connection defenition
        // https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-7.0&tabs=visual-studio

        public class Message_Res {
            public string msg { get; set; }
        }
        public class Message_Req
        {
            public string msg { get; set; }
        }


        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"new user conncted to signalR {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"old user disconnect to signalR {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }
        public async Task Sleep(Message_Req req)
        {
            Console.WriteLine("sleep activated");
            AllFunctions.Sleep(10);
            Message_Res res = new Message_Res()
            {
                msg = $"zopy"
            };
            await Clients.All.SendAsync("Sleep", res);
            return;
        }
        public async Task Number_All(Message_Req req)
        {
            
            // تجهز فنكشن فلتر
            if (req == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            if (req.msg == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }

            if(req.msg == "plus")
            {
                Variables.Single_R_Number_All++;
            } else if (req.msg == "min")
            {
                Variables.Single_R_Number_All--;
            }
            Message_Res res = new Message_Res()
            {
                msg = $"{Variables.Single_R_Number_All}"
            };
            await Clients.All.SendAsync("Number_All", res);
        }

        public async Task Number_Caller(Message_Req req)
        {
            // تجهز فنكشن فلتر
            // نحتاج نربط السيشن عشان تشتغل هذي الفنكشن
            HttpContext? httpContext = Context.GetHttpContext()!;
            int Number_Caller_value = int.Parse(httpContext.Session.GetString("plusser")!);
            Console.WriteLine($"SingleR: {Number_Caller_value}");
            if (req == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            if (req.msg == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }

            if (req.msg == "plus")
            {
                Number_Caller_value++;
                httpContext.Session.SetString("plusser", $"{Number_Caller_value}");
            }
            else if (req.msg == "min")
            {
                Number_Caller_value--;
                httpContext.Session.SetString("plusser", $"{Number_Caller_value}");
            }
            Message_Res res = new Message_Res()
            {
                msg = $"{Number_Caller_value}"
            };
            await Clients.Caller.SendAsync("Number_Caller", res);
        }
        public async Task News(Message_Req req)
        {
            Console.WriteLine(req);
            await Clients.Caller.SendAsync("News", new Message_Res() { 
                msg = "this is a msg from the back end"
            });
        }
    }

    
}
