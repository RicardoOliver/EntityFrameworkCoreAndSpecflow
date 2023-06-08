using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Cliente" no banco de dados
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        //Nome
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string? Nome { get; set; }

        //Email
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage =
            "O Email deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "O Numero do celluar é Obrigatório.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Introduza um número de telefone válido.")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Digite o Endereço")]
        public string? Endereco { get; set; }
    }
}
