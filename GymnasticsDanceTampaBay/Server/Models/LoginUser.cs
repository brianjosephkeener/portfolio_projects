using System;
using Server.Models;
using System.ComponentModel.DataAnnotations;
public class LoginUser
{
    [Required]
    public string Username {get; set;}
    [Required]
    public string Password { get; set; }
}

