using System.ComponentModel.DataAnnotations;

namespace technical_test_api.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        //Validacion para que diga que es obligatorio y un limite en caso de que se excedan
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public required string Name { get; set; }
        //Validacion para que diga que es obligatorio y que sea un numero validos
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        [Required(ErrorMessage = "El precio es obligatorio.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El precio debe ser un número válido.")]
        public required decimal Price { get; set; } = 0;
        public bool IsActive { get; set; } = true;

    }
}
