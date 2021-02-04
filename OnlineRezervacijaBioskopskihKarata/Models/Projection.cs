using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace OnlineRezervacijaBioskopskihKarata.Models
{
    public class Projection
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public int TicketCost { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

        public string GetTicketsSold()
        {
            return Reservations.Count.ToString();
        }

        public string formatReservedSeats()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0;i<Reservations.Count;i++)
            {
                sb.Append("\"r" + Reservations.ElementAt(i).Row + "c" + Reservations.ElementAt(i).Column+"\"");
                if (i < Reservations.Count - 1)
                {
                    sb.Append(',');
                }
            }
            return sb.ToString();
        }
    }
}