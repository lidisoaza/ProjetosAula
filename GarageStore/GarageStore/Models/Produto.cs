using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageStore.Models
{
    public class Produto
    { 
      
        public int ProdutoID { get; set; }

        [Required(ErrorMessage = "Informe o Titulo do Anúncio")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Titulo deve conter entre 5 e 50 caracteres!")]
        public string TitleProduct { get; set; }

        [Required(ErrorMessage = "Produto deve conter uma descrição!")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valor do Produto deve ser infomado")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c0}")]
        [Range (0,500,ErrorMessage ="O Preço do Produto não pode ultrapassar R$ 500,00")]
        public decimal Price { get; set; }

        // [DataType(DataType.Date)]
        [Display(Name = "Data de Entrada do Produto")]
        public DateTime DateInput { get; set; }

        public string StatusVenda { get; set; }

        [Display(Name ="ImageFile")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Categories { get; set; }

        [Display(Name = "UserID")]
        public int UserID { get; set; }
        public virtual User Users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

    }
     

}