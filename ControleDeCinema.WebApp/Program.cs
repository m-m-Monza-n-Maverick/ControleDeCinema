namespace ControleDeCinema.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			#region Processo de configuração de serviços e dependência da aplicação
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();
			#endregion

			WebApplication app = builder.Build();

			app.UseStaticFiles();

			app.MapControllerRoute("rotas-padrao", "{controller}/{action}/{id:int?}");

			app.Run();
		}
	}
}
