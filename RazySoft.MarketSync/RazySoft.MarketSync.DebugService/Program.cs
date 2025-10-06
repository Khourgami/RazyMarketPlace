using Microsoft.Extensions.Logging;
using Moq;
using RazySoft.MarketSync.Api.Services;
using RazySoft.MarketSync.Core.Interfaces;
using RazySoft.MarketSync.Core.Services;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace RazySoft.MarketSync.DebugService
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var storeMock = new Mock<ISyncStore>();
            var apiMock = new Mock<IApiTenant>();
            var mapperMock = new Mock<IMapperService>();
            var validatorMock = new Mock<IValidationService>();
            var loggerMock = new Mock<ILogger<SyncService>>();

            var syncService = new SyncService(
                storeMock.Object,
                apiMock.Object,
                mapperMock.Object,
                validatorMock.Object,
                loggerMock.Object
            );
            await syncService.RunSyncAsync();

        }
    }
}
