
using PC_SHOP.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PC_SHOP.Server.Data;
using PC_SHOP.Server.IRepository;
using PC_SHOP.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PC_SHOP.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Brand> _brands;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Condition> _conditions;
        private IGenericRepository<Item> _items;
        private IGenericRepository<ListItem> _listitems;
        private IGenericRepository<PurchaseRequest> _purchaserequests;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<TradeRequest> _traderequests;
        private IGenericRepository<Review> _reviews;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Brand> Brands
            => _brands ??= new GenericRepository<Brand>(_context);
        public IGenericRepository<Category> Categories
            => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<Condition> Conditions
            => _conditions ??= new GenericRepository<Condition>(_context);
        public IGenericRepository<Item> Items
            => _items ??= new GenericRepository<Item>(_context);
        public IGenericRepository<ListItem> ListItems
            => _listitems ??= new GenericRepository<ListItem>(_context);
        public IGenericRepository<PurchaseRequest> PurchaseRequests
            => _purchaserequests ??= new GenericRepository<PurchaseRequest>(_context);
        public IGenericRepository<Payment> Payments
            => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<TradeRequest> TradeRequests
            => _traderequests ??= new GenericRepository<TradeRequest>(_context);
        public IGenericRepository<Review> Reviews
            => _reviews ??= new GenericRepository<Review>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user.UserName;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user.UserName;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}