using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_Actor { get; set; }

        [Display(Name = "Name"), Required(ErrorMessage = "Campo requerido!")]
        public string Name { get; set; }
    }
}
