using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderServiceApp.Events
{
   public class OrderCreatedEvent
{
    public Guid OrderId { get; set; }
}

}