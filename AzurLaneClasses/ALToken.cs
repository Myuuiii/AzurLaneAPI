using System;

namespace AzurLaneClasses
{
    public class ALToken
    {
        public Guid Id { get; set; }
        public String Email { get; set; }
        public String Token { get; set; }
        public Boolean Active { get; set; }
        public Boolean WriteGrant { get; set; }
    }
}