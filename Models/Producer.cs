using MVCIntermediate.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MVCIntermediate.Models
{
    public class Producer : IEntityBase
    {

        [Key]
        public int Id { get; set; }

        public string ProfilePicURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public List<Movie> Movies { get; set; }



    }
}
