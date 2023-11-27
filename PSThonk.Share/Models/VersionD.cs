using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSThonk.Share.Models
{
    public class VersionD
    {
        public int Id { get; set; }

        public DateTime UpdateTime { get; set; } = DateTime.Now;

        [Column(TypeName = "nvarchar(100)")]
        public string FilePath { get; set; }

        public double VersionIdx { get; set; }
    }
}
