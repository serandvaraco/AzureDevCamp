using System.ComponentModel.DataAnnotations.Schema;

namespace Blueyonder.Entities
{
    public class Traveler
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TravelerId { get; set; }

        public string TravelerUserIdentity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhone { get; set; }

        public string HomeAddress { get; set; }

        public string Passport { get; set; }

        public string Email { get; set; }
    }
}