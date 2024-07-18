using Microsoft.EntityFrameworkCore;
using Test_Task_Blazor.Data.Entities;

namespace Test_Task_Blazor.Data
{
    public class PurchaseContext : DbContext
    {
        // DbSet-свойства добавляем после описания наших табличных классов, сейчас не нужно
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalMaterial> ProposalMaterials { get; set; }
        // Обязательная настройка конструктора. Конфигуратор в Startup’е использует этот конструктор
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        { }
    }
}
