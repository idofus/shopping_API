namespace ShoppingAPI.Utils
{
    public class Entity
    {
        public class ResponseObj<T> where T : class
        {
            public int responseCode { get; set; }
            public bool isSuccess { get; set; }
            public object? data { get; set; }
            public string? message { get; set; }
        }
    }
}
