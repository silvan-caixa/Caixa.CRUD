using System.ComponentModel.DataAnnotations;

namespace Caixai.Web2.Data
{
    public class Turma
    {
        [Display(Name = "Identificação da Turma")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage ="O nome da turma é obrigatório")]
        [MinLength(3, ErrorMessage ="Minímo 3 caracteres")]
        [MaxLength(15, ErrorMessage ="Máximo 15 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O nome da turma é obrigatório")]
        [MinLength(3, ErrorMessage = "Minímo 3 caracteres")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Professor { get; set;}
    }
}
