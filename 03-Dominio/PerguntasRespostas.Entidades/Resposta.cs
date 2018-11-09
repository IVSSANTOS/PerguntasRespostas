using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Entidades
{
    public class Resposta
    {
        public int Id { get; set; }
        public int IdPergunta { get; set; }
        public int IdAutor { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool RespostaAceita { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
