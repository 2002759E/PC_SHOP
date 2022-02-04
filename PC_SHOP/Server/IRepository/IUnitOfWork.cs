
using Microsoft.AspNetCore.Http;
using PC_SHOP.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_SHOP.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Condition> Conditions { get; }
        IGenericRepository<Item> Items { get; }
        IGenericRepository<ListItem> ListItems { get; }
        IGenericRepository<PurchaseRequest> PurchaseRequests { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<TradeRequest> TradeRequests { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<TransactionHistory> TransactionsHistory { get; }
    }
}