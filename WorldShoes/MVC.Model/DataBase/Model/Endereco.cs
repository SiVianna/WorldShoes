using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Endereco
    {
        public virtual int Id { get; set; }
        public virtual int Numero { get; set; }
        public virtual String Rua { get; set; }
        public virtual String Bairro { get; set; }
        public virtual String Cidade { get; set; }
        public virtual String Estado { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Fabricante Fabricante { get; set; }

    }

    public class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Numero);
            Property(x => x.Rua);
            Property(x => x.Bairro);
            Property(x => x.Cidade);
            Property(x => x.Estado);

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("idUsuario");


            });

            ManyToOne(x => x.Fabricante, m =>
            {
                m.Column("idFabricante");
            });
        }
    }
}
