using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    public partial class ContextDB : DbContext
    {
        public ContextDB()
        {
        }

        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        public virtual DbSet<Abastecimento> Abastecimento { get; set; }
        public virtual DbSet<ConsumivelVeicular> ConsumivelVeicular { get; set; }
        public virtual DbSet<Credito> Credito { get; set; }
        public virtual DbSet<Frota> Frota { get; set; }
        public virtual DbSet<Motoristas> Motoristas { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<ProximasTrocas> ProximasTrocas { get; set; }
        public virtual DbSet<RegistroSaidas> RegistroSaidas { get; set; }
        public virtual DbSet<RelatorioMecanico> RelatorioMecanico { get; set; }
        public virtual DbSet<Rota> Rota { get; set; }
        public virtual DbSet<RotaFrota> RotaFrota { get; set; }
        public virtual DbSet<Solicitacao> Solicitacao { get; set; }
        public virtual DbSet<SolicitacoesManutencao> SolicitacoesManutencao { get; set; }
        public virtual DbSet<TiposManutencao> TiposManutencao { get; set; }
        public virtual DbSet<Transacao> Transacao { get; set; }
        public virtual DbSet<Unidades> Unidades { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Veiculos> Veiculos { get; set; }
        public virtual DbSet<Viagem> Viagem { get; set; }
        public virtual DbSet<Vistorias> Vistorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abastecimento>(entity =>
            {
                entity.ToTable("abastecimento", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MotoristaId)
                    .HasName("fk_ABASTECIMENTO_MOTORISTA1_idx");

                entity.HasIndex(e => e.VeiculoId)
                    .HasName("fk_ABASTECIMENTO_VEICULO1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abastecimentocol)
                    .HasColumnName("ABASTECIMENTOcol")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.LeituraOdometro).HasColumnName("LEITURA_ODOMETRO");

                entity.Property(e => e.LitrosAbastecidos).HasColumnName("LITROS_ABASTECIDOS");

                entity.Property(e => e.MotoristaId)
                    .HasColumnName("MOTORISTA_ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.VeiculoId)
                    .HasColumnName("VEICULO_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Motorista)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.MotoristaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ABASTECIMENTO_MOTORISTA1");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.Abastecimento)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ABASTECIMENTO_VEICULO1");
            });

            modelBuilder.Entity<ConsumivelVeicular>(entity =>
            {
                entity.ToTable("consumivel_veicular", "bd_quero_transporte");

                entity.HasIndex(e => e.IdVeiculo)
                    .HasName("fk_TB_CONSUMIVEL_VEICULAR_TB_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataDespesa)
                    .HasColumnName("DATA_DESPESA")
                    .HasColumnType("date");

                entity.Property(e => e.IdVeiculo)
                    .HasColumnName("ID_VEICULO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Valor).HasColumnName("VALOR");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.ConsumivelVeicular)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_CONSUMIVEL_VEICULAR_TB_VEICULO1");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.ToTable("credito", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_CREDITO_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Saldo)
                    .HasColumnName("SALDO")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Credito)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CREDITO_USUARIO1");
            });

            modelBuilder.Entity<Frota>(entity =>
            {
                entity.ToTable("frota", "bd_quero_transporte");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

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

            modelBuilder.Entity<Motoristas>(entity =>
            {
                entity.ToTable("motoristas", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TB_MOTORISTA_TB_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasColumnName("CATEGORIA")
                    .HasColumnType("char(2)");

                entity.Property(e => e.Cnh)
                    .IsRequired()
                    .HasColumnName("CNH")
                    .HasColumnType("char(15)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Validade)
                    .HasColumnName("VALIDADE")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Motoristas)
                    .HasForeignKey(d => d.IdUsuario)
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
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Data).HasColumnName("DATA");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasColumnType("enum('A VISTA','CREDITOS')");
            });

            modelBuilder.Entity<ProximasTrocas>(entity =>
            {
                entity.ToTable("proximas_trocas", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RelatorioMecanicoId)
                    .HasName("fk_PROXIMAS_TROCAS_RELATORIO_MECANICO1_idx");

                entity.HasIndex(e => e.VeiculosId)
                    .HasName("fk_PROXIMAS_TROCAS_VEICULOS1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Especificacao)
                    .HasColumnName("ESPECIFICACAO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.KmProximaTroca)
                    .HasColumnName("KM_PROXIMA_TROCA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RelatorioMecanicoId).HasColumnName("RELATORIO_MECANICO_ID");

                entity.Property(e => e.VeiculosId)
                    .HasColumnName("VEICULOS_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.RelatorioMecanico)
                    .WithMany(p => p.ProximasTrocas)
                    .HasForeignKey(d => d.RelatorioMecanicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PROXIMAS_TROCAS_RELATORIO_MECANICO1");

                entity.HasOne(d => d.Veiculos)
                    .WithMany(p => p.ProximasTrocas)
                    .HasForeignKey(d => d.VeiculosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PROXIMAS_TROCAS_VEICULOS1");
            });

            modelBuilder.Entity<RegistroSaidas>(entity =>
            {
                entity.ToTable("registro_saidas", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MotoristaId)
                    .HasName("fk_REGISTRO_SAIDAS_MOTORISTA1_idx");

                entity.HasIndex(e => e.VeiculoId)
                    .HasName("fk_REGISTRO_SAIDAS_VEICULO1_idx");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioRetorno).HasColumnName("HORARIO_RETORNO");

                entity.Property(e => e.HorarioSaida).HasColumnName("HORARIO_SAIDA");

                entity.Property(e => e.LeituraOdometroFinal).HasColumnName("LEITURA_ODOMETRO_FINAL");

                entity.Property(e => e.LeituraOdometroInicial).HasColumnName("LEITURA_ODOMETRO_INICIAL");

                entity.Property(e => e.MotoristaId)
                    .HasColumnName("MOTORISTA_ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.VeiculoId)
                    .HasColumnName("VEICULO_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Motorista)
                    .WithMany(p => p.RegistroSaidas)
                    .HasForeignKey(d => d.MotoristaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_REGISTRO_SAIDAS_MOTORISTA1");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.RegistroSaidas)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_REGISTRO_SAIDAS_VEICULO1");
            });

            modelBuilder.Entity<RelatorioMecanico>(entity =>
            {
                entity.ToTable("relatorio_mecanico", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OrdemServico)
                    .HasColumnName("ORDEM_SERVICO")
                    .HasColumnType("blob");

                entity.Property(e => e.ValorPecas)
                    .HasColumnName("VALOR_PECAS")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.ValorServico)
                    .HasColumnName("VALOR_SERVICO")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("VALOR_TOTAL")
                    .HasColumnType("decimal(2,0)");
            });

            modelBuilder.Entity<Rota>(entity =>
            {
                entity.ToTable("rota", "bd_quero_transporte");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

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
            });

            modelBuilder.Entity<RotaFrota>(entity =>
            {
                entity.ToTable("rota_frota", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("fk_TB_FROTA_has_TB_ROTA_TB_FROTA1_idx");

                entity.HasIndex(e => e.IdRota)
                    .HasName("fk_TB_FROTA_has_TB_ROTA_TB_ROTA1_idx");

                entity.HasIndex(e => e.UnidadesId)
                    .HasName("fk_ROTA_FROTA_UNIDADES1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdRota)
                    .HasColumnName("ID_ROTA")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.UnidadesId)
                    .HasColumnName("UNIDADES_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.RotaFrota)
                    .HasForeignKey<RotaFrota>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_FROTA_has_TB_ROTA_TB_FROTA1");

                entity.HasOne(d => d.IdRotaNavigation)
                    .WithMany(p => p.RotaFrota)
                    .HasForeignKey(d => d.IdRota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_FROTA_has_TB_ROTA_TB_ROTA1");

                entity.HasOne(d => d.Unidades)
                    .WithMany(p => p.RotaFrota)
                    .HasForeignKey(d => d.UnidadesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ROTA_FROTA_UNIDADES1");
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.ToTable("solicitacao", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdPagamento)
                    .HasName("fk_SOLICITACAO_PAGAMENTO1_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TB_USUARIO_has_TB_VIAGEM_TB_USUARIO1_idx");

                entity.HasIndex(e => e.IdViagem)
                    .HasName("fk_SOLICITACAO_VIAGEM1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.DataSolicitacao).HasColumnName("DATA_SOLICITACAO");

                entity.Property(e => e.FoiAtentida)
                    .HasColumnName("FOI_ATENTIDA")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IdPagamento)
                    .HasColumnName("ID_PAGAMENTO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdViagem)
                    .HasColumnName("ID_VIAGEM")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.IdPagamentoNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACAO_PAGAMENTO1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_USUARIO_has_TB_VIAGEM_TB_USUARIO1");

                entity.HasOne(d => d.IdViagemNavigation)
                    .WithMany(p => p.Solicitacao)
                    .HasForeignKey(d => d.IdViagem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACAO_VIAGEM1");
            });

            modelBuilder.Entity<SolicitacoesManutencao>(entity =>
            {
                entity.ToTable("solicitacoes_manutencao", "bd_quero_transporte");

                entity.HasIndex(e => e.RelatorioMecanicoId)
                    .HasName("fk_SOLICITACOES_MANUTENCAO_RELATORIO_MECANICO1_idx");

                entity.HasIndex(e => e.TipoManutençãoId)
                    .HasName("fk_SOLICITAR_MANUTENCAO_TIPO_MANUTENÇÃO1_idx");

                entity.HasIndex(e => e.UsuarioId)
                    .HasName("fk_SOLICITACOES_MANUTENCAO_USUARIO1_idx");

                entity.HasIndex(e => e.VeiculoId)
                    .HasName("fk_Solicitação_manutencao_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Arquivo)
                    .HasColumnName("ARQUIVO")
                    .HasColumnType("blob");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LeituraOdometro).HasColumnName("LEITURA_ODOMETRO");

                entity.Property(e => e.NumeroSolicitacao)
                    .HasColumnName("NUMERO_SOLICITACAO")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.RelatorioMecanico)
                    .HasColumnName("RELATORIO_MECANICO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RelatorioMecanicoId).HasColumnName("RELATORIO_MECANICO_ID");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.TipoManutençãoId).HasColumnName("TIPO_MANUTENÇÃO_ID");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("USUARIO_ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.VeiculoId)
                    .HasColumnName("VEICULO_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.RelatorioMecanicoNavigation)
                    .WithMany(p => p.SolicitacoesManutencao)
                    .HasForeignKey(d => d.RelatorioMecanicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACOES_MANUTENCAO_RELATORIO_MECANICO1");

                entity.HasOne(d => d.TipoManutenção)
                    .WithMany(p => p.SolicitacoesManutencao)
                    .HasForeignKey(d => d.TipoManutençãoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITAR_MANUTENCAO_TIPO_MANUTENÇÃO1");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.SolicitacoesManutencao)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_SOLICITACOES_MANUTENCAO_USUARIO1");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.SolicitacoesManutencao)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Solicitação_manutencao_VEICULO1");
            });

            modelBuilder.Entity<TiposManutencao>(entity =>
            {
                entity.ToTable("tipos_manutencao", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tipo)
                    .HasColumnName("TIPO")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.ToTable("transacao", "bd_quero_transporte");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("fk_TB_TRANSACAO_TB_USUARIO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Deferido)
                    .HasColumnName("DEFERIDO")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("ID_USUARIO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.QtdCreditos)
                    .HasColumnName("QTD_CREDITOS")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnName("TIPO")
                    .HasColumnType("enum('PAGAMENTO DE PASSAGEM','COMPRA DE CREDITOS')");

                entity.Property(e => e.Valor)
                    .HasColumnName("VALOR")
                    .HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Transacao)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_TRANSACAO_TB_USUARIO1");
            });

            modelBuilder.Entity<Unidades>(entity =>
            {
                entity.ToTable("unidades", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("idUnidades_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.ArquivoFoto)
                    .HasColumnName("ARQUIVO_FOTO")
                    .HasColumnType("blob");

                entity.Property(e => e.Endereco)
                    .HasColumnName("ENDERECO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUnidade)
                    .HasColumnName("NOME_UNIDADE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaUnidade)
                    .HasColumnName("SIGLA_UNIDADE")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("TELEFONE")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios", "bd_quero_transporte");

                entity.HasIndex(e => e.Cpf)
                    .HasName("CPF_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroMatricula)
                    .HasName("NUMERO_MATRICULA_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UnidadesIdUnidades)
                    .HasName("fk_USUARIO_Unidades1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

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

                entity.Property(e => e.NumeroMatricula)
                    .HasColumnName("NUMERO_MATRICULA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(100)
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

                entity.Property(e => e.UnidadesIdUnidades)
                    .HasColumnName("UNIDADES_ID_UNIDADES")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.UnidadesIdUnidadesNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.UnidadesIdUnidades)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_USUARIO_Unidades1");
            });

            modelBuilder.Entity<Veiculos>(entity =>
            {
                entity.ToTable("veiculos", "bd_quero_transporte");

                entity.HasIndex(e => e.IdFrota)
                    .HasName("fk_TB_VEICULO_TB_FROTA1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

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

                entity.Property(e => e.Capacidade).HasColumnName("CAPACIDADE");

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

                entity.Property(e => e.IdFrota)
                    .HasColumnName("ID_FROTA")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.LeituraOdômetro).HasColumnName("LEITURA_ODÔMETRO");

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

                entity.Property(e => e.NomeclaturaViatura)
                    .HasColumnName("NOMECLATURA_VIATURA")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasColumnName("PLACA")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Renavam)
                    .HasColumnName("RENAVAM")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("STATUS")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ValorVeiculo)
                    .HasColumnName("VALOR_VEICULO")
                    .HasColumnType("decimal(2,0)");

                entity.Property(e => e.VencimentoIpva)
                    .HasColumnName("VENCIMENTO_IPVA")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdFrotaNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdFrota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_VEICULO_TB_FROTA1");
            });

            modelBuilder.Entity<Viagem>(entity =>
            {
                entity.ToTable("viagem", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdRota)
                    .HasName("fk_TB_ROTA_has_TB_VEICULO_TB_ROTA1_idx");

                entity.HasIndex(e => e.IdVeiculo)
                    .HasName("fk_TB_ROTA_has_TB_VEICULO_TB_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.FoiRealizada)
                    .HasColumnName("FOI_REALIZADA")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IdRota)
                    .HasColumnName("ID_ROTA")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.IdVeiculo)
                    .HasColumnName("ID_VEICULO")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Lotacao).HasColumnName("LOTACAO");

                entity.Property(e => e.Preco).HasColumnName("PRECO");

                entity.HasOne(d => d.IdRotaNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.IdRota)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ROTA_has_TB_VEICULO_TB_ROTA1");

                entity.HasOne(d => d.IdVeiculoNavigation)
                    .WithMany(p => p.Viagem)
                    .HasForeignKey(d => d.IdVeiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_TB_ROTA_has_TB_VEICULO_TB_VEICULO1");
            });

            modelBuilder.Entity<Vistorias>(entity =>
            {
                entity.ToTable("vistorias", "bd_quero_transporte");

                entity.HasIndex(e => e.Id)
                    .HasName("ID_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MotoristaId)
                    .HasName("fk_Vistorias_MOTORISTA1_idx");

                entity.HasIndex(e => e.VeiculoId)
                    .HasName("fk_Vistorias_VEICULO1_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Data)
                    .HasColumnName("DATA")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LeituraOdometro).HasColumnName("LEITURA_ODOMETRO");

                entity.Property(e => e.MotoristaId)
                    .HasColumnName("MOTORISTA_ID")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.VeiculoId)
                    .HasColumnName("VEICULO_ID")
                    .HasColumnType("int unsigned");

                entity.HasOne(d => d.Motorista)
                    .WithMany(p => p.Vistorias)
                    .HasForeignKey(d => d.MotoristaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vistorias_MOTORISTA1");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.Vistorias)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Vistorias_VEICULO1");
            });
        }
    }
}
