using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Produto
    {
        public virtual int Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Descricao { get; set; }
        public virtual double Valor { get; set; }
        public virtual int Estoque { get; set; }
        public virtual int Tamanho { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual Cor Cor { get; set; }

        public virtual Fabricante Fabricante { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
        public virtual IList<FotoProduto> FotosProduto { get; set; }
        public virtual IList<Pedido> pedido_has_produto { get; set; }

        public Produto()
        {
            this.Avaliacoes = new List<Avaliacao>();
            this.FotosProduto = new List<FotoProduto>();
            this.pedido_has_produto = new List<Pedido>();
        }
    }

    public class ProdutoMap : ClassMapping<Produto>
    {
        public ProdutoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Identity));

            Property(x => x.Nome);
            Property(x => x.Descricao);
            Property(x => x.Valor);
            Property(x => x.Estoque);
            Property(x => x.Tamanho);

            ManyToOne(x => x.Categoria, m =>
            {
                m.Column("idCategoria");

            });

            ManyToOne(x => x.Genero, m =>
            {
                m.Column("idGenero");

            });

            ManyToOne(x => x.Cor, m =>
            {
                m.Column("idCor");

            });

            ManyToOne(x => x.Fabricante, m =>
            {
                m.Column("idFabricante");

            });

            Bag<Avaliacao>(x => x.Avaliacoes, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idProduto"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
          r => r.OneToMany());

            Bag<FotoProduto>(x => x.FotosProduto, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idProduto"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
         r => r.OneToMany());

            Bag<Pedido>(x => x.pedido_has_produto, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("idProduto"));
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
            },
            r => r.ManyToMany());

        }
    }
}
