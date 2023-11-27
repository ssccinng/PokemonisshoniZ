using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSThonk.Share.Models
{
    public enum BattlePlayer { Player1, Player2 }

    public class PSBattle
    {
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Player1 { get; set; }
        public PSTeam Player1Team { get; set; }
        public string Player1TeamSheet { get; set; } = "";
        public int Player1TeamId { get; set; }
        public int Player1Score { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Player2 { get; set; }
        public PSTeam Player2Team { get; set; }
        public string Player2TeamSheet { get; set; } = "";
        public int Player2TeamId { get; set; }
        public int Player2Score { get; set; }
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string RoomId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Tier { get; set; }
        public DateTime BatteTime { get; set; }
        public DateTime BatteTimeDetail { get; set; }

        public BattlePlayer WhoWin { get; set; }

        [Column(TypeName = "longtext")]
        public string BattleReplay { get; set; }

        [Column(TypeName = "nvarchar(50)")]

        public string Header1 { get; set; } = "";
        [Column(TypeName = "nvarchar(50)")]
        public string Header2 { get; set; } = "";


        /// <summary>
        /// 是否是bo3
        /// </summary>
        public bool IsBo3 { get; set; }

    }
}
