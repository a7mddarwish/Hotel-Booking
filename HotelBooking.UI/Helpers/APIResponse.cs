namespace HotelBooking.UI.Helpers
{
    public class APIResponse<T>
    {
        public bool Success {  get; set; }
        public  string? Message { get; set; }
        public  T? Result { get; set; } = default(T?);
        public  List<ErrorDetail>? Errors { get; set; }

    }
    public class ErrorDetail
    {
        public string Field { get; set; } //Error in property
        public string Message { get; set; }
    }
}
