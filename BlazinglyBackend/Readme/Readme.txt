Make sure ConnectionString is in appsettings.json

Drop tables from database

Publish SQL server project (APIBackendDb)

Scaffold DBContext: 
Scaffold-DbContext -Connection name=APIDb -Provider Microsoft.EntityFrameworkCore.SqlServer -Project "APIBackend" -OutputDir "Models/Entities" -Context "APIContext" -NoOnConfiguring -Force

Add DbContext and ConnectionString to Program.cs:
builder.Services.AddDbContext<APIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIDb") ?? throw new InvalidOperationException("Connection string 'APIBackendContext' not found.")));

Fix the generated DBContext and Models. Adding InputModel 

Scaffold Controller:
dotnet-aspnet-codegenerator controller -name APIController -async -api -m TagItem -dc APIContext -outDir Controllers

Fix around in the controller

Add Services in Program.cs
builder.Services.AddScoped<TagItemService>();

