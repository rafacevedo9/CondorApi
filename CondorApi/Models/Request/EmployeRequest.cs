namespace CondorApi.Models.Request
{
    public class EmployeRequest
    {
        public int Id { get; set; }
        public string TypeDocument { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public string Area { get; set; } = null!;
    }
}
