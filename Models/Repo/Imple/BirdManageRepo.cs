using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repo.Imple
{
    public class BirdManageRepo
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public List<Product> getAllProducts() => unitOfWork.Products.GetAll().ToList();
        public Product getProductById(int id) => unitOfWork.Products.FirstOrDefault(c => c.ProductId == id);
        public async Task updateProduct(Product product)
        {
            unitOfWork.Products.Update(product);
            await unitOfWork.SaveChange();
        }
        public async Task deleteProduct(Product product)
        {
            unitOfWork.Products.Remove(product);
            await unitOfWork.SaveChange();
        }
        public async Task addProduct(Product product)
        {
            unitOfWork.Products.Add(product);
            await unitOfWork.SaveChange();
        }
        public List<ProductionStep> GetProductionSteps() => unitOfWork.ProductionSteps.GetAll().ToList();
        public async Task updateProductionStep(ProductionStep productionStep)
        {
            unitOfWork.ProductionSteps.Update(productionStep);
            await unitOfWork.SaveChange();
        }
        public async Task createProductionStep(ProductionStep productionStep)
        {
            unitOfWork.ProductionSteps.Add(productionStep);
            await unitOfWork.SaveChange();
        }
        public async Task deleteProductionStep(ProductionStep productionStep)
        {
            unitOfWork.ProductionSteps.Remove(productionStep);
            await unitOfWork.SaveChange();
        }
        public ProductionStep getProductionStep(int id) => unitOfWork.ProductionSteps.FirstOrDefault(c => c.StepId == id);
        public Staff getStaff(int id) => unitOfWork.Staffs.FirstOrDefault(c => c.StaffId == id);
        public async Task updateStaff(Staff staff)
        {
            unitOfWork.Staffs.Update(staff);
            await unitOfWork.SaveChange();
        }
        public async Task deleteStaff(Staff staff)
        {
            unitOfWork.Staffs.Remove(staff);
            await unitOfWork.SaveChange();
        }
        public async Task createStaff(Staff staff)
        {
            unitOfWork.Staffs.Add(staff);
            await unitOfWork.SaveChange();
        }
        public List<Staff> getAllStaffs() => unitOfWork.Staffs.GetAll().ToList();
    }

}
