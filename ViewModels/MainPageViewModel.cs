using Prismanda.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Prismanda.ViewModels;

public class MainPageViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    public ICommand ModalNavigationCommand { get; }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value)
            {
                return;
            }
            _isBusy = value;
            OnPropertyChanged();
        }
    }

    public MainPageViewModel()
    {
        ModalNavigationCommand = new Command(NavigateAsync);
    }

    private async void NavigateAsync()
    {
        try
        {
            IsBusy = true;

            await Task.Delay(3000);

            await Application.Current!.MainPage!.Navigation.PushModalAsync(new Page1(new Page1ViewModel()), true);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}