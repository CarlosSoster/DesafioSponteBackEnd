using Flunt.Notifications;
using Flunt.Validations;

namespace SponteBackEnd.ViewModels.ProductViewModels
{
    public class EditorProductViewModel : Notifiable, IValidatable
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Imagem { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(Titulo, 100, "Titulo", "O título deve conter até 120 caracteres")
                    .HasMinLen(Titulo, 3, "Titulo", "O título deve conter pelo menos 3 caracteres")
                    .IsGreaterThan(Valor, 0, "Valor", "O valor deve ser maior que zero")
            );
        }
    }
}