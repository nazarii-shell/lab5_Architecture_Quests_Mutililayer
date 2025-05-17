using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess;

public class QuestsContext : DbContext
{
    public DbSet<Quest> Quests { get; set; }
    public DbSet<Availability> Availabilities { get; set; }

    public string DbPath { get; }

    public QuestsContext()
    {
        DbPath = "/Users/nazariypoptsov/Documents/NAU/2_course/2_semester/Архітектура/5/lab5/DataAccess/blogging.db";
    }
    
    

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}