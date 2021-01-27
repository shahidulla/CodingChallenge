using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Web.ViewModels
{
    public class EmployeeViewModel
    {
        public uint Id { get; set; }

        [Required, StringLength(256)]
        public string FirstName { get; set; }

        [Required, StringLength(256)]
        public string LastName { get; set; }

        public string[] DependentFirstName { get; set; }
        public string[] DependentLastName { get; set; }
        public int[] DependentType { get; set; }
    }
}
