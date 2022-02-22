//Top - Level - Statement->Main Methode wird nicht expliziet ausgeschrieben

//Top-Level Statements ist die Main-Methode -> Programm.cs


//WebApplication Initialsiert

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);



//Wäre eigentlich in der Startup->public
//void ConfigureServices(IServiceCollection services)
//{
//    services.AddRazorPages();
//}
// Add services to the container.


//Viele andere Services werden hier mitgeliefert
builder.Services.AddRazorPages(); //RazorPages -> benötigen wird ein Page-Verzeichnis

var app = builder.Build(); //IOC Container beendet seine Initialisierung Phase mit Build 




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages(); //Navigation zwischen RazorPages (ohne diesen kann ich keine RazorSeite aufrufen) 

app.Run();
