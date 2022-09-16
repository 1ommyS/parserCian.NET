using System;
using System.Text;
using ParserServer.Parser.Models;

namespace ParserServer.Services
{
    public class OfferService
    {
        public String GetRailways(Offer currentOffer)
        {
            var railways = new StringBuilder();

            if (currentOffer.Geo.Railways != null)
            {
                foreach (var currentOfferRailway in currentOffer.Geo.Railways)
                {
                    railways.Append($"{currentOfferRailway.Name} в {currentOfferRailway.Time} минутах, ");
                }
            }
            else
            {
                railways = new StringBuilder("Нет метро рядом");
            }

            return railways.ToString();
        }
    }
}