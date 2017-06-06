using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GarageStore.Models;


namespace GarageStore.Models
{
    public class CategoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GarageDBContext>
    {
        protected override void Seed(GarageDBContext context)
        {
            var categ = new List<Category>
            {
                new Category { Name ="Vestuário e Beleza" ,Description="Roupas, Sapatos, Bolsas e Malas, Chapéus, Acessórios, Bijuterias, Relógios, Maquiagem, Cosméticos,outros"},
                new Category { Name ="Utensílios Domésticos" ,Description="Utensílios de Cozinha, Panelas, Louças, Talheres, Utensílios para Limpeza, outros"},
                new Category { Name ="Decoração" ,Description="Quadros, Enfeites, Movéis Decorativos, Peças Artesanais, outros"},
                new Category { Name ="Construção e Ferramentas" ,Description="Ferramentas Eletricas,Ferramentas Manuais, Ferragens, Madeiras, Telhas, Sobras de Obra, outros"},
                new Category { Name ="Movéis" ,Description="Armários para Cozinha, Guarda-Roupas, Armários, Racks, Criados-Mudos, Comodas, Estantes, Escrivaninhas, outros"},
                new Category { Name ="Eletrodomésticos" ,Description="Geladeiras, Fogões, Microondas, Lavadouras, Secadoras, Lava-Louças, Ar-Condicionados, Fornos-elétricos, outros"},
                new Category { Name ="Eletroportáteis" ,Description="Batedeiras, Liquidificadores, Torradeiras, Ferros-de-Passar, Ventiladores, Aspiradores de pó, Acessórios, outros"},
                new Category { Name ="Eletroeletrônicos" ,Description="Tvs, Rádios, Home Theaters, DVD, BlueRay, Video Games, Acessórios, outros"},
                new Category { Name ="Informática e Telefonia" ,Description="SmartPhones, Telefones fixos, Celulares, Computadores e Componentes, Impressoras, Cameras, Acessórios para Informética e Telefonia, outros"},
                new Category { Name ="Hobby, Lazer e Esportes" ,Description="Livros, Revistas, Discos, Cds, Quadrinhos, Bicicletas, Equipamentos para Musculação e Ginastica, Equipamentos Esportivos, Brinquedos, outros"},
                new Category { Name ="Jardinagem" ,Description="Flores, Sementes, Vasos, Acessórios para Jardinagem, Movéis para Jardim, Piscinas e acessórios, outros"},
                new Category { Name ="Acessórios para Pets" ,Description="Gaiolas, Pratos, Bebedouros, Acessórios, Roupas para Animais, Produtos de Higiene para Pets, Coleiras e Guias, outros"}

            };
            categ.ForEach(a=> context.Categories.Add(a));
            context.SaveChanges();

          
        }
        

    }
}