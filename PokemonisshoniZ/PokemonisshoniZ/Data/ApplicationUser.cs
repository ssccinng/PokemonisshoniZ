using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PokemonisshoniZ.Components.Account.Pages.Manage;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    [Comment("昵称")]
    public string NickName { get; set; } = string.Empty; // 昵称


    /// <summary>
    /// 生日
    /// </summary>
    [PersonalData]
    [Comment("生日")]

    public DateTime DOB { get; set; } // 生日



    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    [Comment("城市")]

    public string City { get; set; } = string.Empty; // 城市

    [PersonalData]
    [Column(TypeName = "varchar(50)")]
    [Comment("游戏名")]

    public string HomeName { get; set; } = string.Empty;// 剑盾游戏名字
                                                        //[PersonalData]
                                                        //public DateTime DOB { get; set; } // 生日
                                                        // QQ
                                                        //[PersonalData]
    [Column(TypeName = "varchar(50)")]
    [Comment("QQ号")]
    public string QQ { get; set; } = string.Empty;// QQ

    [PersonalData]
    [Comment("注册时间")]
    public DateTime Registertime { get; set; } = DateTime.Now; // 注册时间

    [Column(TypeName = "varchar(200)")]
    [Comment("头像")]
    public string Avatar { get; set; } = "Upload/ztxb.jpeg"; // QQ


    [Comment("训练家id")]
    public int TrainerId { get; set; }

    /// <summary>
    /// GS编号
    /// </summary>
    [Comment("GS号")]
    public int GSNum { get; set; } = -1;
}

