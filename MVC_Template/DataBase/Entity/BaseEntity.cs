using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Template.DataBase.Entity
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
