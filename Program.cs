using Distributedsqlservercache.Classes;
using Distributedsqlservercache.InterFaces;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IDistributedCachAdapter, DistributedCachAdapter>();
builder.Services.AddDistributedSqlServerCache(x =>
{
    x.SchemaName = "dbo";
    x.TableName = "ChacheTable";
    x.ConnectionString = "Server=DESKTOP-FPKJ6AU\\SQL2022;Database=CacheDb;Trusted_Connection=True;TrustServerCertificate=True";

});
var app = builder.Build();


app.MapGet("/cacheTesting", async (HttpContext context, IDistributedCachAdapter cache) =>
{
    int counter = 0;
    string key = "myCounter";
    counter = cache.Get<int>(key);
    cache.Set(key, ++counter);
    context.Response.WriteAsync(counter.ToString());
});
app.MapGet("/", () => "Hello World!");

app.Run();
