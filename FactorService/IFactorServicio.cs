using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FactorService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFactorServicio
    {
        [OperationContract]
        IList<Factor> Listar();

        [OperationContract]
        void Guardar(Factor f);

        [OperationContract]
        void Eliminar(Factor f);

        [OperationContract]
        Factor GetById(int id);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Factor
    {

        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public List<FactorValor> Valores { get; set; } 

    }

    [DataContract]
    public class FactorValor
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public double Valor { get; set; }

    }

}
