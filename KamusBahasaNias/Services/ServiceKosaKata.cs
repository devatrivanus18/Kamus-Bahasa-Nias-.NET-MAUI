using KamusBahasaNias.Models;
using MvvmHelpers;
using SQLite;
using System.Collections.ObjectModel;

namespace KamusBahasaNias.Services;

public class ServiceKosaKata : BaseViewModel
{
    private ObservableCollection<KosaKata> _listKosaKata = new ObservableCollection<KosaKata>();
    public ObservableCollection<KosaKata> ListKosaKata { get => _listKosaKata; set => SetProperty(ref _listKosaKata, value); }
    readonly SQLiteAsyncConnection database;
    public ServiceKosaKata()
    {
        try
        {
            string dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
            database = new SQLiteAsyncConnection(dbpath);
            database.CreateTableAsync<KosaKata>().Wait();
            getdata();
        }
        catch (Exception ex)
        {

            ex.Message.ToString();
        }


    }
    public void getdata()
    {
        var data = GetAllBukuAsync().Result;
        foreach (var item in data)
        {
            ListKosaKata.Add(item);
        }
    }
    public Task<List<KosaKata>> GetAllBukuAsync()
    {

        return database.Table<KosaKata>().ToListAsync();
    }

    public Task<int> SaveBukuAsync(KosaKata kosaKata)
    {
        if (kosaKata.ID != 0)
        {
            // Update an existing note.
            return database.UpdateAsync(kosaKata);
        }
        else
        {
            // Save a new note.
            return database.InsertAsync(kosaKata);
        }
    }
}
