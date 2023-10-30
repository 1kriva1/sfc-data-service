﻿using SFC.Data.Application.Interfaces.Common;

namespace SFC.Data.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;
}
