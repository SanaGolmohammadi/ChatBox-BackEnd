﻿using Microsoft.EntityFrameworkCore;

namespace ChatBox.Models
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) { }
        public DbSet<Message> Messages => Set<Message>();
    }
}
