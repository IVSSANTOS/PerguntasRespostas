using System;
using System.Collections.Generic;
using System.Text;

namespace PerguntasRespostas.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

    }
}
