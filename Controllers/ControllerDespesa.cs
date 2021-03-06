﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerDespesa
    {
        public Boolean SalvarDespesa(Despesa despesaRecebida)
        {
            Despesa teste1 = ProcurarDespesaPorId(despesaRecebida.DespesaID);
            Despesa teste2 = ProcurarDespesaPorNome(despesaRecebida.Descricao);

            if (teste1 == null && teste2 == null)
            {
                ContextoSigleton.Instancia.Despesas.Add(despesaRecebida);
                ContextoSigleton.Instancia.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Despesa> RetornarListaDeDespesa()
        {
            return ContextoSigleton.Instancia.Despesas.ToList();

        }

        public Despesa ProcurarDespesaPorId(int id)
        {
            var u = from x in ContextoSigleton.Instancia.Despesas
                    where x.DespesaID.Equals(id)
                    select x;
            if (u != null)
            {
                return u.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public Despesa ProcurarDespesaPorNome(string nome)
        {
            var d = from x in ContextoSigleton.Instancia.Despesas
                    where x.Descricao.ToLower().Equals(nome.Trim().ToLower())
                    select x;
            if (d != null)
            {
                return d.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        public Boolean ExcluirDespesa(int despesaID)
        {
            Despesa d = ContextoSigleton.Instancia.Despesas.Find(despesaID);

            if (d != null && despesaID > 27)
            {
                ContextoSigleton.Instancia.Entry(d).State = System.Data.Entity.EntityState.Deleted;
                ContextoSigleton.Instancia.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
