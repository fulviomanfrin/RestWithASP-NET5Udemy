using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Model
{
    //sintaxe que relaciona o nome dos campos no modelo e no DB em caso de nomes diferentes.
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }
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
