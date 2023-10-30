namespace AAPDemo.ViewModels;

using System.Collections.ObjectModel;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<int> Numbers { get; }

    [ObservableProperty]
    private bool _showRootAnchor = true;

    [ObservableProperty]
    private double _raH = 1.0;

    [ObservableProperty]
    private double _raV = 0.0;

    [ObservableProperty]
    private double _caH = 0.0;

    [ObservableProperty]
    private double _caV = 1.0;

    [ObservableProperty]
    private double _offsetH = 0.0;

    [ObservableProperty]
    private double _offsetV = 0.0;

    [ObservableProperty]
    private int _clickCount = 8;

    [RelayCommand]
    public void Click()
    {
        ClickCount++;
    }

    public MainWindowViewModel()
    {
    }
}
