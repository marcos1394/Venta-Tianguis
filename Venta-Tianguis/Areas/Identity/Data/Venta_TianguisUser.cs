using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Venta_Tianguis.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Venta_TianguisUser class
public class Venta_TianguisUser : IdentityUser
{

    [Required, PersonalData, MaxLength(60)]
    public string? FullName { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();    
}

