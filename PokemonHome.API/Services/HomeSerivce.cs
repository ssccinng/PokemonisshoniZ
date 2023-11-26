using MySqlX.XDevAPI;
using PokeCommon.Models;
using PokeCommon.PokemonHome;

namespace PokemonHome.API.Services
{
    public class HomeSerivce
    {
        static PKHomeUtils PKHomeUtils { get; set; } = new PKHomeUtils();
        public List<SVPokemonHomeSession> Sessions { get; set; } = [];
        public Dictionary<string, List<SVPokemonHomeTrainerRankData>> TrainRanks { get; set; } = [];

        public async Task UpdateSession()
        {
            Sessions = await PKHomeUtils.GetSVPokemonHomeSessionsAsync();
            var lastDouble = Sessions.Last(s => s.Type == PokeCommon.BattleEngine.BattleType.Double);
            var lastSingle = Sessions.Last(s => s.Type == PokeCommon.BattleEngine.BattleType.Single);
            TrainRanks[lastDouble.SeasonId] = await PKHomeUtils.GetSVTrainerDataAsync(lastDouble, 1);
            TrainRanks[lastSingle.SeasonId] = await PKHomeUtils.GetSVTrainerDataAsync(lastSingle, 1);
        }

        public async Task FetchPreviewSessionTrainerData(string sessionId)
        {
            var session = Sessions.FirstOrDefault(s => s.SeasonId == sessionId);
            if (session == null) return;

            TrainRanks[sessionId] = await PKHomeUtils.GetSVTrainerDataAsync(session, -1);
        }

    }
}
