using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public static readonly Byte Unknown = 0;
        public static readonly Byte PayAsYouGo = 1;
    }

    enum Membership
    {
        Unknown = 0,
        PayAsYouGo,
        Weekly,
        Monthly,
        Quarterly

    }
}