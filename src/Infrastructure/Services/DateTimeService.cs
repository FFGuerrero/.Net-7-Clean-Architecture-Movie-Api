﻿using MovieApi.Application.Common.Interfaces;

namespace MovieApi.Infrastructure.Services;
public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}