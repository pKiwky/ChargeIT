using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChargeIT.Domain.Entities {

    [Table("charge_machines")]
    public class ChargeMachineEntity : TrackableEntity {
        [Column("number")]
        public int Number { get; set; }
        
        [Column("longitude")]
        public double Longitude { get; set; }
        
        [Column("latitude")]
        public double Latitude { get; set; }

        [Column("city")]
        [MaxLength(64)]
        public string City { get; set; }

        [Column("street")]
        [MaxLength(128)]
        public string Street { get; set; }
    }

}