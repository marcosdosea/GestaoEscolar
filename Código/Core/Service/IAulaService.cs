using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IAulaService
    {
        void Editar(Aula aula);
        int Inserir(Aula aula);
        Aula Obter(int idAula);
        IEnumerable<Aula> ObterPorNome(string nome);
        IEnumerable<Aula> ObterTodos();
        void Remover(int idAula);
        IEnumerable<AulaDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
