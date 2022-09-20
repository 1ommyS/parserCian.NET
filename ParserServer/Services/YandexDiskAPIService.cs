using System;
using System.Threading;
using System.Threading.Tasks;
using YandexDisk.Client;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;

namespace ParserServer.Services
{
    public class YandexDiskApiService
    {
        public async void UploadExcelFile(string uid)
        {
            string oauthToken = "y0_AgAAAABRUuuOAAhrSwAAAADO_oElWhsk-8nRR42yOAmcLPd9XVUDbQM";

            // Create a client instance
            IDiskApi diskApi = new DiskHttpApi(oauthToken);

            //Upload file from local
            await diskApi.Files.UploadFileAsync(path: $"{uid}.xlsx",
                overwrite: true,
                localFile: $"{uid}.xlsx",
                cancellationToken: CancellationToken.None);
        }
    }
}