// using System.Threading.Tasks;
// using ClosedXML.Excel;
// using DocumentFormat.OpenXml.Office2016.Drawing.Charts;
// using Microsoft.Extensions.DependencyInjection;
// using ParserServer.Services;
// using Quartz;
//
// namespace ParserServer.Jobs
// {
//     public class ParsingJob : IJob
//     {
//         private ParsingService _service;
//         private OfferService _offerService;
//         private readonly IServiceScopeFactory serviceScopeFactory;
//
//         public ParsingJob(IServiceScopeFactory serviceScopeFactory)
//         {
//             this.serviceScopeFactory = serviceScopeFactory;
//         }
//
//         /*
//         public async Task Execute(IJobExecutionContext context)
//         {
//             using (var scope = serviceScopeFactory.CreateScope())
//             {
//                 _service = scope.ServiceProvider.GetRequiredService<ParsingService>();
//                 _offerService = scope.ServiceProvider.GetRequiredService<OfferService>();
//         
//                 // var allOffers = await _service.getAllOffers(reg);
//         
//                 using (var wbook = new XLWorkbook())
//                 {
//                     var ws = wbook.Worksheets.Add("Лист 1");
//                     ws.Cell("A1").Value = "Ссылка";
//                     ws.Cell("B1").Value = "Имя";
//                     ws.Cell("C1").Value = "Номер телефона";
//                     ws.Cell("D1").Value = "Метро";
//                     ws.Cell("E1").Value = "Адрес";
//                     ws.Cell("F1").Value = "Площадь квартиры м²";
//                     ws.Cell("G1").Value = "Стоимость";
//                     ws.Cell("H1").Value = "Описание объявления";
//         
//         
//                     foreach (var offersOnPage in allOffers)
//                     {
//                         var offersOnPageCopy = offersOnPage.ToArray();
//                         for (var i = 0; i < offersOnPage.Count; i++)
//                         {
//                             var currentOffer = offersOnPageCopy[i];
//                             var phoneNumber = currentOffer.Phones?[0].CountryCode + currentOffer?.Phones?[0].Number;
//                             var railways = _offerService.GetRailways(currentOffer);
//         
//                             ws.Cell(i + 2, 1).Value = currentOffer.FullUrl;
//                             ws.Cell(i + 2, 2).Value =
//                                 $"{currentOffer.RoomsCount}-комн. квартира, {currentOffer.TotalArea}м²";
//                             ws.Cell(i + 2, 3).Value = $"+{phoneNumber}";
//                             ws.Cell(i + 2, 4).Value = railways;
//                             ws.Cell(i + 2, 5).Value = currentOffer.Geo?.UserInput;
//                             ws.Cell(i + 2, 6).Value = currentOffer.TotalArea;
//                             ws.Cell(i + 2, 7).Value = $"{currentOffer.BargainTerms.Price}₽";
//                             ws.Cell(i + 2, 8).Value = currentOffer.Description;
//                         }
//                     }
//         
//         
//                     var uuid = System.Guid.NewGuid();
//                     var fileName = uuid.ToString();
//                     wbook.SaveAs($"{fileName}.xlsx");
//                 }
//             }
//     }*/
//     }
// }