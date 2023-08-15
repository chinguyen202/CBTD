using CBTD.DataAccess.Data;
using CBTD.DataAccess.Models;
using CBTD.Infrastructure.Interfaces;

namespace CBTD.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;  //dependency injection of Data Source

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        } 

        private IGenericRepository<Category> _category;
        private IGenericRepository<Manufacturer> _manufacturer;
        private IGenericRepository<Product> _product;
        private IGenericRepository<ShoppingCart> _shoppingCart;

        private IGenericRepository<ApplicationUser> _applicationUser;
        //ADD ADDITIONAL MODELS HERE

        public IGenericRepository<Category> Category
        {
            get
            {

                if (_category == null)
                {
                    _category = new GenericRepository<Category>(_dbContext);
                }

                return _category;
            }
        }
        public IGenericRepository<Manufacturer> Manufacturer
        {
            get
            {

                if (_manufacturer == null)
                {
                    _manufacturer = new GenericRepository<Manufacturer>(_dbContext);
                }

                return _manufacturer;
            }
        }
        public IGenericRepository<Product> Product
        {
            get
            {

                if (_product == null)
                {
                    _product = new GenericRepository<Product>(_dbContext);
                }

                return _product;
            }
        }
        
        public IGenericRepository<ApplicationUser> ApplicationUser
        {
            get
            {

                if (_applicationUser == null)
                {
                    _applicationUser = new GenericRepository<ApplicationUser>(_dbContext);
                }

                return _applicationUser;
            }
        }
        public IGenericRepository<ShoppingCart> ShoppingCart
        {
            get
            {

                if (_shoppingCart == null)
                {
                    _shoppingCart = new GenericRepository<ShoppingCart>(_dbContext);
                }

                return _shoppingCart;
            }
        }
        

        // public IGenericRepository<Manufacturer> Manufacturer => throw new NotImplementedException();

        // public IGenericRepository<Product> Product => throw new NotImplementedException();

        //ADD ADDITIONAL METHODS FOR EACH MODEL (similar to Category) HERE

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        //additional method added for garbage disposal

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
