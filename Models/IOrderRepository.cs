﻿namespace SistemasWeb01.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void correoSend(string informacion, string Email);
        string detalleOrden(Order order);

    }
}
