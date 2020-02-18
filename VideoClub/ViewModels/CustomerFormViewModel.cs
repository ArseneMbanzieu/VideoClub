using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoClub.Models;

namespace VideoClub.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable< MembershipType> MembershipTypes { get; set; }
        public Customer Customer  { get; set; }
    }
}