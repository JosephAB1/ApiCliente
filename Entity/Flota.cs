using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Entity
{
    public class Flota
    {
        [Key]
        public int id { get; set; }
        public string tipo_flota { get; set; }
        public string desc_flota { get; set; }
        public string img_flota { get; set; }
        public int marcaId { get; set; }
        public Marca marca { get; set; }
    }
}
