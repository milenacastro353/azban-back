using DataAccess;
using EntityFrameworkExtras.EFCore;
using Microsoft.EntityFrameworkCore;
using Repository.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepoProduct
    {
        public DatabaseContext context;

        public List<ProductInfoDto> GetProductList()
        {
            var productsResult = new List<ProductInfoDto>();

            var products = context.Products.FromSqlRaw("ObtenerProductosConListas").AsNoTracking().ToList();

            productsResult =
                products.Select(p => new ProductInfoDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Sigle = p.Sigle,
                    Gender = p.Gender
                }).GroupBy(p => p.Id).Select(p => p.First()).ToList();


            foreach (var p in productsResult)
            {
                p.Genders = new List<GenderDto>();
                // Agregar Generos
                if (p.Gender == "UNISEX" || p.Gender == "DAMA")
                {
                    p.Genders.Add(new GenderDto() { Id = 1, Gender = "F" });
                }

                if (p.Gender == "UNISEX" || p.Gender == "CABALLERO")
                {
                    p.Genders.Add(new GenderDto() { Id = 2, Gender = "M" });
                }

                if (p.Gender == "UNISEX")
                {
                    p.Genders.Add(new GenderDto() { Id = 3, Gender = "Niño" });
                }

                // Agregar Colores
                p.Colors = products.Where(pr => pr.Id == p.Id).Select(pr => new ColorDto()
                {
                    Id = pr.ColorId,
                    Color = pr.ColorName,
                    HexRef = pr.HexRef
                }).GroupBy(c => c.Id).Select(c => c.First()).ToList();

                // Agregar Tallas
                p.Sizes = products.Where(pr => pr.Id == p.Id).Select(pr => new SizeDto()
                {
                    Id = pr.SizeId,
                    Size = pr.SizeName,
                    Price = pr.Price
                }).GroupBy(s => s.Id).Select(s => s.First()).ToList();
            }

            return productsResult;
        }
    }
}
