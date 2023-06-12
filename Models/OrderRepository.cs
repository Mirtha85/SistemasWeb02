using System.Net.Mail;
using System.Net;

namespace SistemasWeb01.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BethesdaPieShopDbContext bethesdaPieShopDbContext, IShoppingCart shoppingCart)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bethesdaPieShopDbContext.Orders.Add(order);

            _bethesdaPieShopDbContext.SaveChanges();
        }
        public string detalleOrden (Order order) 
        {
            string nombre = "Lista de productos Comprados\n-----------------------------------";
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                nombre = nombre + "\nproducto " +  shoppingCartItem.Pie.Name + " precio :" +shoppingCartItem.Pie.Price + " Cantidad "+ shoppingCartItem.Amount;
                
            }
            nombre = nombre + "\nTotal : "+ order.OrderTotal;
            return nombre;
        }
        public void correoSend(string informacion)
        {

            string destinatario = "alexiscruzt2@gmail.com";
            string asunto = "Correo de prueba";
            string contenido = informacion;

            // Configurar la información del remitente y el servidor SMTP
            string remitente = "alex29cruz09ticona@gmail.com";
            string contraseña = "kmdljfvakjzomaed";
            string servidorSmtp = "smtp.gmail.com";
            int puertoSmtp = 587;

            try
            {
                // Crear el objeto MailMessage con el contenido del correo
                MailMessage correo = new MailMessage(remitente, destinatario, asunto, contenido);

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient(servidorSmtp, puertoSmtp);
                clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);
                clienteSmtp.EnableSsl = true;

                // Enviar el correo
                clienteSmtp.Send(correo);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
