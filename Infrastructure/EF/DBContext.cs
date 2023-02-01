using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class DBContext : DbContext
{
    private readonly IConnectionStringProvider _connectionStringProvider;

    public DBContext(IConnectionStringProvider connectionStringProvider)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public DbSet<DbTravails> Travails { get; set; }
    public DbSet<DbHoraires> Horaires { get; set; }
    public DbSet<DbPrestations> Prestations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionStringProvider.GetConnectionString("Db"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbTravails>(entity =>
        {
            entity.ToTable("Travails");
            entity.HasKey(travails => travails.Id);
            entity.Property(travails => travails.Id).HasColumnName("id");
            entity.Property(travails => travails.Travail).HasColumnName("travail");
            entity.Property(travails => travails.SalaireBrut).HasColumnName("salaire_brut");
            entity.Property(travails => travails.SalaireNet).HasColumnName("salaire_net");
        });
        modelBuilder.Entity<DbHoraires>(entity =>
        {
            entity.ToTable("Horaires");
            entity.HasKey(horaires => horaires.Id);
            entity.Property(horaires => horaires.Id).HasColumnName("id");
            entity.Property(horaires => horaires.Ordre).HasColumnName("ordre");
            entity.Property(horaires => horaires.Travail).HasColumnName("travail");
            entity.Property(horaires => horaires.Debut).HasColumnName("debut");
            entity.Property(horaires => horaires.Fin).HasColumnName("fin");
            entity.Property(horaires => horaires.Duree).HasColumnName("duree");
        });
        modelBuilder.Entity<DbPrestations>(entity =>
        {
            entity.ToTable("Prestations");
            entity.HasKey(prestations => prestations.Id);
            entity.Property(prestations => prestations.Id).HasColumnName("id");
            entity.Property(prestations => prestations.Date).HasColumnName("date");
            entity.Property(prestations => prestations.Travail).HasColumnName("travail");
            entity.Property(prestations => prestations.Horaire).HasColumnName("horaire");
            entity.Property(prestations => prestations.SalaireNet).HasColumnName("salaire_net");
        });
    }
}