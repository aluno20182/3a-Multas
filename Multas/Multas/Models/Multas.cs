using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Multas
    {

        public int ID { get; set; }

        public string Infracao { get; set; }

        public string LocalDaMulta { get; set; }

        public decimal ValorMulta { get; set; }

        public DateTime DataDaMulta { get; set; }

        // **************************************
        // criação das Chaves Forasteiras
        // **************************************

        // FK para Viatura
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }  // Base de Dados
        public Viaturas Viatura { get; set; }  // C#

        // FK para Condutor
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public Condutores Condutor { get; set; }

        // FK para Agente
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public Agentes Agente { get; set; }


    }


}
