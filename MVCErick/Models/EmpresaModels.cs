using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCErick.Models
{
    public class EmpresaModels
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]    
        [DisplayName("Nome")]
        public string NomeEmpresa { get; set; }
        [DisplayName("Descrição")]
        public string DescricaoEmpresa{ get; set; }
        [MaxLength(100)]
        [DisplayName("Endereço")]
        public string EnderecoEmpresa { get; set; }
        
        public string CNPJ { get; set; }
        [DisplayName("Criação")]
        public DateTime DataCriacao { get; set; }



        //Muitos pra um
        [JsonIgnore]
        public List<UsuarioModels> Usuarios { get; set; }

        
    }
}