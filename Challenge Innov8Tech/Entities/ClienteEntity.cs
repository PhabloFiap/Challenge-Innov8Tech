
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Challenge_Innov8Tech.Entities
{

    [Table("tab_Cliente")]
    public class ClienteEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

      
        public virtual ICollection<RamoEntity>? Ramo { get; set; }




    }
}
