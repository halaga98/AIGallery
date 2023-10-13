using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image : Entity<Guid>
    {
        public string ImageUrl { get; set; }
        public string Promt { get; set; }
        public int ArtStyleId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string ImgToImg { get; set; }
        public bool Discover { get; set; }
        public bool SaleStatus { get; set; }
        public int SalePrice { get; set; }
        public bool Blocked { get; set; }

        public virtual User? User { get; set; }
        public virtual ArtStyle? ArtStyle { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Like> Like { get; set; }
    }
}
