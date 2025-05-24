using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EventosUTN.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Ponente> Ponentes { get; set; }
        public DbSet<EventoPonente> EventoPonentes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Sesiones)
            .WithOne(s => s.Evento)
            .HasForeignKey(s => s.EventoId);

        modelBuilder.Entity<Sesion>()
            .HasOne(s => s.Sala)
            .WithMany(sala => sala.Sesiones)
            .HasForeignKey(s => s.SalaId);

        modelBuilder.Entity<Participante>()
            .HasMany(p => p.Inscripciones)
            .WithOne(i => i.Participante)
            .HasForeignKey(i => i.ParticipanteId);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Inscripciones)
            .WithOne(i => i.Evento)
            .HasForeignKey(i => i.EventoId);

        modelBuilder.Entity<Inscripcion>()
            .HasMany(i => i.Pagos)
            .WithOne(p => p.Inscripcion)
            .HasForeignKey(p => p.InscripcionId);

        modelBuilder.Entity<Pago>()
            .Property(p => p.Monto)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Certificado)
            .WithOne(c => c.Inscripcion)
            .HasForeignKey<Certificado>(c => c.InscripcionId);

        modelBuilder.Entity<EventoPonente>()
            .HasKey(ep => new { ep.EventoId, ep.PonenteId });

        modelBuilder.Entity<EventoPonente>()
            .HasOne(ep => ep.Evento)
            .WithMany(e => e.EventoPonentes)
            .HasForeignKey(ep => ep.EventoId);

        modelBuilder.Entity<EventoPonente>()
            .HasOne(ep => ep.Ponente)
            .WithMany(p => p.EventoPonentes)
            .HasForeignKey(ep => ep.PonenteId);
    }

}
