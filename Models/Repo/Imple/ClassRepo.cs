using Models.Models;
using Models.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo.Imple
{
    public class ClassRepo
    {
    }
    public class CustomerRepo : Repository<Customer>, ICustomerRepo
    {
        public CustomerRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class ExpenseRepo : Repository<Expense>, IExpenseRepo
    {
        public ExpenseRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class InventoryRepo : Repository<Inventory>, IInventoryRepo
    {
        public InventoryRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class MaterialRepo : Repository<Material>, IMaterialRepo
    {
        public MaterialRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class OrderRepo : Repository<Order>, IOrderRepo
    {
        public OrderRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class ProductionStepRepo : Repository<ProductionStep>, IProductionStepRepo
    {
        public ProductionStepRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class StaffRepo : Repository<Staff>, IStaffRepo
    {
        public StaffRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
    public class WorkOnRepo : Repository<WorkOn>, IWorkOnRepo
    {
        public WorkOnRepo(BirdCageManagementsContext context) : base(context)
        {
        }
    }
}
