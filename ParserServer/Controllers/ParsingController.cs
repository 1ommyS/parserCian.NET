using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Jitbit.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParserServer.Parser;
using ParserServer.Parser.Models;
using ParserServer.QueryBuilder;
using ParserServer.QueryBuilder.Models;

namespace ParserServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParsingController : ControllerBase
    {
        private readonly ILogger<ParsingController> _logger;
        private readonly CsvExport _exportCsv;

        public ParsingController(ILogger<ParsingController> logger)
        {
            _logger = logger;
            _exportCsv = new CsvExport();
        }

        [HttpGet]
        public async Task<FileContentResult> Get()
        {
            var cianParser = new HttpCianParser(new HttpClient());
            string queryFlat = CianQueryBuilderFactory.ForFlat()
                .SetDealType(DealType.Sale)
                .SetRegion(Region.Moscow)
                .SetRooms(1, 2, 3)
                .SortBy(SortBy.FirstNewByDate)
                .Page(2)
                .Build();


            var offersOnPage = await cianParser.SetUri(queryFlat).GetOffersOnPage();

            if (offersOnPage == null) return null;

            // var builder = new StringBuilder();
            // builder.AppendLine(
            //     "Ссылка, Имя, Номер телефона, метро, адрес, площадь квартиры, стоимость, описание объявления");


            foreach (var currentOffer in offersOnPage)
            {
                var phoneNumber = currentOffer.Phones?[0].CountryCode + currentOffer?.Phones?[0].Number;
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

                _exportCsv.AddRow();
                _exportCsv["Ссылка"] = currentOffer.FullUrl;
                _exportCsv["Имя"] = currentOffer.Title;
                _exportCsv["Номер телефона"] = $"+{phoneNumber}";
                _exportCsv["Метро"] = railways;
                _exportCsv["Адрес"] = currentOffer.Geo?.UserInput;
                _exportCsv["Площадь квартиры"] = currentOffer.TotalArea;
                _exportCsv["Стоимость"] = $"{currentOffer.BargainTerms.Price}₽";
                _exportCsv["Описание объявления"] = currentOffer.Description;


                // builder.AppendLine(
                // $"{currentOffer.FullUrl}, {currentOffer.Title}, +{phoneNumber}, {railways}, {currentOffer.TotalArea}, {currentOffer.Price}, {currentOffer.Description}");
            }

            return File(Encoding.UTF8.GetBytes(_exportCsv.Export()), "text/csv", "results.csv");

            // return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "flatsinfo.csv");
        }
    }
}