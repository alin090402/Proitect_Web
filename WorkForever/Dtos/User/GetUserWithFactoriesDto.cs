﻿using WorkForever.Dtos.Factory;

namespace WorkForever.Dtos.User;

public class GetUserWithFactoriesDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public double WorkExperience { get; set; }
    public List<GetFactoryDto> Factories { get; set; } = new List<GetFactoryDto>();
}