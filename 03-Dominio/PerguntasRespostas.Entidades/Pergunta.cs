using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Entidades
{
    public class Pergunta
    {
        public int Id { get; set; }
        public int IdAutor { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
