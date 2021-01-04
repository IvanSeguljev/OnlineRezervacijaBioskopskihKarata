using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineRezervacijaBioskopskihKarata.Models
{
    public class ViewTicketsViewModel
    {
        public ICollection<Reservation> Reservations { get; set; }
        public Projection Projection { get; set; }
        public string TransactionId { get; set; }
    }
}