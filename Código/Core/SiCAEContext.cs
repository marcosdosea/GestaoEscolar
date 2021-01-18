using System;
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
        public virtual DbSet<Alunopessoaresponsavel> Alunopessoaresponsavel { get; set; }
        public virtual DbSet<Aula> Aula { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Diahora> Diahora { get; set; }
        public virtual DbSet<Diahoraprofessorturmadisciplina> Diahoraprofessorturmadisciplina { get; set; }
        public virtual DbSet<Diretor> Diretor { get; set; }
        public virtual DbSet<Disciplina> Disciplina { get; set; }
        public virtual DbSet<Escola> Escola { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Presencaalunoaula> Presencaalunoaula { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Secretário> Secretário { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }
        public virtual DbSet<TurmaAluno> TurmaAluno { get; set; }
        public virtual DbSet<User> User { get; set; }

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

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
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
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Identidade)
                    .IsRequired()
                    .HasColumnName("identidade")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidade)
                    .IsRequired()
                    .HasColumnName("nacionalidade")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nis)
                    .IsRequired()
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

            modelBuilder.Entity<Alunopessoaresponsavel>(entity =>
            {
                entity.HasKey(e => new { e.IdAluno, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("alunopessoaresponsavel");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_AlunoPessoa_Aluno1_idx");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_AlunoPessoa_Pessoa1_idx");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.Property(e => e.Parentesco)
                    .IsRequired()
                    .HasColumnName("parentesco")
                    .HasColumnType("enum('PAI','MAE','OUTRO')")
                    .HasDefaultValueSql("'PAI'");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Alunopessoaresponsavel)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AlunoPessoa_Aluno1");

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
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodIbge)
                    .HasName("PRIMARY");

                entity.ToTable("cidade");

                entity.Property(e => e.CodIbge).HasColumnName("codIBGE");
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
                entity.HasKey(e => new { e.IdDiaHora, e.IdProfessorTurmaDisciplina })
                    .HasName("PRIMARY");

                entity.ToTable("diahoraprofessorturmadisciplina");

                entity.HasIndex(e => e.IdDiaHora)
                    .HasName("fk_DiaHoraProfessorTurmaDisciplina_DiaHora1_idx");

                entity.HasIndex(e => e.IdProfessorTurmaDisciplina)
                    .HasName("fk_DiaHoraProfessorTurmaDisciplina_ProfessorTurmaDisciplina_idx");

                entity.Property(e => e.IdDiaHora).HasColumnName("idDiaHora");

                entity.Property(e => e.IdProfessorTurmaDisciplina).HasColumnName("idProfessorTurmaDisciplina");

                entity.HasOne(d => d.IdDiaHoraNavigation)
                    .WithMany(p => p.Diahoraprofessorturmadisciplina)
                    .HasForeignKey(d => d.IdDiaHora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DiaHoraProfessorTurmaDisciplina_DiaHora1");
            });

            modelBuilder.Entity<Diretor>(entity =>
            {
                entity.HasKey(e => new { e.IdDiretor, e.IdSecretário, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("diretor");

                entity.HasIndex(e => new { e.IdSecretário, e.IdPessoa })
                    .HasName("fk_Diretor_Secretário1_idx");

                entity.Property(e => e.IdDiretor).HasColumnName("idDiretor");

                entity.Property(e => e.IdSecretário).HasColumnName("idSecretário");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.Diretor)
                    .HasForeignKey(d => new { d.IdSecretário, d.IdPessoa })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Diretor_Secretário1");
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
                    .HasName("fk_Escola_Diretor1_idx");

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
                    .HasForeignKey(d => d.CodIbge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Escola_Cidade1");
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
                    .HasMaxLength(12)
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
                    .IsFixedLength();

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Presencaalunoaula>(entity =>
            {
                entity.HasKey(e => new { e.IdAula, e.IdAluno })
                    .HasName("PRIMARY");

                entity.ToTable("presencaalunoaula");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_Aula_has_Aluno_Aluno1_idx");

                entity.HasIndex(e => e.IdAula)
                    .HasName("fk_Aula_has_Aluno_Aula_idx");

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.EstaPresente).HasColumnName("estaPresente");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.Presencaalunoaula)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aula_has_Aluno_Aluno1");

                entity.HasOne(d => d.IdAulaNavigation)
                    .WithMany(p => p.Presencaalunoaula)
                    .HasForeignKey(d => d.IdAula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aula_has_Aluno_Aula");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => new { e.IdProfessor, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("professor");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Professor_Pessoa1_idx");

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Professor)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Professor_Pessoa1");
            });

            modelBuilder.Entity<Secretário>(entity =>
            {
                entity.HasKey(e => new { e.IdSecretário, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("secretário");

                entity.HasIndex(e => e.IdPessoa)
                    .HasName("fk_Secretário_Pessoa1_idx");

                entity.Property(e => e.IdSecretário).HasColumnName("idSecretário");

                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Secretário)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Secretário_Pessoa1");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PRIMARY");

                entity.ToTable("turma");

                entity.HasIndex(e => e.IdEscola)
                    .HasName("fk_Turma_Escola1_idx");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.AnoDaTurma).HasColumnName("anoDaTurma");

                entity.Property(e => e.IdEscola).HasColumnName("idEscola");

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

                entity.HasOne(d => d.IdEscolaNavigation)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.IdEscola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_Escola1");
            });

            modelBuilder.Entity<TurmaAluno>(entity =>
            {
                entity.HasKey(e => new { e.IdTurma, e.IdAluno })
                    .HasName("PRIMARY");

                entity.ToTable("turma_aluno");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("fk_Turma_has_Aluno_Aluno1_idx");

                entity.HasIndex(e => e.IdTurma)
                    .HasName("fk_Turma_has_Aluno_Turma1_idx");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.TurmaAluno)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_has_Aluno_Aluno1");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.TurmaAluno)
                    .HasForeignKey(d => d.IdTurma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Turma_has_Aluno_Turma1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
