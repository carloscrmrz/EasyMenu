using System.ComponentModel.DataAnnotations;

namespace EasyMenu.Portal.Models;

public class Credentials
{
    [Required] public string UserLogin { get; set; }
    [Required] public string UserPass { get; set; }
}