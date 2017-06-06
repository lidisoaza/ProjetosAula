using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GarageStore.Models
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Display(Name = "Mensagem")]
        [DataType (DataType.MultilineText)]
        public string Messages { get; set; }


        [Display(Name = "Data do comentário")]
        [DataType(DataType.Date)]
        public DateTime DateSend { get; set; }

        [Display(Name = "Usuario Id")]
        public int UserId { get; set; }

        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Display(Name = "Resposta Id")]
        public int AnswerId { get; set; }

        [Display(Name = "ProdutoID")]
        public int ProdutoId { get; set; }
        public virtual Produto Produtos { get; set; }
    }
}