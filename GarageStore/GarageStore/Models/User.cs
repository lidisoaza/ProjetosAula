using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GarageStore.Models
{
    public class User
    {

        public int UserID { get; set; }

        [Required(ErrorMessage = "campo Nome é obrigatório")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Nome deve conter entre 4 e 30 caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "campo Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required (ErrorMessage ="Campo CPF é obrigatório")]
        [RegularExpression(@"\d{11}",ErrorMessage ="CPF deve conter 11 digítos, sem o uso de separadores!")]
        public string Cpf { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "Rua deve conter entre 4 e 30 caracteres!")]
        public string Street { get; set; }

        public int Number_House { get; set; }

        [Required(ErrorMessage = "campo Bairro deve ser informado")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Bairro deve conter entre 3 e 20 caracteres!")]
        public string District { get; set; }

        [Required(ErrorMessage = "campo Cidade deve ser informado")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Cidade deve conter entre 3 e 20 caracteres!")]
        public string City { get; set; }

        [Required(ErrorMessage = "campo Estado deve ser informado")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Estado deve conter entre 4 e 20 caracteres!")]
        public string State { get; set; }

        [Required (ErrorMessage ="Informe um número de Telefone")]
        [RegularExpression(@"((\d{3}))?\d{8}",ErrorMessage ="DDD deve conter 3 digítos e o numero de Telefone. 8 digítos")]
        public string Telephone { get; set; }

        [Display(Name="Image User")]
        public byte[] ImageUser { get; set; }
        public string ImageMimeType { get; set; }

        public string Login { get; set; }

        /*public int Aval { get; set; }
        public int AvalCount { get; set; }*/

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}