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

        //  *************************************
        //  Criação das chaves Forasteiras
        //  *************************************

        //  FK para Viatura
        [ForeignKey("Viatura")]  //Anotações são feitas sobre o objeto que está por baixo
        public int ViaturaFK { get; set; }  //Base de Dados

        public Viaturas Viatura { get; set; }   // C#

        [ForeignKey("Agente")]  //Anotações são feitas sobre o objeto que está por baixo
        public int AgenteFK { get; set; }  //Base de Dados

        public Agentes Agente { get; set; }   // C#

        [ForeignKey("Condutor")]  //Anotações são feitas sobre o objeto que está por baixo
        public int CondutorFK { get; set; }  //Base de Dados

        public Condutores Condutor { get; set; }   // C#


        //lista das multas associadas à viatura
        public ICollection<Multas> ListaDeMultas { get; set; }

    }
}