using System.ComponentModel.DataAnnotations;

namespace Caixai.Web2.Data
{
    public class Aluno
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display (Name = "Turma")]
        public Guid? TurmaId { get; set; }
        public Turma? Turma { get; set; }
    }
}
