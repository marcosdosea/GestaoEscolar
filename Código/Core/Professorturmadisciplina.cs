using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Professorturmadisciplina
    {
        public Professorturmadisciplina()
        {
            Aula = new HashSet<Aula>();
            Avaliacao = new HashSet<Avaliacao>();
            Diahoraprofessorturmadisciplina = new HashSet<Diahoraprofessorturmadisciplina>();
        }

        public int IdProfessorTurmaDisciplina { get; set; }
        public int IdDisciplina { get; set; }
        public int IdProfessor { get; set; }
        public int IdTurma { get; set; }

        public virtual Disciplina IdDisciplinaNavigation { get; set; }
        public virtual Pessoa IdProfessorNavigation { get; set; }
        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual ICollection<Aula> Aula { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<Diahoraprofessorturmadisciplina> Diahoraprofessorturmadisciplina { get; set; }
    }
}
