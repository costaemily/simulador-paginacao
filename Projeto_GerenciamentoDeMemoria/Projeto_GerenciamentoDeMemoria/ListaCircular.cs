using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class ListaCircular
    {
        private No ult;

        internal No Ult { get => ult; set => ult = value; }

        public void CriarLista(ListaCircular l)
        {
            l.ult = null;
        }
        public int EstaVazia(ListaCircular l)
        {
            if (l.ult == null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void InserirLista(ListaCircular l, Bloco b, Memoria m)
        {
            No novo = new No();

            Bloco c = new Bloco();
            c.criarBloco(m.Offset);
            c = b;
            novo.Valor = c;
            novo.Prox = null;

            if (EstaVazia(l) == 1)
            {
                l.ult = novo;
                l.ult.Prox = l.ult;
            }
            else
            {
                novo.Prox = l.ult.Prox;
                l.ult.Prox = novo;
                l.ult = novo;
            }
        }
        public No RetirarLista(ListaCircular l)
        {
            No aux1 = null, aux2 = null;

            if (l.ult == null)
            {
                return null;
            }
            else
            {
                aux1 = l.ult.Prox;
                aux2 = l.ult;

                No n = null;
                if (aux2 == aux1)
                {
                    n = aux1;
                    l.ult = null;
                }
                else
                {
                    aux2.Prox = aux1.Prox;
                    l.ult = aux2;
                    n = aux1;
                }
                return n;
            }
        }
        public int QTD(ListaCircular l)
        {
            int t = 0;
            No aux = l.ult.Prox;
            while (aux != l.ult)
            {
                t++;
                aux = aux.Prox;
            }
            t++;
            return t;
        }
    }
}
