using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafioArquivo.Negocios.Entidades
{
    public class Transacoes
    {
        public Int32 Cartao { get; set; }
        public Double Valor { get; set; }
        private DateTime DataNascimento {get;set;} 

        public Transacoes(Int32 cartao, double valor, DateTime dataNascimento)        
        {
            this.Cartao = cartao;
            this.Valor = valor;
            this.DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            return this.Cartao.ToString().PadLeft(16, '0') + this.Valor.ToString().Replace(".", "").Replace(",", "").PadLeft(11, '0') + this.DataNascimento.ToString("ddMMyyyy");
        }
    }
}
