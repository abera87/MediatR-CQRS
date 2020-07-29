namespace BackOffice.ViewModel
{
     public partial class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public int? EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string NameWithId { get; set; }
    }
}