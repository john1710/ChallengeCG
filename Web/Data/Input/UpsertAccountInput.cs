using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.Data.Input
{
    public class UpsertAccountInput
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "campo Origatório *")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O nome precisa estar entre 3 e 20 caracteres")]
        [DisplayName("Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "campo Origatório *")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A descrição precisa estar entre 3 e 100 caracteres")]
        [DisplayName("Descrição")]
        public string? Description { get; set; }
    }
}
