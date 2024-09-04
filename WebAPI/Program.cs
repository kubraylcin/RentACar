using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;

var host = CreateHostBuilder(args).Build();

host.Run();

static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Autofac ile bağımlılık enjeksiyonunu yapılandır
        builder.RegisterModule(new AutofacBusinessModule());
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        // ASP.NET Core web host konfigürasyonu
        webBuilder.Configure(app =>
        {
            // HTTPS yönlendirmesi, yetkilendirme, rota kullanımı ve Swagger entegrasyonu gibi middleware'leri ekler.
            app.UseHttpsRedirection();
            app.UseRouting();

            // UseAuthorization, UseRouting'den sonra gelmelidir
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });
        });
    })
    .ConfigureServices(services =>
    {
        // ASP.NET Core servisleri konfigürasyonu: 
        // Kontrolleri ekler, endpoint API keşfi ve Swagger belgelemesi için gerekli olan servisleri ekler.
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    });
