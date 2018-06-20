using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace desafioArquivo
{
    class Program
    {
        public static bool validarData(string data, out DateTime valor)
        {
            return DateTime.TryParseExact(data, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out valor);
        }

        static void Main(string[] args)
        {
            try
            {
                DateTime data;
                if (args.Count() == 0)
                {
                    Console.WriteLine("Erro - Nao foi passado uma data como parametro");
                    Environment.ExitCode = 3;
                }
                else if (args.Count() > 1)
                {
                    Console.WriteLine("Erro - Foi passado mais de um parametro");
                    Environment.ExitCode = 5;
                }
                else
                {
                    if (validarData(args[0], out data))
                    {
                        MontarArquivo(data);
                    }
                    else
                    {
                        Console.WriteLine("Erro - Data nao valida");
                        Environment.ExitCode = 2;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.ExitCode = 1;
            }
        }

        private static void MontarArquivo(DateTime data)
        {
            String arquivo = "resultado.txt";
            
            List<desafioArquivo.Negocios.Entidades.Transacoes> trans = desafioArquivo.Dados.Transacoes.BuscaDados(data);
            using (StreamWriter sw = new StreamWriter(arquivo, true, Encoding.UTF8))
            {
                for (int i = 0; i < trans.Count() - 1; i++)
                {
                    sw.WriteLine(trans[i].ToString());
                }
            }
        }
    }
}
