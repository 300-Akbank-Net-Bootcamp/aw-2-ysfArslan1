using PatikaGenelWepApi.DBOperations;

namespace VbApi;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        // ddatabase de baslang�c olarak database ve veri ekleme i�in kullan�l�yor
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            DataGenerator.Initialize(services);
        }
        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
}