﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonisshoniZ.Data
{
    public class PCLMatch
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime MatchStartDate { get; set; } // 比赛日期

        [DataType(DataType.Date)]
        public DateTime MatchEndDate { get; set; }

        public MatchStatus MatchStatus { get; set; } // 是否正在举办
        public MatchType MatchType { get; set; } // 比赛类型 可能改成枚举类型
        public bool IsOnline { get; set; } // 是否是线上赛


        [Column(TypeName = "nvarchar(200)")]
        public string Logo { get; set; } = string.Empty;
        /// <summary>
        /// 是否有使用率
        /// </summary>
        public bool HasUsage { get; set; }
        /// <summary>
        /// 是否允许游客
        /// </summary>
        public bool AllowGuest { get; set; }

        /// <summary>
        /// 当前游客数+1
        /// </summary>
        public int GuestId { get; set; } = 1;


        public bool IsTeamCompeition { get; set; } = false;
        public int TeamNumberLimit { get; set; } = 5;

        public int MaxPlayerNumber { get; set; } = 9999;
        public bool NotShow { get; set; } = false;

        [Timestamp]
        public byte[] ConcurrencyToken { get; set; }
    }

    public enum MatchType
    {
        Single,
        Double,
    }

    public enum MatchStatus
    {
        Registering,
        Running,
        Finished
    }

}
