using MediatR;
using PokemonisshoniZ.Data;

namespace PokemonisshoniZ.Meditor.Commands
{
    public record CreatePokemonBoxCommand(string userId, int cnt): IRequest<PCLPokemonBox[]>;
}
