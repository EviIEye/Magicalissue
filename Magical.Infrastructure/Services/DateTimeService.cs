﻿using Magical.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magical.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now { get => DateTime.Now; }

    }
}
