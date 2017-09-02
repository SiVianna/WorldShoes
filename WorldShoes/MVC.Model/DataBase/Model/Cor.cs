﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Cor
    {
        public virtual int Id { get; set; }
        public virtual String Nome { get; set; }

        public virtual IList<Produto> Produtos { get; set; }

        public Cor()
        {
            this.Produtos = new List<Produto>();
        }
    }

    public class CorMap : ClassMapping<Cor>
    {
        public CorMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));
            Property(x => x.Nome);

            Bag<Produto>(x => x.Produtos, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idCor"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
          r => r.OneToMany());

        }

    }
}
