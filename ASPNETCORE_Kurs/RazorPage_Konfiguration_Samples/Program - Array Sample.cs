//using RazorPage_Konfiguration_Samples.Models;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();


////"MyArray.json -> IConfiguration 
//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile("MyArray.json", optional: true, reloadOnChange: true);
//});

//builder.Services.Configure<ArrayExample>(
//    builder.Configuration.GetSection("array"));




//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();
