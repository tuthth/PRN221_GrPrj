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
    }
}
