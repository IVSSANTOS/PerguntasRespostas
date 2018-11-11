using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PerguntasRespostas.MVC.Ui.Models
{
    public class PerguntaModel
    {


        public int Id { get; set; }
        public int IdAutor { get; set; }


        [Display (Name ="Pergunta")]
        public string Descricao { get; set; }


        public int Idcategoria { get; set; }

        public List<CategoriaModel> categoriaModel {
            get {return new List<CategoriaModel>(); } set { this.categoriaModel = value; } }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}
