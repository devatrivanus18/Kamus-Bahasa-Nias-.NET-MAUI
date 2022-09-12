using KamusBahasaNias.Models;
using KamusBahasaNias.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace KamusBahasaNias.ViewModels;

public class ViewModelTambahData : BaseViewModel
{
    #region Property
    private string _asalKata;
    public string AsalKata { get => _asalKata; set => SetProperty(ref _asalKata, value); }

    private string _terjemahanKata;
    public string TerjemahanKata { get => _terjemahanKata; set => SetProperty(ref _terjemahanKata, value); }

    private string _penulisanKata;
    public string PenulisanKata { get => _penulisanKata; set => SetProperty(ref _penulisanKata, value); }
    #endregion

    #region Command
    public ICommand TambahCommand { get; set; }

    #endregion

    #region Method
    public ServiceKosaKata service { get; }
    public ViewModelTambahData()
    {
        Bersih();
        service = new ServiceKosaKata();
        TambahCommand = new AsyncCommand(TambahData);
    }

    public void Bersih()
    {
        AsalKata = String.Empty;
        PenulisanKata = String.Empty;
        TerjemahanKata = String.Empty;
    }
    private async Task TambahData()
    {
        var data = new KosaKata
        {
            KataAsal = this.AsalKata,
            KataTerjemahan = this.TerjemahanKata,
            PenulisanKata = this.PenulisanKata
        };
        await service.SaveBukuAsync(data);
        await Application.Current.MainPage.DisplayAlert("Berhasil", $"data dengan kata {data.KataAsal} berhasil Disimpan", "Ok");
        await Shell.Current.GoToAsync("KosaKataPage");
        Bersih();
    }
    #endregion
}
