using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model.DataBase.Model
{
    public class Produto
    {
        public virtual int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public virtual String Nome { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório")]
        [Display(Name = "Descrição")]
        public virtual String Descricao { get; set; }
        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        public virtual double Valor { get; set; }
        [Required(ErrorMessage = "O campo Estoque é obrigatório")]
        public virtual int Estoque { get; set; }
        [Required(ErrorMessage = "O campo Tamanho é obrigatório")]
        public virtual int Tamanho { get; set; }
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public virtual Categoria Categoria { get; set; }
        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [Display(Name = "Gênero")]
        public virtual Genero Genero { get; set; }
        [Required(ErrorMessage = "O campo Cor é obrigatório")]
        public virtual Cor Cor { get; set; }
        [Required(ErrorMessage = "O campo Fabricante é obrigatório")]
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
