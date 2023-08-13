using FirstAspPerson.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAspPerson.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string File { get; set; }


        //[ForeignKey(nameof(Person))]
        public int PersonId { get; set; }

        //it can be virtual
        public Person Person { get; set; }
    }
}
