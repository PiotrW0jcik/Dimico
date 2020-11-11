using System;
using System.ComponentModel.DataAnnotations;

namespace Dimico.Server.Data.Base
{
    public interface IEntity
    {
         DateTime CreatedOn { get; set; }

         string CreatedBy { get; set; }

         DateTime? ModifiedOn { get; set; }

         string ModifiedBy { get; set; }
    }
}
