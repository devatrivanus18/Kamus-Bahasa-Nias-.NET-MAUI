namespace KamusBahasaNias.Pages;

public partial class KosaKataPage : ContentPage
{
	public KosaKataPage()
	{
		InitializeComponent();
	}

    private  void Button_Back_Clicked(object sender, EventArgs e)
    {
         Shell.Current.GoToAsync("..");
    }
}