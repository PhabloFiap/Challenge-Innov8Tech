using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Innov8Tech.Entities
{
    [Table("tab_Ramos")]
    public class RamoEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Column("ClienteId")]
        public int ClienteId { get; set; }
        public virtual ClienteEntity? Cliente { get; set; }

    }
}