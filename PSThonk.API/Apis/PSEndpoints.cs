using Microsoft.Extensions.Caching.Memory;
using PokePSCore;
using System.Text.RegularExpressions;

namespace PSThonk.API.Apis
{
    public static class PSEndpoints
    {
        static PSClient pSClient = new("testttt1", "");

        public static void MapPSEndpoints(this IEndpointRouteBuilder routes)
        {
            pSClient.ConnectAsync().Wait();



            var groups = routes.MapGroup("/api/v1/PsThonk");

            groups.MapGet("/GetPSUserRankData/{Id}", async (string Id) =>
            {

                return await pSClient.GetRankAsync(Id);
            })
                .WithName("GetPSUserRankData")
                .WithOpenApi();

            groups.MapGet("/GetUserDetail/{Id}", async (IMemoryCache _memoryCache, string Id) =>
            { 
                //if 
                //await pSClient.GetUserDetails(Id);
            });


        }
    }
}
