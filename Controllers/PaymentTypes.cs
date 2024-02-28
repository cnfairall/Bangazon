 namespace Bangazon.Controllers
{
    public class PaymentTypes
    {
        public static void Map(WebApplication app)
        {
            //get payment types
            app.MapGet("/api/paymenttypes", (BangazonDbContext db) =>
            {
                return db.PaymentTypes;
            });
        }
    }
}
