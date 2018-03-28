using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Qbg.Data.Bases
{
    public class EnumBase<TEnum> where TEnum : struct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public virtual string Name { get; set; }

        [MaxLength(100)]
        public virtual string Description { get; set; }
    }
}
