using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.Entidad
{
    public class Persona
    {
        public int IdPersona { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "La cédula debe tener 10 caracteres")]
        [SoloNumeros]
        public string Cedula { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        [PrimeraLetraMayuscula]
        public string Apellido { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "El teléfono debe tener 10 caracteres")]
        [SoloNumeros]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La dirección debe tener entre 2 y 50 caracteres")]
        public string Direccion { get; set; }
        public string? EstadoPersona { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public virtual ICollection<FacturaCabecera> FacturaCabecera { get; set; } = new List<FacturaCabecera>();
    }
}
