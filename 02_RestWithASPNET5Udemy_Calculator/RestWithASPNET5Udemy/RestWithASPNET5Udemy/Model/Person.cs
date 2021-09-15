using RestWithASPNET5Udemy.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5Udemy.Model
{
    //sintaxe que relaciona o nome dos campos no modelo e no DB em caso de nomes diferentes.
    [Table("person")]
    public class Person : BaseEntity
    {
        
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
       

    } 
}
