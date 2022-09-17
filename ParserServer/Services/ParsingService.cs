using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ParserServer.Parser;
using ParserServer.Parser.Models;
using ParserServer.QueryBuilder;
using ParserServer.QueryBuilder.Models;

namespace ParserServer.Services
{
    public class ParsingService
    {
        public async Task<List<List<Offer>>> getAllOffers()
        {
            var cianParser = new HttpCianParser(new HttpClient());
            var queryFlat = CianQueryBuilderFactory.ForFlat()
                .SetDealType(DealType.Sale)
                .SetRegion(Region.Moscow)
                .SetRooms(1, 2, 3)
                .SortBy(SortBy.FirstNewByDate);


            var offersOnFirstPage = await cianParser.SetUri(queryFlat.Page(1).Build()).GetOffersOnPage();
            var offersOnSecondPage = await cianParser.SetUri(queryFlat.Page(2).Build()).GetOffersOnPage();
            var offersOnThirdPage = await cianParser.SetUri(queryFlat.Page(3).Build()).GetOffersOnPage();
            var offersOnFourthPage = await cianParser.SetUri(queryFlat.Page(4).Build()).GetOffersOnPage();
            var offersOnFivePage = await cianParser.SetUri(queryFlat.Page(5).Build()).GetOffersOnPage();
            return new List<List<Offer>>()
                {offersOnFirstPage, offersOnSecondPage, offersOnThirdPage, offersOnFourthPage, offersOnFivePage};
        }
        
        
    }
}