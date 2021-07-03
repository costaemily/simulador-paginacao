using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class TabelaDePaginas
    {
        private List<Pagina> tabelaPagina = new List<Pagina>();

        public TabelaDePaginas()
        {
        }

        public TabelaDePaginas(List<Pagina> tabelaPagina)
        {
            this.tabelaPagina = tabelaPagina;
        }

        internal List<Pagina> TabelaPagina { get => tabelaPagina; set => tabelaPagina = value; }

        public void SetarTabelaPaginas(Memoria prin)
        {
            //SETAR TABELA DE PÁGINAS
            for (int i = 0; i <= prin.Tamanho; i++)
            {
                Pagina p = new Pagina(i, 0, 0, 0, -1);
                //p.UltimoAcesso = 
                this.tabelaPagina.Add(p);
            }
        }
        public void ExibirTablelaPag()
        {
            Console.WriteLine("         TABELA DE PÁGINAS       \n");
            //Console.WriteLine("| I | A | R | M | B |");
            for (int i = 0; i < this.tabelaPagina.Count; i++)
            {
                Console.WriteLine("ID: " + this.tabelaPagina[i].Id + " |ATIVA: " + this.tabelaPagina[i].Ativa + " |R: " + this.tabelaPagina[i].R + " |M: " + this.tabelaPagina[i].M + " |BLOCO: " + this.tabelaPagina[i].IdBloco);
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
