﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class SiCAEContext : DbContext
    {
        public SiCAEContext()
        {
        }

        public SiCAEContext(DbContextOptions<SiCAEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<Alunoaula> Alunoaula { get; set; }
        public virtual DbSet<Alunonotificacao> Alunonotificacao { get; set; }
        public virtual DbSet<Alunopessoaresponsavel> Alunopessoaresponsavel { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Boletim> Boletim { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Diahora> Diahora { get; set; }
        public virtual DbSet<Diahoraprofessorturmadisciplina> Diahoraprofessorturmadisciplina { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Escola> Escola { get; set; }
        public virtual DbSet<Notificacao> Notificacao { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoanotificacao> Pessoanotificacao { get; set; }
        public virtual DbSet<Professorturmadisciplina> Professorturmadisciplina { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
        public virtual DbSet<TurmaAluno> TurmaAluno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=sicae");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.IdAluno)
                    .HasName("PRIMARY");

                entity.ToTable("aluno");

                entity.HasIndex(e => e.Cpf)
                    .HasName("cpf_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CertidaoNascimento)
                    .IsRequired()
                    .HasColumnName("certidaoNascimento")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorRaca)
                    .IsRequired()
                    .HasColumnName("corRaca")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.Identidade)
                    .IsRequired()
                    .HasColumnName("identidade")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidade)
                    .IsRequired()
                    .HasColumnName("nacionalidade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nis)
                    .HasColumnName("nis")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSocial)
                    .HasColumnName("nomeSocial")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroImovel)
                    .IsRequired()
                    .HasColumnName("numeroImovel")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProcedenciaEscolar)
                    .IsRequired()
                    .HasColumnName("procedenciaEscolar")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Sus)
                    .IsRequired()
                    .HasColumnName("sus")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Alunoaula>(entity =>
            {
                entity.HasKey(e => new { e.IdAula, e.IdAluno })
                    .HasName("PRIMARY");

                entity.ToTable("alunoaula");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_AlunoAula_Aluno1_idx");

                entity.HasIndex(e => e.IdAula)
                    .HasName("fk_Aula_Aluno_Aula_idx");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.EstaPresente).HasColumnName("estaPresente");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Alunoaula)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoAula_Aluno1");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Alunoaula)
                    .HasForeignKey(d => d.IdAula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aula_Aluno_Aula");
            });

            modelBuilder.Entity<Alunonotificacao>(entity =>
            {
                entity.HasKey(e => new { e.IdAluno, e.IdNotificacao })
                    .HasName("PRIMARY");

                entity.ToTable("alunonotificacao");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_AlunoNotificacao_Aluno1_idx");

                entity.HasIndex(e => e.IdNotificacao)
                    .HasName("fk_AlunoNotificacao_Notificacao1_idx");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdNotificacao).HasColumnName("idNotificacao");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Alunonotificacao)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoNotificacao_Aluno1");

                entity.HasOne(d => d.IdNotificacaoNavigation)
                    .WithMany(p => p.Alunonotificacao)
                    .HasForeignKey(d => d.IdNotificacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoNotificacao_Notificacao1");
            });

            modelBuilder.Entity<Alunopessoaresponsavel>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdAluno })
                    .HasName("PRIMARY");

                entity.ToTable("alunopessoaresponsavel");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_AlunoPessoaResponsavel_Aluno1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_AlunoPessoa_Pessoa1_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasColumnName("parentesco")
                    .HasColumnType("enum('PAI','MAE','AVO','IRMAO','OUTRO')")
                    .HasDefaultValueSql("'PAI'");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Alunopessoaresponsavel)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoPessoaResponsavel_Aluno1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Alunopessoaresponsavel)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoPessoa_Pessoa1");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.HasKey(e => e.IdAula)
                    .HasName("PRIMARY");

                entity.ToTable("aula");

                entity.HasIndex(e => e.IdProfessorTurmaDisciplina)
                    .HasName("fk_Aula_ProfessorTurmaDisciplina1_idx");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.Conteudo)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.IdProfessorTurmaDisciplina).HasColumnName("idProfessorTurmaDisciplina");

                entity.HasOne(d => d.IdProfessorTurmaDisciplinaNavigation)
                    .WithMany(p => p.Aula)
                    .HasForeignKey(d => d.IdProfessorTurmaDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aula_ProfessorTurmaDisciplina1");
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                    .HasName("PRIMARY");

                entity.ToTable("avaliacao");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_Avaliacao_Aluno1_idx");

                entity.HasIndex(e => e.IdProfessorTurmaDisciplina)
                    .HasName("fk_Avaliacao_ProfessorTurmaDisciplina1_idx");

                entity.Property(e => e.IdAvaliacao).HasColumnName("idAvaliacao");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdProfessorTurmaDisciplina).HasColumnName("idProfessorTurmaDisciplina");

                entity.Property(e => e.Nota)
                    .HasColumnName("nota")
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_Aluno1");

                entity.HasOne(d => d.IdProfessorTurmaDisciplinaNavigation)
                    .WithMany(p => p.Avaliacao)
                    .HasForeignKey(d => d.IdProfessorTurmaDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Avaliacao_ProfessorTurmaDisciplina1");
            });

            modelBuilder.Entity<Boletim>(entity =>
            {
                entity.HasKey(e => e.IdBoletim)
                    .HasName("PRIMARY");

                entity.ToTable("boletim");

                entity.HasIndex(e => e.Ano)
                    .HasName("ano_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_Boletim_Aluno1_idx");

                entity.HasIndex(e => e.Semestre)
                    .HasName("semestre_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdBoletim).HasColumnName("idBoletim");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Semestre).HasColumnName("semestre");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Boletim)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Boletim_Aluno1");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.idCidade)
                    .HasName("PRIMARY");

                entity.ToTable("cidade");

                entity.HasIndex(e => e.CodIbge)
                    .HasName("codIBGE_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.idCidade).HasColumnName("idCidade");

                entity.Property(e => e.CodIbge).HasColumnName("codIBGE");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Diahora>(entity =>
            {
                entity.HasKey(e => e.IdDiaHora)
                    .HasName("PRIMARY");

                entity.ToTable("diahora");

                entity.Property(e => e.IdDiaHora).HasColumnName("idDiaHora");

                entity.Property(e => e.DiaSemana)
                    .IsRequired()
                    .HasColumnName("diaSemana")
                    .HasColumnType("enum('SEG','TER','QUA','QUI','SEX','SAB','DOM')");

                entity.Property(e => e.HorarioInicio).HasColumnName("horarioInicio");

                entity.Property(e => e.HorarioTermino).HasColumnName("horarioTermino");
            });

            modelBuilder.Entity<Diahoraprofessorturmadisciplina>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessorTurmaDisciplina, e.IdDiaHora })
                    .HasName("PRIMARY");

                entity.ToTable("diahoraprofessorturmadisciplina");

                entity.HasIndex(e => e.IdDiaHora)
                    .HasName("fk_DiaHoraProfessorTurmaDisciplina_DiaHora1_idx");

                entity.HasIndex(e => e.IdProfessorTurmaDisciplina)
                    .HasName("fk_DiaHoraProfessorTurmaDisciplina_ProfessorTurmaDisciplina_idx");

                entity.Property(e => e.IdProfessorTurmaDisciplina).HasColumnName("idProfessorTurmaDisciplina");

                entity.Property(e => e.IdDiaHora).HasColumnName("idDiaHora");

                entity.HasOne(d => d.IdDiaHoraNavigation)
                    .WithMany(p => p.Diahoraprofessorturmadisciplina)
                    .HasForeignKey(d => d.IdDiaHora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiaHoraProfessorTurmaDisciplina_DiaHora1");

                entity.HasOne(d => d.IdProfessorTurmaDisciplinaNavigation)
                    .WithMany(p => p.Diahoraprofessorturmadisciplina)
                    .HasForeignKey(d => d.IdProfessorTurmaDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiaHoraProfessorTurmaDisciplina_ProfessorTurmaDisciplina1");
            });

            modelBuilder.Entity<Disciplina>(entity =>
            {
                entity.HasKey(e => e.IdDisciplina)
                    .HasName("PRIMARY");

                entity.ToTable("disciplina");

                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Escola>(entity =>
            {
                entity.HasKey(e => e.IdEscola)
                    .HasName("PRIMARY");

                entity.ToTable("escola");

                entity.HasIndex(e => e.CodIbge)
                    .HasName("fk_Escola_Cidade_idx");

                entity.HasIndex(e => e.IdDiretor)
                    .HasName("fk_Escola_Pessoa1_idx");

                entity.Property(e => e.IdEscola).HasColumnName("idEscola");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.CodIbge).HasColumnName("codIBGE");

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IdDiretor).HasColumnName("idDiretor");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroImovel)
                    .IsRequired()
                    .HasColumnName("numeroImovel")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodIbgeNavigation)
                    .WithMany(p => p.Escola)
                    .HasPrincipalKey(p => p.CodIbge)
                    .HasForeignKey(d => d.CodIbge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Escola_Cidade1");

                entity.HasOne(d => d.IdDiretorNavigation)
                    .WithMany(p => p.Escola)
                    .HasForeignKey(d => d.IdDiretor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Escola_Pessoa1");
            });

            modelBuilder.Entity<Notificacao>(entity =>
            {
                entity.HasKey(e => e.IdNotificacao)
                    .HasName("PRIMARY");

                entity.ToTable("notificacao");

                entity.HasIndex(e => e.IdNotificacao)
                    .HasName("idNotificacao_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdNotificacao).HasColumnName("idNotificacao");

                entity.Property(e => e.Descricao)
                    .HasColumnName("descricao")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NotificaAluno).HasColumnName("notificaAluno");

                entity.Property(e => e.NotificaProfessor).HasColumnName("notificaProfessor");

                entity.Property(e => e.NotificaResponsavel).HasColumnName("notificaResponsavel");

                entity.Property(e => e.Prioridade)
                    .HasColumnName("prioridade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Remetente)
                    .HasColumnName("remetente")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.IdPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf)
                    .HasName("CPF_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorRaca)
                    .IsRequired()
                    .HasColumnName("corRaca")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Identidade)
                    .IsRequired()
                    .HasColumnName("identidade")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidade)
                    .IsRequired()
                    .HasColumnName("nacionalidade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NomeSocial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroImovel)
                    .IsRequired()
                    .HasColumnName("numeroImovel")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Profissao)
                    .IsRequired()
                    .HasColumnName("profissao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasColumnName("tipoPessoa")
                    .HasColumnType("enum('Diretor','Secretario','Professor','Responsavel')");
            });

            modelBuilder.Entity<Pessoanotificacao>(entity =>
            {
                entity.HasKey(e => new { e.IdPessoa, e.IdNotificacao })
                    .HasName("PRIMARY");

                entity.ToTable("pessoanotificacao");

                entity.HasIndex(e => e.IdNotificacao)
                    .HasName("fk_PessoaNotificacao_Notificacao1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_PessoaNotificacao_Pessoa1_idx");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.IdNotificacao).HasColumnName("idNotificacao");

                entity.HasOne(d => d.IdNotificacaoNavigation)
                    .WithMany(p => p.Pessoanotificacao)
                    .HasForeignKey(d => d.IdNotificacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaNotificacao_Notificacao1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Pessoanotificacao)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PessoaNotificacao_Pessoa1");
            });

            modelBuilder.Entity<Professorturmadisciplina>(entity =>
            {
                entity.HasKey(e => e.IdProfessorTurmaDisciplina)
                    .HasName("PRIMARY");

                entity.ToTable("professorturmadisciplina");

                entity.HasIndex(e => e.IdDisciplina)
                    .HasName("fk_ProfessorTurmaDisciplina_Disciplina1_idx");

                entity.HasIndex(e => e.IdProfessor)
                    .HasName("fk_ProfessorTurmaDisciplina_Pessoa1_idx");

                entity.HasIndex(e => e.IdTurma)
                    .HasName("fk_ProfessorTurmaDisciplina_Turma1_idx");

                entity.HasIndex(e => new { e.IdDisciplina, e.IdProfessor, e.IdTurma })
                    .HasName("ProfessorTurmaDisciplina_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdProfessorTurmaDisciplina).HasColumnName("idProfessorTurmaDisciplina");

                entity.Property(e => e.IdDisciplina).HasColumnName("idDisciplina");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.HasOne(d => d.IdDisciplinaNavigation)
                    .WithMany(p => p.Professorturmadisciplina)
                    .HasForeignKey(d => d.IdDisciplina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessorTurmaDisciplina_Disciplina1");

                entity.HasOne(d => d.IdProfessorNavigation)
                    .WithMany(p => p.Professorturmadisciplina)
                    .HasForeignKey(d => d.IdProfessor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessorTurmaDisciplina_Pessoa1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.Professorturmadisciplina)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ProfessorTurmaDisciplina_Turma1");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PRIMARY");

                entity.ToTable("turma");

                entity.HasIndex(e => e.EscolaIdEscola)
                    .HasName("fk_Turma_Escola1_idx");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.AnoDaTurma).HasColumnName("anoDaTurma");

                entity.Property(e => e.EscolaIdEscola).HasColumnName("Escola_idEscola");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NomeTurma)
                    .IsRequired()
                    .HasColumnName("nomeTurma")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Turno)
                    .IsRequired()
                    .HasColumnName("turno")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.EscolaIdEscolaNavigation)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.EscolaIdEscola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_Escola1");
            });

            modelBuilder.Entity<TurmaAluno>(entity =>
            {
                entity.HasKey(e => new { e.IdTurma, e.IdAluno })
                    .HasName("PRIMARY");

                entity.ToTable("turma_aluno");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_Turma_Aluno_Aluno1_idx");

                entity.HasIndex(e => e.IdTurma)
                    .HasName("fk_Turma_Aluno_Turma1_idx");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.TurmaAluno)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_Aluno_Aluno1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.TurmaAluno)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_Aluno_Turma1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
