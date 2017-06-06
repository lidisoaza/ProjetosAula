using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageStore.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required (ErrorMessage="Nome da Categoria deve ser informado")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="Nome da Categoria deve conter entre 2 e 20 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage ="O campo Descrição deve ser preenchido!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}