﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services
{
    public interface ITaxiService
    {
        Task<IEnumerable<Taxi>> ListAsync();
    }
}