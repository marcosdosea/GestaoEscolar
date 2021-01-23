using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IHorarioService
    {
        void Editar(Diahora diahora);
        int Inserir(Diahora diahora);
        Diahora Obter(int idDiahora);
        IEnumerable<Diahora> ObterPorNome(string nome);
        IEnumerable<Diahora> ObterTodos();
        void Remover(int idDiahora);
        IEnumerable<HorarioDTO> ObterPorNomeOrdenadoDescending(string nome);


    }
}
