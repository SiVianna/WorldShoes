using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Pedido
    {
        public virtual int Id { get; set; }
        public virtual Usuario Usuario { get; set; }




    }

    public class PedidoMap : ClassMapping<Pedido>
    {

        public PedidoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("idUsuario");
            });

        }







    }
}
