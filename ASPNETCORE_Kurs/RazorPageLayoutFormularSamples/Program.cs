using RazorPageLayoutFormularSamples.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options=>
{
    
});

builder.Services.AddSingleton<IMovieService, MovieService>();
WebApplication app = builder.Build();





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
app.UseStaticFiles();

//Generell Navigation
app.UseRouting();

app.UseAuthorization();

//RazorPage Navigation -> Pages\[SubOrdner]\Page123
app.MapRazorPages();

app.Run();
