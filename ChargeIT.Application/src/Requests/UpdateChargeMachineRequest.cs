namespace ChargeIT.Application.Requests {

    public class UpdateChargeMachineRequest {
        public int Number { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }

}