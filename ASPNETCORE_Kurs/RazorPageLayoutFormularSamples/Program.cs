using Microsoft.EntityFrameworkCore;
using RazorPageLayoutFormularSamples.Data;
using RazorPageLayoutFormularSamples.Services;
using Microsoft.AspNetCore.Identity;

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


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Produktiver Modus

    //formatierte Fehlerseite f�r den Kunden
    app.UseExceptionHandler("/Error");
    
    
    //HSTS ist ein Aufsatz Https 
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//HTTPS 
app.UseHttpsRedirection();

//wwwroot
app.UseStaticFiles();

//Generell Navigation
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseAuthorization();

//RazorPage Navigation -> Pages\[SubOrdner]\Page123
app.MapRazorPages();

app.Run();
