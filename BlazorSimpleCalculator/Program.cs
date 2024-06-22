using BlazorSimpleCalculator.Components;
using MudBlazor.Services;
using Model.Services;
using Model.Calculators;
using BusinessComponent.Calculators;
using BusinessComponent.Operations;
using BusinessServices.Calculation;

namespace BlazorSimpleCalculator;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddMudServices();
        // Register CalculatorService
        builder.Services.AddScoped<ICalculatorService, CalculatorService>();
        builder.Services.AddTransient<ICalculator, Calculator>();
        builder.Services.AddTransient<IOperation, DevideOperation>();
        builder.Services.AddTransient<IOperation, PlusOperation>();
        builder.Services.AddTransient<IOperation, MultipleOperation>();
        builder.Services.AddTransient<IOperation, SubstractOperation>();
        builder.Services.AddTransient<ICalculatorProcessor, CalculatorProcessor>();
        builder.Services.AddTransient<ICalculatorState, CalculatorState>();

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
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
