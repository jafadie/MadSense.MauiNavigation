using Prismanda.Views;
using System.Diagnostics;

namespace Prismanda.Services;

internal class BackgroundService
{
    private INavigation Navigation { get; }
    private Task BackgroundTask { get; }

    public BackgroundService(INavigation navigation)
    {
        Navigation = navigation;

        BackgroundTask = BackgroundExecution();
    }

    private async Task BackgroundExecution()
    {
        try
        {
            // Remove this produce a Current MainPage null
            await Task.Delay(3000);

            while (true)
            {
                await Navigation.PushModalAsync(new Page1(), true);

                await Task.Delay(3000);

                await Navigation.PopModalAsync();

                await Task.Delay(3000);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Debugger.Break();
        }
    }
}