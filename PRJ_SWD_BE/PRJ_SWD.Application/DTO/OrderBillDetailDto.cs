namespace PRJ_SWD.Application.DTO
{
    public class OrderBillDetailDto
    {
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; } // optional nếu bạn muốn include sau
        public int TotalAmount { get; set; }
        public int PaymentMethod { get; set; }

        public int ReservationId { get; set; }
        public DateOnly ReservationDate { get; set; }

        public int ScheduleId { get; set; }
        public string? ScheduleDescription { get; set; }

        // Optional: list of services/prescriptions nếu cần
        public List<string>? Services { get; set; }
        public List<string>? Prescriptions { get; set; }
    }
}
