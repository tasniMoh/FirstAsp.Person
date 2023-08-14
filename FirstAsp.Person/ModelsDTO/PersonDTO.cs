using System.ComponentModel.DataAnnotations;

namespace FirstAspPerson.ModelsDTO
{
    public class CreatePersonDTO
    {

        [Required]
        public int NationalCode { get; set; }


        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Hotel Name Is Too Long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 70, ErrorMessage = "Hotel Name Is Too Long.")]
        public string LastName { get; set; }


    }

    public class PersonDTO:CreatePersonDTO
    {
   
        public IList<ImageDTO> Images { get; set; }


    }
}
