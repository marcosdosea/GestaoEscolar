using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface ITurmaService
    {
        Turma Buscar(int idTurma);
        int Inserir(Turma turma);
        void Editar(Turma turma);
        IEnumerable<Turma> ObterPorNome(string nome);
        IEnumerable<Turma> ObterTodos();
        void Remover(int idTurma);
    }
}
