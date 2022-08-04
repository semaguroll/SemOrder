using SemOrder.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SemOrder.WEB.UI.Areas.Admin.Models.ReservationViewModels
{
    public class CreateReservationViewModel
    {
        public Status Status { get; set; }

        [Display(Name = "Rezervasyon Mesajınız")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Reservasyon tarihi girilmesi zorunludur.")]
        [Display(Name = "Rezervasyon Tarihi")]
        public DateTime ReservationDate { get; set; }

        [Required(ErrorMessage = "Reservasyon saati girilmesi zorunludur.")]
        [Display(Name = "Rezervasyon Saati")]
        public string ReservationTime { get; set; }

        [Required(ErrorMessage = "Kişi sayısı girilmesi zorunludur.")]
        [Display(Name = "Kişi Sayısı")]
        public int NumberOfPerson { get; set; }

        public Guid UserId { get; set; }
        public Guid TableId { get; set; }
    }
}
