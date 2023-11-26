using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeCommon.Models;
using PokemonHome.API.Services;



namespace PokemonHome.API.Apis
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PKHomeController(HomeSerivce homeSerivce) : ControllerBase
    {
        [HttpGet("Sessions")]
        public List<SVPokemonHomeSession> GetSessions()
        {
            return homeSerivce.Sessions;
        }

        [HttpGet("TrainersRankData/{sessionId}")]
        public async Task<List<SVPokemonHomeTrainerRankData>> GetTrainersRankData(string sessionId) 
        {
            if (homeSerivce.TrainRanks.ContainsKey(sessionId))
            {
                return homeSerivce.TrainRanks[sessionId];
            }
            else
            {
                // 去更新
                await homeSerivce.FetchPreviewSessionTrainerData(sessionId);
                return homeSerivce.TrainRanks[sessionId];
            }
        }

    }
}
