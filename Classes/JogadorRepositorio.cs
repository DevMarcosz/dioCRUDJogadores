using System;
using System.Collections.Generic;
using DIO.Jogadores.Interfaces;

namespace DIO.Jogadores
{
    public class JogadorRepositorio : IRepositorio<Jogador>
    {
        private List<Jogador> listaJogador = new List<Jogador>();
        public void Atualiza(int id, Jogador entidade)
        {
            listaJogador[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaJogador[id].Excluir();
        }

        public void Insere(Jogador entidade)
        {
            listaJogador.Add(entidade);
        }

        public List<Jogador> Lista()
        {
            return listaJogador;
        }

        public int ProximoId()
        {
            return listaJogador.Count;
        }

        public Jogador RetornaPorId(int id)
        {
          return listaJogador[id];
        }
    }
}