using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParserServer.Services;

namespace ParserServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParsingController : ControllerBase
    {
        private readonly ILogger<ParsingController> _logger;
        private readonly ParsingService _service;
        private readonly OfferService _offerService;

        public ParsingController(ILogger<ParsingController> logger, ParsingService service, OfferService offerService)
        {
            _logger = logger;
            _service = service;
            _offerService = offerService;
        }
        
        [HttpGet]
        public async Task<string> Get()
        {
            var allOffers = await _service.getAllOffers();
            
            using (var wbook = new XLWorkbook())
            {
                var ws = wbook.Worksheets.Add("Лист 1");
                ws.Cell("A1").Value = "Ссылка";
                ws.Cell("B1").Value = "Имя";
                ws.Cell("C1").Value = "Номер телефона";
                ws.Cell("D1").Value = "Метро";
                ws.Cell("E1").Value = "Адрес";
                ws.Cell("F1").Value = "Площадь квартиры м²";
                ws.Cell("G1").Value = "Стоимость";
                ws.Cell("H1").Value = "Описание объявления";


                foreach (var offersOnPage in allOffers)
                {
                    var offersOnPageCopy = offersOnPage.ToArray();
                    for (var i = 0; i < offersOnPage.Count; i++)
                    {
                        var currentOffer = offersOnPageCopy[i];
                        var phoneNumber = currentOffer.Phones?[0].CountryCode + currentOffer?.Phones?[0].Number;
                        var railways = _offerService.GetRailways(currentOffer);

                        ws.Cell(i + 2, 1).Value = currentOffer.FullUrl;
                        ws.Cell(i + 2, 2).Value =
                            $"{currentOffer.RoomsCount}-комн. квартира, {currentOffer.TotalArea}м²";
                        ws.Cell(i + 2, 3).Value = $"+{phoneNumber}";
                        ws.Cell(i + 2, 4).Value = railways;
                        ws.Cell(i + 2, 5).Value = currentOffer.Geo?.UserInput;
                        ws.Cell(i + 2, 6).Value = currentOffer.TotalArea;
                        ws.Cell(i + 2, 7).Value = $"{currentOffer.BargainTerms.Price}₽";
                        ws.Cell(i + 2, 8).Value = currentOffer.Description;
                    }
                }

                wbook.SaveAs("simple.xlsx");
            }
            return "Файл загружен на облако";
        }
    }
}