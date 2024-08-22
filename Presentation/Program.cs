var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Add as dependency Injections e outros services
// como base de dados, email e qualquer outra coisa
builder.Services.AddDependencyInjections();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Adiciona aquela tela de erro amarela com stack tracer
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
