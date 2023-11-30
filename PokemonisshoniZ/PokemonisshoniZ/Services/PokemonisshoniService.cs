namespace PokemonisshoniZ.Services
{
    public class PokemonisshoniService(
        PokeCommonService pokeCommonService,
        PokemonHomeService pokemonHomeService,
        PokeOCRService pokeOCRService,
        PSThonkService pSThonkService
        )
    {
        public PokeCommonService PokeCommonService { get; } = pokeCommonService;
        public PokemonHomeService PokemonHomeService { get; } = pokemonHomeService;
        public PokeOCRService PokeOCRService { get; } = pokeOCRService;
        public PSThonkService PSThonkService { get; } = pSThonkService;
    }
}
