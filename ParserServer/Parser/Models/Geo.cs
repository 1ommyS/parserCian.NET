using System.Collections.Generic;

namespace ParserServer.Parser.Models
{
    public class Geo
    {
        public string? UserInput { get; set; }
        public List<Railway> Railways { get; set; }
    }
}