using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Prismanda.ViewModels;

public class Page1ViewModel : INotifyPropertyChanged
{
    private bool _isBusy;
    public ICommand GoBackCommand { get; }
    public string Title { get; } = "Page1";

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

    public Page1ViewModel()
    {
        GoBackCommand = new Command(GoBack);
    }

    private async void GoBack()
    {
        try
        {
            IsBusy = true;

            await Task.Delay(3000);

            await Application.Current!.MainPage!.Navigation.PopModalAsync();
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