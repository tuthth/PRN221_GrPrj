using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo.Interface
{
    public interface InterfaceRepo
    {
    }
    public interface ICustomerRepo : IRepository<Customer>
    {
    }
    public interface IExpenseRepo : IRepository<Expense>
    {
    }
    public interface IInventoryRepo : IRepository<Inventory>
    {
    }
    public interface IMaterialRepo : IRepository<Material>
    {
    }
    public interface IOrderRepo : IRepository<Order>
    {
    }
    public interface IOrderItemRepo : IRepository<OrderItem>
    {
    }
    public interface IProductRepo : IRepository<Product>
    {
    }
    public interface IProductionStepRepo : IRepository<ProductionStep>
    {
    }
    public interface IStaffRepo : IRepository<Staff>
    {
    }
    public interface IWorkOnRepo : IRepository<WorkOn>
    {
    }
}
