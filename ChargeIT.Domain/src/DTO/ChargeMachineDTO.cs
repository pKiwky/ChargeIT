namespace ChargeIT.Domain.DTO {

    public class ChargeMachineDTO {
        public int Id { get; set; }
        public int Number { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

}