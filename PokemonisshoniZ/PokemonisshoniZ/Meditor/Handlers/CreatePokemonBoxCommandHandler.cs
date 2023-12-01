using MediatR;
using PokemonisshoniZ.Data;
using PokemonisshoniZ.Meditor.Commands;

namespace PokemonisshoniZ.Meditor.Handlers
{
    public class CreatePokemonBoxCommandHandler(ApplicationDbContext dbContext) : IRequestHandler<CreatePokemonBoxCommand, PCLPokemonBox[]>
    {
        public async Task<PCLPokemonBox[]> Handle(CreatePokemonBoxCommand request, CancellationToken cancellationToken)
        {
            var cnt = dbContext.PCLPokemonBoxes.Where(s => s.UserId == request.userId).Count();

            PCLPokemon[] pCLPokemons = new PCLPokemon[cnt * 30];
            for (int i = 0; i < pCLPokemons.Length; i++)
            {
                pCLPokemons[i] = new() { UserId = request.userId };
            }
            dbContext.PCLPokemons.AddRange(pCLPokemons);
            await dbContext.SaveChangesAsync();

            IEnumerable<PCLPokemonBox> pCLPokemonBoxes = Enumerable.Range(cnt, request.cnt).Select(s => new PCLPokemonBox { BoxIdx = s, Name = $"箱子{s + 1}", UserId = request.userId, PCLPokemonIds = pCLPokemonBoxes.Skip(s * 30).Take(30).Select(s => s.Id).ToArray()});
            dbContext.PCLPokemonBoxes.AddRange(pCLPokemonBoxes);
            await dbContext.SaveChangesAsync();
            return pCLPokemonBoxes.ToArray();
        }
    }
}
