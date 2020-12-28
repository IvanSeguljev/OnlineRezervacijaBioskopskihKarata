using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineRezervacijaBioskopskihKarata.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Projection")]
        public int ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }
        public string OrderId { get; set; }
        public string TicketGuid { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}