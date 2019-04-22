using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineSubscriptionApp.Models
{
    public class Magazine : Entity
    {
        public DateTime IssueDate { get; set; }
        public int Cost { get; set; }
    }
}
