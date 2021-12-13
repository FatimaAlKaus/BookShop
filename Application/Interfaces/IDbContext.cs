﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<User> Users { get; set; }

        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Authors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
