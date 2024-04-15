using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DotNetEFCoreBench;

[MemoryDiagnoser]
public class EfCoreBenchmarks
{
    private StoreContext _dbContext;
    private static readonly Func<StoreContext, int, IEnumerable<Order>> _ordersByCustomerIdQuery = 
        EF.CompileQuery((StoreContext context, int customerId) => 
            context.Orders.Where(o => o.CustomerId == customerId));

    [GlobalSetup]
    public void Setup()
    {
        _dbContext = new StoreContext();
        if (!_dbContext.Products.Any())
        {
            _dbContext.Products.AddRange(Enumerable.Range(1, 1000).Select(i => new Product { Price = i }));
            _dbContext.Orders.AddRange(Enumerable.Range(1, 1000).Select(i => new Order { CustomerId = i % 10 }));
            _dbContext.SaveChanges();
        }
    }

    [Benchmark]
    public void LinqToEntities()
    {
        var productsQuery = _dbContext.Products.Where(p => p.Price > 10);
        var products = productsQuery.ToList();
    }

    [Benchmark]
    public void CompiledQuery()
    {
        var orders = _ordersByCustomerIdQuery(_dbContext, 1).ToList();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<EfCoreBenchmarks>();
    }
}