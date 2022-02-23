using RazorPage_Konfiguration_Samples.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.PostConfigure<PositionOptions>(myOptions =>
{
    myOptions.Name = "Max";
    myOptions.Title = "ist mit Moritz befreundet";
});

builder.Services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));

////Default-Werte

//builder.Services.PostConfigure<PositionOptions>(myOptions =>
//{
//    myOptions.Name = "Donald Duck";
//    myOptions.Title = "Dr.";
//});

////Hier liegen die Konfigurationen in IConfiguration: 
//builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position));







var app = builder.Build();

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

app.MapRazorPages();

app.Run();
