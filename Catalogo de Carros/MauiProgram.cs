namespace Catalogo_de_Carros;

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
                fonts.AddFont("FontAwesome6Free-Solid-900.otf", "FontAwesomeSolid");
                fonts.AddFont("FontAwesome6Free-Regular-400.otf", "FontAwesomeRegular");
            });

		return builder.Build();
	}
}
