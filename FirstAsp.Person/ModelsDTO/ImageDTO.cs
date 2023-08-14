using FirstAspPerson.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstAspPerson.ModelsDTO
{
    public class CreateImageDTO
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string File { get; set; }


        [Required]
        //[ForeignKey(nameof(Person))]
        public int PersonId { get; set; }


    }
    public class ImageDTO:CreateImageDTO
    {
        public int Id { get; set; }
        
        public PersonDTO Person { get; set; }

    }
}
