using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Entity
{
    public class Marca
    {
        [Key]
        public int id { get; set; }
        public string nom_marca { get; set; }

    }
}
