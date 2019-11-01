using System;

namespace AirBnb.Models
{
    public class Solicitacao
    {
        public int SolicitacaoId { get; set; }
        public string Usuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}
