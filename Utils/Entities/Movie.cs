using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    [Table("Movie")]
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_Movie { get; set; }

        [Display(Name = "name"), Required(ErrorMessage = "Campo requerido!")]
        public string name { get; set; }

        [Display(Name = "id_category"), Required(ErrorMessage = "Campo requerido Categoria!")]
        public int id_category { get; set; }

        [Display(Name = "year"), Required(ErrorMessage = "Campo requerido añoo!")]
        public int year { get; set; }


    }
}
