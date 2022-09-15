namespace ParserServer.Parser.Models
{
    public class Railway
    {
        /*
         * "id": 701,
                    "name": "Электрозаводская",
                    "time": 5,
                    "travelType": "byCar",
         */
        public int? Name { get; set; }
        public int? Time { get; set; }
        public string? TravelType { get; set; }
    }
}