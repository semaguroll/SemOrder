using SemOrder.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.ReservationViewModels
{
    public class ReservationViewModel
    {
        [Display(Name = "Rezervasyon Mesajınız")]
        public string Message { get; set; }

        [Display(Name = "Rezervasyon Tarihi")]
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; }
        public int NumberOfPerson { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid TableId { get; set; }
        public Table Table { get; set; }
    }
}
