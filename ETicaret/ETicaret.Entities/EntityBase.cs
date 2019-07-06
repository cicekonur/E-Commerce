using CommonType.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entities
{
    public class EntityBase :IEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}
