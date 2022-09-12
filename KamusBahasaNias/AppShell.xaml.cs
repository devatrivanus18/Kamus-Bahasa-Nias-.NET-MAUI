using KamusBahasaNias.Pages;

namespace KamusBahasaNias;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("KosaKataPage", typeof(KosaKataPage));
        Routing.RegisterRoute("TambahDataPage", typeof(TambahDataPage));
    }
}
