using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class DataAccessUtility
    {
        private readonly OMSContext _context;

        public DataAccessUtility(OMSContext context)
        {
            _context = context;
        }

        // Get all shoppers from the database
        public async Task<List<Shopper>> GetAllShoppersAsync()
        {
            return await _context.Shoppers.ToListAsync();
        }

        // Get all baskets for a particular shopper
        public async Task<List<Basket>> GetBasketsForShopperAsync(int shopperId)
        {
            return await _context.Baskets
                .Where(b => b.IdShopper == shopperId)
                .ToListAsync();
        }

        // Get all basket items for a particular basket
        public async Task<List<BasketItem>> GetBasketItemsForBasketAsync(int basketId)
        {
            return await _context.BasketItems
                .Where(bi => bi.IdBasket == basketId)
                .ToListAsync();
        }

        // Get all products from the database
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Save changes to the database
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

