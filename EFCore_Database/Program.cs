// See https://aka.ms/new-console-template for more information
using EFCore_Database.Entities;
using Microsoft.EntityFrameworkCore;

static void CreateDatabase()
{
    using var dbContext = new DBProductManagement();
    string dbName = dbContext.Database.GetDbConnection().Database;
    Console.WriteLine("Ten co so du lieu duoc tao la: " + dbName);
    var kq = dbContext.Database.EnsureCreated();
    if (kq)
    {
        Console.WriteLine($"Tao database {dbName} thanh cong");
    }
    else
    {
        Console.WriteLine($"Tao database {dbName} that bai");
    }
}

static void DeleteDatabase()
{
    using var dbContext = new DBProductManagement();
    string dbName = dbContext.Database.GetDbConnection().Database;
    Console.WriteLine("Ten co so du lieu duoc tao la: " + dbName);
    var kq = dbContext.Database.EnsureDeleted();
    if (kq)
    {
        Console.WriteLine($"Xoa database {dbName} thanh cong");
    }
    else
    {
        Console.WriteLine($"Xoa database {dbName} that bai");
    }
}

static void InsertProduct(Product product)
{
    using var dbContext = new DBProductManagement();
    dbContext.Products.Add(product);
    int kq = dbContext.SaveChanges();
    Console.WriteLine($"Da chen {kq} dong du lieu");
}

static void ReadProducts()
{
    using var dbContext = new DBProductManagement();
    var products = dbContext.Products.ToList();
    //var products = dbContext.Products.Where(p=>p.Provider == "Nha Cung cap 1").ToList();
    products.ForEach(p => p.PrintInfor());
}

static void UpdateProduct(Product pro)
{
    using var dbContext = new DBProductManagement();
    var product = dbContext.Products.Where(p=>p.ProductID == pro.ProductID).FirstOrDefault();
    if (product != null)
    {
        product.ProductName = pro.ProductName;
        product.Provider = pro.Provider;
        dbContext.Update(product);
    }
    int kq = dbContext.SaveChanges();
    Console.WriteLine($"Da cap nhat {kq} dong du lieu");
}

static void DeleteProduct(int productID)
{
    using var dbContext = new DBProductManagement();
    var product = dbContext.Products.Where(p => p.ProductID == productID).FirstOrDefault();
    dbContext.Products.Remove(product);
    int kq = dbContext.SaveChanges();
    Console.WriteLine($"Da xoa {kq} dong du lieu");
}
//CreateDatabase();
//DeleteDatabase();
//InsertProduct(new Product("San pham 4", "Nha Cung cap 1"));
//UpdateProduct(new Product(1,"San pham 1", "Nha Cung cap 1"));
DeleteProduct(3);
ReadProducts();