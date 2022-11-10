using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        /*for audit and common  fields to prevent repetition across domain  entities
        made it abstract so it doesnt need to be instatiated on its own but rather inherited by the domain  entities */
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
