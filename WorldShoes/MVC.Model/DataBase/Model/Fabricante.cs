using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Fabricante
    {
        public virtual int Id { get; set; }
        public virtual String razao_social { get; set; }

        public virtual IList<Produto> Produtos { get; set; }
        public virtual IList<Telefone> Telefones { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }

        public Fabricante()
        {
            Produtos = new List<Produto>();
            Telefones = new List<Telefone>();
            this.Enderecos = new List<Endereco>();
        }
    }

    public class FabricanteMap : ClassMapping<Fabricante>
    {
        public FabricanteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.razao_social);

            Bag<Produto>(x => x.Produtos, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idFabricante"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
          r => r.OneToMany());

            Bag<Telefone>(x => x.Telefones, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idFabricante"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
          r => r.OneToMany());

            Bag<Endereco>(x => x.Enderecos, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idFabricante"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.OneToMany());
        }

    }
}
