var builder = WebApplication.CreateBuilder(args);

//Razor Page -> wird verewndet 
//builder.Services.AddRazorPages(); //UI Framework -> Razor Page

//builder.Services.AddControllersWithViews(); //UI Framework -> MVC 

//Achtung Extrafall -> MVC Anwendung verwendet Idenetiy UI (Library mit UserAccounts->Authentifizierung etc)
//Idenetiy UI liegt nur in RazorPages vor
//AddMVC wird verwendet, wenn eine MVC Anwendung die Identtity verwendet
//builder.Services.AddMvc(); // AddRazorPages + AddControllersWithViews

/* Deep Dive in ASPNET Core SourceCode von AddMVC(): 
 * 
 * /// <summary>
    /// Adds MVC services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>An <see cref="IMvcBuilder"/> that can be used to further configure the MVC services.</returns>
    public static IMvcBuilder AddMvc(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddControllersWithViews();
        return services.AddRazorPages();
    }
 * 
 */


//Bietet Daten in JSON Format an (XML, CSV....) 
//builder.Services.AddControllers(); //WebAPI - RESTFul Service (Http->GET/POST/PUT/DELETE


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
