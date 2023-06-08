using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarbeariaDomain.Entities
{
    // Classe que representa a tabela "Agendamento" no banco de dados
    [Table("Agendamento")]
    public class Agendamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgendamentoId { get; set; }


        [Display(Name = "Horário Entrada")]
        [Required(ErrorMessage = "Hora invalida")]
        [RegularExpression(@"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$", ErrorMessage = "Formato invalido (HH:MM)")]
        public DateTime DataHora { get; set; }

        //Nome
        [MaxLength(50)]
        [Display(Name = "Nome Completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string? Cliente { get; set; }


        [Required(ErrorMessage = "O Numero do celluar é Obrigatório.")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Introduza um número de telefone válido.")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "Digite o Endereço")]
        public string? Endereco { get; set; }

        
        [Required]
        [MaxLength(255)]
        public string? Descricao { get; set; }
    }
}