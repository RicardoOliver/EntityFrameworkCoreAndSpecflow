
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Servico" no banco de dados
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicoId { get; set; }

        //Nome
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string? Nome { get; set; }


        [Required]
        [MaxLength(255)]
        public string? Descricao { get; set; }


        [Required]
        [Display(Name = "Preco")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:###,##0.00}")]
        public decimal Preco { get; set; }
    }
}
