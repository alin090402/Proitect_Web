﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WorkForever.Models.Base;
using WorkForever.Models.Enums;

namespace WorkForever.Models;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseEntity
{
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;
    public double WorkExperience { get; set; } = 1;

    public double Money { get; set; } = 0;
    public List<Factory> Factories { get; set; } 
    public List<UserItem> UserItems { get; set; }
    public DateTime? LastWorked { get; set; }
    public List<WorkRecord> WorkRecords { get; set; }
    
    public InfoUser InfoUser { get; set; }
    
}