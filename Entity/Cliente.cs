using System.ComponentModel.DataAnnotations;

namespace ApiCliente.Entity
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        public string cod_cliente { get; set; }
        public string nom_cliente { get; set; }
        public string ape_cliente { get; set; }
        public string direc_cliente { get; set; }
        public string telef_cliente { get; set; }
        public string correo_cliente { get; set; }
        
        
        public int? marcaId { get; set; }
        public Marca marca { get; set; }

        public int? flotaId { get; set; }
        public Flota flota { get; set; }
    }
}
