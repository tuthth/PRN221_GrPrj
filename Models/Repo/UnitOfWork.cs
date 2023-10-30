using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo
{
    public class UnitOfWork
    {
        private BirdCageManagementsContext _context = new BirdCageManagementsContext();
        private Repository<Customer> customers;
        private Repository<Expense> expenses;
        private Repository<Order> orders;
        private Repository<Inventory> inventories;
        private Repository<Material> materials;
        private Repository<OrderItem> orderItems;
        private Repository<Product> products;
        private Repository<ProductionStep> productionSteps;
        private Repository<Staff> staffs;
        private Repository<WorkOn> workOns;

        public Repository<Customer> Customers => customers ??= new Repository<Customer>(_context);
        public Repository<Expense> Expenses => expenses ??= new Repository<Expense>(_context);
        public Repository<Order> Orders => orders ??= new Repository<Order>(_context);
        public Repository<Inventory> Inventories => inventories ??= new Repository<Inventory>(_context);
        public Repository<Material> Materials => materials ??= new Repository<Material>(_context);
        public Repository<OrderItem> OrderItems => orderItems ??= new Repository<OrderItem>(_context);
        public Repository<Product> Products => products ??= new Repository<Product>(_context);
        public Repository<ProductionStep> ProductionSteps => productionSteps ??= new Repository<ProductionStep>(_context);
        public Repository<Staff> Staffs => staffs ??= new Repository<Staff>(_context);
        public Repository<WorkOn> WorkOns => workOns ??= new Repository<WorkOn>(_context);
        public async Task SaveChange() => await _context.SaveChangesAsync();

    }
}
