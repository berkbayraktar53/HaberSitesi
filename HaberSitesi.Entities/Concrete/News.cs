using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSitesi.Entities.Concrete
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }

        [StringLength(500)]
        public string NewsTitle { get; set; }

        public string NewsContent { get; set; }

        [StringLength(500)]
        public string NewsImage { get; set; }

        public DateTime NewsDate { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}