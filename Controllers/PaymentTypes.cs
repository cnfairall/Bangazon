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

            //get payment type by id
            app.MapGet("/api/paymenttypes/{id}", (BangazonDbContext db, int id) =>
            {
                return db.PaymentTypes.SingleOrDefault(x => x.Id == id);
            });
        }
    }
}
