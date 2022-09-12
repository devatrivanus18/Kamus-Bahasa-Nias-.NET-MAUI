using KamusBahasaNias.Models;
using KamusBahasaNias.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace KamusBahasaNias.ViewModels;

public class ViewModelKosaKata : BaseViewModel
{
    private bool _isRefresh;
    public bool IsRefresh { get => _isRefresh; set => SetProperty(ref _isRefresh, value); }

    private ObservableCollection<KosaKata> _listKosaKata = new ObservableCollection<KosaKata>();
    public ObservableCollection<KosaKata> ListKosaKata { get => _listKosaKata; set => SetProperty(ref _listKosaKata, value); }
    public ServiceKosaKata service { get; }
    public ICommand RefreshCommand { get; set; }
    public ViewModelKosaKata()
    {
        service = new ServiceKosaKata();
        ListKosaKata = service.ListKosaKata;
        RefreshCommand = new AsyncCommand(RefreshData);
    }

    private async Task RefreshData()
    {
        ListKosaKata = service.ListKosaKata;
        IsRefresh = false;
    }
}
