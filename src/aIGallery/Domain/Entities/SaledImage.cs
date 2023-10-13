using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SaledImage : Entity<Guid>
{
    public int UserId { get; set; }
    public int ImageId { get; set; }

    public virtual User? User { get; set; }
    public virtual Image? Image { get; set; }
}
