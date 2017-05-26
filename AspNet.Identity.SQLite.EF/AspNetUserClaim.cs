namespace AspNet.Identity.SQLite.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserClaim
    {
        public long Id { get; set; }

        [StringLength(256)]
        public string ClaimType { get; set; }

        [StringLength(256)]
        public string ClaimValue { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
