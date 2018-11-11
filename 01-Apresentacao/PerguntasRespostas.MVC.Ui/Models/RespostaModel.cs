using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerguntasRespostas.MVC.Ui.Models
{
    public class RespostaModel
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
