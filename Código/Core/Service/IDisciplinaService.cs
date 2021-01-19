using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IDisciplinaService
    {
        Disciplina Buscar(int idDisciplina);
        int Inserir(Disciplina disciplina);
        void Editar(Disciplina disciplina);
        IEnumerable<Disciplina> ObterPorNome(string nome);
        IEnumerable<Disciplina> ObterTodos();
        void Remover(int idDisciplina);


    }
}
