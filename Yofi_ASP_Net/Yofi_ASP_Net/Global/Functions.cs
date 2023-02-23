namespace Yofi_ASP_Net.Global
{
    public class AllFunctions
    {
        public static void Sleep(int Second)
        {
            Task.Delay(TimeSpan.FromSeconds(Second)).GetAwaiter().GetResult();
        }
    }
}
