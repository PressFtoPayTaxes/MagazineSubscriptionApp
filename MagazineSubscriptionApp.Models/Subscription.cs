using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscriptionApp.Models
{
    public class Subscription : Entity
    {
        public virtual Client Client { get; set; }
        public DateTime StartDate { get; set; }
        public int SubscriptionTerm { get; set; }
    }
}
