using System;

namespace DIO.Jogadores
{
    public class Jogador : EntidadeBase
    {
        private Nivel Nivel { get ; set; }
        private string Nome {get ; set;}
        private string Clube {get ; set; }
        private string Descricao {get ; set; }
        private bool Excluido {get; set;}

        public Jogador(int id, Nivel nivel, string nome, string clube, string descricao)
        {
            this.Id = id;
            this.Nivel = nivel;
            this.Nome = nome;
            this.Clube = clube;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Patamar: " + this.Nivel + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Clube: " + this.Clube + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
             retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }
        public int retornaId()
        {
            return this.Id;
        }

         public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}