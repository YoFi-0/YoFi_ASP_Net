using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using Yofi_ASP_Net.Global;
using static Google.Rpc.Context.AttributeContext.Types;

namespace Yofi_ASP_Net.SignalR
{
    public class MainSocket : Hub
    {
        // signalR connection defenition
        // https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-7.0&tabs=visual-studio

        private class Message_Res {
            public string msg { get; set; }
        }
        private class Message_Req
        {
            public string msg { get; set; }
        }


        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"new user conncted {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"old user disconnect {Context.ConnectionId}");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task Number_All(string reqString)
        {
            
            // تجهز فنكشن فلتر
            if (reqString == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            Message_Req msg;
            try
            {
                msg = JsonSerializer.Deserialize<Message_Req>(reqString)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            if (msg.msg == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }

            if(msg.msg == "plus")
            {
                Variables.Single_R_Number_All++;
            } else if (msg.msg == "min")
            {
                Variables.Single_R_Number_All--;
            }
            Message_Res res = new Message_Res()
            {
                msg = $"{Variables.Single_R_Number_All}"
            };
            await Clients.All.SendAsync("Number_All", JsonSerializer.Serialize(res));
        }

        public async Task Number_Caller(string reqString)
        {
            // تجهز فنكشن فلتر
            // نحتاج نربط السيشن عشان تشتغل هذي الفنكشن
            HttpContext? httpContext = Context.GetHttpContext()!;
            int Number_Caller_value = int.Parse(httpContext.Session.GetString("plusser")!);
            Console.WriteLine($"SingleR: {Number_Caller_value}");
            if (reqString == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            Message_Req msg;
            try
            {
                msg = JsonSerializer.Deserialize<Message_Req>(reqString)!;
            }
            catch (Exception ex)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }
            if (msg.msg == null)
            {
                Console.WriteLine("SingleR: invalid json data");
                return;
            }

            if (msg.msg == "plus")
            {
                Number_Caller_value++;
                httpContext.Session.SetString("plusser", $"{Number_Caller_value}");
            }
            else if (msg.msg == "min")
            {
                Number_Caller_value--;
                httpContext.Session.SetString("plusser", $"{Number_Caller_value}");
            }
            Message_Res res = new Message_Res()
            {
                msg = $"{Number_Caller_value}"
            };
            await Clients.Caller.SendAsync("Number_Caller", JsonSerializer.Serialize(res));
        }
    }

    
}
