using Microsoft.EntityFrameworkCore;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Services;
using Microsoft.AspNetCore.Identity;
using RazorPageLayoutFormularSamples.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options=>
{
    
});

//Intern wird bei AddDBContext -> ISeriveCollection -> AddScoped()
builder.Services.AddDbContext<MovieDbContext>(options =>
{
    //options.UseInMemoryDatabase("MovieDb");
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMovieConnectionString"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MovieStoreUserIdentityDb>();builder.Services.AddDbContext<MovieStoreUserIdentityDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieStoreUserIdentityDbConnection")));
builder.Services.AddSession();
builder.Services.AddAuthentication();
builder.Services.AddSingleton<IMovieService, MovieService>();
WebApplication app = builder.Build();

//Fr�heste M�glichkeit auf IOC Container zuzugreifen 
using (IServiceScope scope = app.Services.CreateScope())
{
    DataSeed.Init(scope.ServiceProvider);
}



//MIDDLEWARE-PIPELINE BEGIN

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Produktiver Modus

    //formatierte Fehlerseite für den Kunden
    app.UseExceptionHandler("/Error");
    
    
    //HSTS ist ein Aufsatz Https 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



//HTTPS 
app.UseHttpsRedirection();

//wwwroot
app.UseStaticFiles(); //wwwRoot


AppDomain.CurrentDomain.SetData("BildVerzeichnis", app.Environment.WebRootPath); //wwwRoot Verzeichnis wird gespeichert

//Generell Navigation
app.UseRouting();

//Indentiy UI Library
app.UseAuthentication();
app.UseAuthorization();

//Session Middleware
app.UseSession();

#region Customize Middleware
app.MapWhen(context => context.Request.Path.ToString().Contains("imagegen"), subapp =>
{
    subapp.UseThumbnailGen();
});
#endregion




//RazorPage Navigation -> Pages\[SubOrdner]\Page123
app.MapRazorPages();
//MIDDLEWARE-PIPELINE ENDE  -> app.MapRazorPages(); ODER app.MapController 

app.Run();
