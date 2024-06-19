namespace MVC_Template.Models
{
    public class ServiceResult<T>
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }

        public T Result { get; set; }
    }
}
