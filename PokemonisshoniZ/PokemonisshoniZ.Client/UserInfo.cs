using System.Security.Claims;

namespace PokemonisshoniZ.Client;

// Add properties to this class and update the server and client AuthenticationStateProviders
// to expose more information about the authenticated user to the client.
public class UserInfo
{
    public required string UserId { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }


    ////[PersonalData]
    //public string NickName { get; set; } = string.Empty// 昵称
    ////[PersonalData]
    //public DateTime DOB { get; set; } // 生日

    ////[PersonalData]
    //public string City { get; set; } // 城市
    ////[PersonalData]
    //public string HomeName { get; set; } // 剑盾游戏名字
    //                                     //[PersonalData]
    //                                     //public DateTime DOB { get; set; } // 生日
    //                                     // QQ
    ////[PersonalData]
    //public string QQ { get; set; } // QQ

    ////[PersonalData]
    //public DateTime Registertime { get; set; } // 注册时间


    //public string Avatar { get; set; } = "Upload/ztxb.jpeg"; // QQ


    //public int TrainerId { get; set; }


    //public int GSNum { get; set; }
}
