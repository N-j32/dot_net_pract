using System.ComponentModel.DataAnnotations;

namespace First.Models
{
    public class Category
    {
        //data annotation for adding validation
        [Key]

        public int Id{ get; set; }
        [Required]
        public string Name{ get; set; }
        public int DispalyOrder { get; set; }
        public DateTime CreateDateTime { get; set; }= DateTime.Now;

    }
}
