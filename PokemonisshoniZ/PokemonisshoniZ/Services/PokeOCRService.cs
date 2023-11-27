using PokeCommon.Models;

namespace PokemonisshoniZ.Services
{
    public class PokeOCRService(HttpClient httpClient)
    {
        private readonly string remoteServiceBaseUrl = "/api/v1/PokemonImage/";

        public async Task<string> GetImageTeamData(byte[] image, LanguageType languageType)
        {
           
            ByteArrayContent content = new(image);
            return await (await httpClient.PostAsync($"{remoteServiceBaseUrl}GetImageData/{GetLangStr(languageType)}", content)).Content.ReadAsStringAsync();


        }
        public string GetLangStr(LanguageType lang)
        {
            switch (lang)
            {
                case LanguageType.JPN:
                    return "japan";
                case LanguageType.ENG:
                    return "en";

                case LanguageType.FRA:
                    return "french";
                case LanguageType.ITA:
                    return "italian";
                case LanguageType.GER:
                    return "greman";
                case LanguageType.SPA:
                    return "span";
                case LanguageType.CHS:
                    return "ch";
                case LanguageType.CHT:
                    return "chinese_cht";

                default:
                    return "";
            }
        }

    }
}
