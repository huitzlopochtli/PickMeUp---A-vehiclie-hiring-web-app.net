using PickMeUp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PickMeUp.Models.Admin
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {

        }
        public RoleViewModel(Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string Name { get; set; }
    }
}