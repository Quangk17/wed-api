using System;

namespace Application.ViewModels.BookingDetailDTOs
{

    public class BookingDetailParentCreateDTO
    {
        public bool? IsActive { get; set; }
        public DateTime? Date { get; set; }
        public string? Name { get; set; }
        public float? amountHour { get; set; }
        public int? bookingID { get; set; }
        public int? scheduleID { get; set; }
    }
    public class BookingDetailPermanentCreateDTO
    {
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public int? BookingID { get; set; }
        public int? ScheduleID { get; set; }
    }

    public class BookingDetailDailyCreateDTO
    {
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public int? BookingID { get; set; }
        public int? ScheduleID { get; set; }
    }

    public class BookingDetailFlexibleCreateDTO
    {
        public bool IsActive { get; set; }
        public string? Name { get; set; }
        public float? AmountHour { get; set; }
        public int? BookingID { get; set; }
    }
}
