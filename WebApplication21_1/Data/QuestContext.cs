using Microsoft.EntityFrameworkCore;
using WebApplication21_1.Models;

namespace WebApplication21_1.Data
{
    public class QuestContext:DbContext
    {
        public DbSet<Quest> Quests { get; set; }
        public QuestContext(DbContextOptions<QuestContext> options) : base(options)
        {

        }
    }
}
