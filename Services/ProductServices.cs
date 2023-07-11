using App.Models;

namespace App.Services{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id = 1,Name ="Iphone X",Price = 1000},
                new ProductModel() {Id = 2,Name ="Iphone 11",Price = 1100},
                new ProductModel() {Id = 3,Name ="Iphone 12",Price = 1200},
                new ProductModel() {Id = 4,Name ="Iphone 13",Price = 1300},
                new ProductModel() {Id = 5,Name ="Iphone 14",Price = 1400},
            });
        }
    }
}