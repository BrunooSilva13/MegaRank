using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? PhotoLink { get; set; }
    public int Experience { get; set; }
    public string? SocialMediaLink { get; set; }
    public string? Role { get; set; }
    
    }
}    