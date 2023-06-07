using RPS.Data;

var builder = WebApplication.CreateBuilder(args);


var tempDataContext = new PtInMemoryContext();

builder.Services.AddSingleton<IPtUserRepository, PtUserRepository>(c => new PtUserRepository(tempDataContext));
builder.Services.AddSingleton<IPtItemsRepository, PtItemsRepository>(c => new PtItemsRepository(tempDataContext));
builder.Services.AddSingleton<IPtDashboardRepository, PtDashboardRepository>(c => new PtDashboardRepository(tempDataContext));
builder.Services.AddSingleton<IPtTasksRepository, PtTasksRepository>(c => new PtTasksRepository(tempDataContext));
builder.Services.AddSingleton<IPtCommentsRepository, PtCommentsRepository>(c => new PtCommentsRepository(tempDataContext));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AddPageRoute("/Dashboard", "");
    });

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
