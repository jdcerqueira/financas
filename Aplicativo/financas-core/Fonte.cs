using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financas_core
{
    public class Fonte
    {
        public int codigo { get; set; }
        public String descricao { get; set; }
        public String tipo { get; set; }
        public CartaoCredito dadosCartao { get; set; }

        public class CartaoCredito
        {
            public String bandeira { get; set; }
            public int fechamentoFatura { get; set; }
            public int pagamentoFatura { get; set; }

            public static void criaCartaoCredito(Fonte fonte)
            {
                SqlDataReader resultado = DAO.resultSet($"exec lancamentos.cria_fonte_cartao_credito {fonte.codigo},'{fonte.dadosCartao.bandeira}',{fonte.dadosCartao.fechamentoFatura},{fonte.dadosCartao.pagamentoFatura}");
                if (resultado.Read())
                {
                    fonte.codigo = Int32.Parse(resultado["CodResultado"].ToString());
                    Console.WriteLine(resultado["MsgRetorno"].ToString());
                }
            }

            override
            public String ToString()
            {
                return $"Bandeira: {this.bandeira} \n" +
                $"Fechamento: {this.fechamentoFatura}\n" +
                $"Fatura: {this.pagamentoFatura}";
            }
        }

        public static void criaFonte(Fonte fonte)
        {
            SqlDataReader resultado = DAO.resultSet($"exec lancamentos.cria_fonte '{fonte.descricao}','{fonte.tipo}' ");
            if (resultado.Read())
            {
                fonte.codigo = Int32.Parse(resultado["CodResultado"].ToString());
                Console.WriteLine(resultado["MsgRetorno"].ToString());
            }
                

            if (fonte.tipo == "cartao.credito")
                CartaoCredito.criaCartaoCredito(fonte);
        }

        public static List<Fonte> listaFontesSemFiltro()
        {
            SqlDataReader resultado = DAO.resultSet("exec lancamentos.lista_fontes_sem_filtro");
            List<Fonte> fontes = new List<Fonte>();

            while (resultado.Read())
            {
                fontes.Add(new Fonte()
                {
                    codigo = Int32.Parse(resultado["cdFonte"].ToString()),
                    descricao = resultado["dsFonte"].ToString(),
                    tipo = resultado["tpFonte"].ToString(),
                    dadosCartao = new CartaoCredito()
                    {
                        bandeira = resultado["dsBandeira"].ToString(),
                        fechamentoFatura = Int32.Parse(resultado["diaFechamento"].ToString()),
                        pagamentoFatura = Int32.Parse(resultado["diaFatura"].ToString())
                    }

                }) ;
            }

            return fontes;
        }

        override
        public String ToString()
        {
            return $"Codigo: {this.codigo}\n" +
                $"Descrição: {this.descricao}\n" +
                $"Tipo: {this.tipo}\n" +
                $"Cartão de crédito: {this.dadosCartao.ToString()}";
        }
    }
}
