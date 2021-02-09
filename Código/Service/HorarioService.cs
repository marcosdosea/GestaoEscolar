using Core;
using Core.DTO;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class HorarioService : IHorarioService
    {
        private readonly SiCAEContext _context;
        
        public HorarioService(SiCAEContext context)
        {
            _context = context;
        }

        public int Inserir(Diahora diahora)
        {
            _context.Add(diahora);
            _context.SaveChanges();
            return diahora.IdDiaHora;
        }
        public void Editar(Diahora diahora)
        {
            _context.Diahora.Update(diahora);
            _context.SaveChanges();
        }
        public void Remover(int idDiahora)
        {
            var _diahora = _context.Diahora.Find(idDiahora);
            _context.Diahora.Remove(_diahora);
            _context.SaveChanges();
        }
        private IQueryable<Diahora> GetQuery()
        {
            IQueryable<Diahora> tb_diahora = _context.Diahora;
            var query = from diahora in tb_diahora
                        select diahora;
            return query;
        }
        public int GetHorarios()
        {
            return _context.Diahora.Count();
        }
        public Diahora Obter(int idDiahora)
        {
            IEnumerable<Diahora> diahoras = GetQuery().Where(diahoraModel => diahoraModel.IdDiaHora.Equals(idDiahora));

            return diahoras.ElementAtOrDefault(0);
        }

        public IEnumerable<Diahora> ObterPorNome(string nome)
        {
            IEnumerable<Diahora> diahoras = GetQuery()
                .Where(diahoraModel => diahoraModel.DiaSemana.StartsWith(nome));
            return diahoras;
        }

        public IEnumerable<Diahora> ObterTodos()
        {
            return GetQuery();
        }

        public IEnumerable<HorarioDTO> ObterPorNomeOrdenadoDescending(string nome)
        {
            IQueryable<Diahora> tb_diahora = _context.Diahora;
            var query = from diahora in tb_diahora
                        where nome.StartsWith(nome)
                        orderby diahora.DiaSemana descending
                        select new HorarioDTO
                        {
                            DiaSemana = diahora.DiaSemana
                        };
            return query;
        }


        
    }
}
