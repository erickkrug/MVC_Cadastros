using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace MVCErick.Models
{
    public class UsuarioRequest
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string NomeEmpresa { get; set; }
        public string DescricaoEmpresa { get; set; }
        public string DescricaoUsuario { get; set; }
        public string EnderecoEmpresa { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public class UsuarioResponse
    {
        public string NomeUsuario { get; set; }
        public string CPF { get; set; }
        public string TelefoneUsuario { get; set; }
        public string NomeEmpresarial { get; set; }
        public string DescricaoEmpresarial { get; set; }
        public string DescricaoUsuario { get; set; }
        public string EnderecoEmpresa { get; set; }
        public string CNPJEmpresa { get; set; }
        public DateTime CriacaoEmpresa { get; set; }
    }

    public class UsuarioModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        [MaxLength(20)]
        public string Telefone { get; set; }
        [DisplayName("Empresa")]
        public int EmpresaId { get; set; }

        //Um para muitos
        public EmpresaModels Empresa { get; set; }


    }
}