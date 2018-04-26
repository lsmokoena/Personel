using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Base : IEntity
    {
        private EntityState _entity_state;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public bool? Active { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [NotMapped]
        public EntityState entity_state
        {
            get { return _entity_state; }

            set
            {
                if (value == EntityState.Added)
                {
                    DateModified = DateTime.UtcNow;
                    DateCreated = DateTime.UtcNow;
                    Active = true;
                }
                else if (value == EntityState.Modified)
                {
                    DateModified = DateTime.UtcNow;
                }
                else if (value == EntityState.Deleted)
                {
                    DateModified = DateTime.UtcNow;
                    Active = false;
                }
                _entity_state = value;
            }
        }
    }
}
