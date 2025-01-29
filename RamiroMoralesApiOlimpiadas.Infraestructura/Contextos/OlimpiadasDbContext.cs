using Microsoft.EntityFrameworkCore;
using RamiroMoralesApiOlimpiadas.Entidades.Entidades;


namespace RamiroMoralesApiOlimpiadas.Infraestructura.Contextos
{
    public class OlimpiadasDbContext :DbContext
    {
        public OlimpiadasDbContext()
        {
        }

        public OlimpiadasDbContext(DbContextOptions<OlimpiadasDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Categoria> Categorias { get; set; }

        public virtual DbSet<Deportista> Deportistas { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Pai> Pais { get; set; }

        public virtual DbSet<Resultado> Resultados { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=DESKTOP-EKALF78\\SQLSERVERM;Database=Olimpiada;Trusted_Connection=True;Encrypt=false;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("PK__categori__CD54BC5A9447F681");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_categoria");
            });

            modelBuilder.Entity<Deportista>(entity =>
            {
                entity.HasKey(e => e.IdDeportista).HasName("PK__deportis__14D664E1F8598873");

                entity.ToTable("deportistas");

                entity.Property(e => e.IdDeportista).HasColumnName("id_deportista");
                entity.Property(e => e.IdPais).HasColumnName("id_pais");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Deportista)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__deportist__id_pa__3B75D760");

                entity.HasMany(d => d.IdCategoria).WithMany(p => p.IdDeportista)
                    .UsingEntity<Dictionary<string, object>>(
                        "DeportistasCategoria",
                        r => r.HasOne<Categoria>().WithMany()
                            .HasForeignKey("IdCategoria")
                            .HasConstraintName("FK__deportist__id_ca__3F466844"),
                        l => l.HasOne<Deportista>().WithMany()
                            .HasForeignKey("IdDeportista")
                            .HasConstraintName("FK__deportist__id_de__3E52440B"),
                        j =>
                        {
                            j.HasKey("IdDeportista", "IdCategoria").HasName("PK__deportis__A8032F24701EB76E");
                            j.ToTable("deportistas_categorias");
                            j.IndexerProperty<int>("IdDeportista").HasColumnName("id_deportista");
                            j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                        });
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.IdLog).HasName("PK__Log__77CCC3E0EB6EDCB4");

                entity.ToTable("Log");

                entity.Property(e => e.IdLog).HasColumnName("id_Log");
                entity.Property(e => e.DescripcionLog)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("descripcionLog");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais).HasName("PK__pais__0941A3A7F64A9ED0");

                entity.ToTable("pais");

                entity.Property(e => e.IdPais).HasColumnName("id_pais");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.IdResultado).HasName("PK__resultad__33A42B300CAE8542");

                entity.ToTable("resultados");

                entity.Property(e => e.IdResultado).HasColumnName("id_resultado");
                entity.Property(e => e.Anio).HasColumnName("anio");
                entity.Property(e => e.Evento)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("evento");
                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
                entity.Property(e => e.IdDeportista).HasColumnName("id_deportista");
                entity.Property(e => e.PesoLevantado)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("peso_levantado");

                entity.HasOne(d => d.IdDeportistaNavigation).WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdDeportista)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__resultado__id_de__4222D4EF");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__8E901EAAD39103DD");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("id_Usuario");
                entity.Property(e => e.Clave)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("clave");
                entity.Property(e => e.Usuario1)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });


            // OnModelCreatingPartial(modelBuilder);
        }

        // public void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
