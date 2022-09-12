using KamusBahasaNias.Services;
using KamusBahasaNias.ViewModels;

namespace KamusBahasaNias;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton(new ServiceKosaKata());
		builder.Services.AddSingleton(new ViewModelKosaKata());
		builder.Services.AddSingleton(new ViewModelTambahData());
		return builder.Build();
	}
}
