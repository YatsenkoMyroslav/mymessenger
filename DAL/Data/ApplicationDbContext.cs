using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMessenger.Models;

namespace DAL.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public virtual DbSet<Chat> Chats { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}