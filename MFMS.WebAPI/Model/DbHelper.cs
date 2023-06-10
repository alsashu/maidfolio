using MFMS.WebAPI.EFCore;

namespace MFMS.WebAPI.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// To get the product
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> response = new List<ProductModel>();
            var data = _context.Products.ToList();
            data.ForEach(row => response.Add(new ProductModel()
            {
                brand = row.brand,
                id = row.id,
                name = row.name,
                price = row.price,
                size = row.size,
            }));
            return response;
        }

        /// <summary>
        /// PUT/POST/PATCH
        /// </summary>
        /// <param name="orderModel"></param>
        public void SaveOrder(OrderModel orderModel)
        {
            Order dbTable = new Order();
            if (orderModel.id > 0)
            {
                //PUT
                dbTable = _context.Orders.Where(t => t.id.Equals(orderModel.id)).FirstOrDefault();
                if (dbTable != null)
                {
                    dbTable.phone = orderModel.phone;
                    dbTable.address = orderModel.address;
                }
            }
            else
            {
                //POST
                dbTable.phone = orderModel.phone;
                dbTable.address = orderModel.address;
                dbTable.name = orderModel.name;
                dbTable.Product = _context.Products.Where(t => t.id.Equals(orderModel.product_id)).FirstOrDefault();
                _context.Orders.Add(dbTable);
            }
            _context.SaveChanges();
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleatOrder(int id)
        {
            var order = _context.Orders.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Get by Id
        /// </summary>
        /// <param name="id"></param>
        public ProductModel GetProductById(int id)
        {
            var row = _context.Products.Where(t => t.id.Equals(id)).FirstOrDefault();
            if (row != null)
            {
                return new ProductModel
                {
                    brand = row.brand,
                    id = row.id,
                    name = row.name,
                    price = row.price,
                    size = row.size,
                };
            }
            return null;
        }
    }
}
