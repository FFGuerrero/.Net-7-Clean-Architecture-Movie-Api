﻿namespace MovieApi.Application.Common.Interfaces.Services;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserName { get; }
}