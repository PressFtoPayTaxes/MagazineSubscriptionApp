using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscriptionApp.Models
{
    public abstract class User : Entity
    {
        public string FullName { get; set; }
        public virtual Account Account { get; set; }
    }
}
