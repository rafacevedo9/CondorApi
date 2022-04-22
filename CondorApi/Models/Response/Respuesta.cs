namespace CondorApi.Models.Response
{
    public class Respuesta<T>
    {
        public int Success { get; set; }
        public string Message { get; set; } = null!;
        public T Data { get; set; } 

        public Respuesta()
        {
            this.Success = 0;
        }

    }
}
