﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Persistence
{
    public  class BD_QUERO_TRANSPORTEContext : DbContext
    {
        public BD_QUERO_TRANSPORTEContext()
        {
        }

        public BD_QUERO_TRANSPORTEContext(DbContextOptions<BD_QUERO_TRANSPORTEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsumivelVeicular> ConsumivelVeicular { get; set; }
        public virtual DbSet<Credito> Credito { get; set; }
        public virtual DbSet<Frota> Frota { get; set; }
        public virtual DbSet<Motorista> Motorista { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Rota> Rota { get; set; }
        public virtual DbSet<RotaFrota> RotaFrota { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           /* if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=BD_QUERO_TRANSPORTE");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<ConsumivelVeicular>(entity =>
            {
                entity.ToTable("consumivel_veicular", "bd_quero_transporte");

                entity.HasIndex(e => e.Veiculo)
                    .HasName("fk_TB_CONSUMIVEL_VEICULAR_TB_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataDespesa)
                    .HasColumnName("DATA_DESPESA")
                    .HasColumnType("date");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.Property(e => e.Veiculo)
                    .HasColumnName("VEICULO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.VeiculoNavigation)
                    .WithMany(p => p.ConsumivelVeicular)
                    .HasForeignKey(d => d.Veiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_CONSUMIVEL_VEICULAR_TB_VEICULO1");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.ToTable("credito", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("fk_CREDITO_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Saldo)
                    .HasColumnName("SALDO")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("USUARIO_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Credito)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CREDITO_USUARIO1");
            });

            modelBuilder.Entity<Frota>(entity =>
            {
                entity.ToTable("frota", "bd_quero_transporte");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.EhPublica)
                    .HasColumnName("EH_PUBLICA")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Motorista>(entity =>
            {
                entity.ToTable("motorista", "bd_quero_transporte");

                entity.HasIndex(e => e.Usuario)
                    .HasName("fk_TB_MOTORISTA_TB_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Cnh)
                    .IsRequired()
                    .HasColumnName("CNH")
                    .HasColumnType("char(12)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("USUARIO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Validade)
                    .HasColumnName("VALIDADE")
                    .HasColumnType("date");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Motorista)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_MOTORISTA_TB_USUARIO1");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.ToTable("pagamento", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnName("DATA");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasColumnType("enum('A VISTA','CREDITOS')");
            });

            modelBuilder.Entity<Rota>(entity =>
            {
                entity.ToTable("rota", "bd_quero_transporte");

                entity.HasIndex(e => e.RotaId)
                    .HasName("fk_TB_ROTA_TB_ROTA1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Destino)
                    .IsRequired()
                    .HasColumnName("DESTINO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasColumnName("DIA_SEMANA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EhComposta)
                    .HasColumnName("EH_COMPOSTA")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HorarioChegada).HasColumnName("HORARIO_CHEGADA");

                entity.Property(e => e.HorarioSaida).HasColumnName("HORARIO_SAIDA");

                entity.Property(e => e.Origem)
                    .IsRequired()
                    .HasColumnName("ORIGEM")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RotaId)
                    .HasColumnName("ROTA_ID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RotaNavigation)
                    .WithMany(p => p.InverseRotaNavigation)
                    .HasForeignKey(d => d.RotaId)
                    .HasConstraintName("fk_TB_ROTA_TB_ROTA1");
            });

            modelBuilder.Entity<RotaFrota>(entity =>
            {
                entity.HasKey(e => new { e.Frota, e.Rota });

                entity.ToTable("rota_frota", "bd_quero_transporte");

                entity.HasIndex(e => e.Frota)
                    .HasName("fk_TB_FROTA_has_TB_ROTA_TB_FROTA1_idx");

                entity.HasIndex(e => e.Rota)
                    .HasName("fk_TB_FROTA_has_TB_ROTA_TB_ROTA1_idx");

                entity.Property(e => e.Frota)
                    .HasColumnName("FROTA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rota)
                    .HasColumnName("ROTA")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FrotaNavigation)
                    .WithMany(p => p.RotaFrota)
                    .HasForeignKey(d => d.Frota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_FROTA_has_TB_ROTA_TB_FROTA1");

                entity.HasOne(d => d.RotaNavigation)
                    .WithMany(p => p.RotaFrota)
                    .HasForeignKey(d => d.Rota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_FROTA_has_TB_ROTA_TB_ROTA1");
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Viagem, e.Usuario, e.PagamentoId });

                entity.ToTable("solicitacao", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PagamentoId)
                    .HasName("fk_SOLICITACAO_PAGAMENTO1_idx");

                entity.HasIndex(e => e.Usuario)
                    .HasName("fk_TB_USUARIO_has_TB_VIAGEM_TB_USUARIO1_idx");

                entity.HasIndex(e => e.Viagem)
                    .HasName("fk_SOLICITACAO_VIAGEM1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Viagem)
                    .HasColumnName("VIAGEM")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Usuario)
                    .HasColumnName("USUARIO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PagamentoId)
                    .HasColumnName("PAGAMENTO_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DataSolicitacao).HasColumnName("DATA_SOLICITACAO");

                entity.Property(e => e.FoiAtentida)
                    .HasColumnName("FOI_ATENTIDA")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Pagamento)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.PagamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACAO_PAGAMENTO1");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_USUARIO_has_TB_VIAGEM_TB_USUARIO1");

                entity.HasOne(d => d.ViagemNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.Viagem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACAO_VIAGEM1");
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("transacao", "bd_quero_transporte");

                entity.HasIndex(e => e.Usuario)
                    .HasName("fk_TB_TRANSACAO_TB_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Deferido)
                    .HasColumnName("DEFERIDO")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.QtdCreditos)
                    .HasColumnName("QTD_CREDITOS")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasColumnName("USUARIO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UsuarioNavigation)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.Usuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_TRANSACAO_TB_USUARIO1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario", "bd_quero_transporte");

                entity.HasIndex(e => e.Cpf)
                    .HasName("CPF_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasColumnType("enum('CLIENTE','MOTORISTA','ADMIN','GESTOR')");
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.ToTable("veiculo", "bd_quero_transporte");

                entity.HasIndex(e => e.Frota)
                    .HasName("fk_TB_VEICULO_TB_FROTA1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AnoFabricacao)
                    .IsRequired()
                    .HasColumnName("ANO_FABRICACAO")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AnoModelo)
                    .IsRequired()
                    .HasColumnName("ANO_MODELO")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Capacidade)
                    .HasColumnName("CAPACIDADE")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Chassi)
                    .IsRequired()
                    .HasColumnName("CHASSI")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasColumnName("COR")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataEmplacamento)
                    .HasColumnName("DATA_EMPLACAMENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Frota)
                    .HasColumnName("FROTA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("MARCA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasColumnName("MODELO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.FrotaNavigation)
                    .WithMany(p => p.Veiculo)
                    .HasForeignKey(d => d.Frota)
                    .HasConstraintName("fk_TB_VEICULO_TB_FROTA1");
            });

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.ToTable("viagem", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Rota)
                    .HasName("fk_TB_ROTA_has_TB_VEICULO_TB_ROTA1_idx");

                entity.HasIndex(e => e.Veiculo)
                    .HasName("fk_TB_ROTA_has_TB_VEICULO_TB_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FoiRealizada)
                    .HasColumnName("FOI_REALIZADA")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Lotacao)
                    .HasColumnName("LOTACAO")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Preco).HasColumnName("PRECO");

                entity.Property(e => e.Rota)
                    .HasColumnName("ROTA")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Veiculo)
                    .HasColumnName("VEICULO")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RotaNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.Rota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ROTA_has_TB_VEICULO_TB_ROTA1");

                entity.HasOne(d => d.VeiculoNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.Veiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ROTA_has_TB_VEICULO_TB_VEICULO1");
            });
        }
    }
}