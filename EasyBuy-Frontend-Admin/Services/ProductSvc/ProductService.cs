﻿using EasyBuy_Frontend_Admin.Models;
using System.Diagnostics;
using System.Text.Json;

namespace EasyBuy_Frontend_Admin.Services.ProductSvc
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7084");
        }

		public async Task<List<ProductViewModel>> GetProductsAsync()
		{
			List<ProductViewModel> products = new List<ProductViewModel>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync("/api/Product");
				string data = await response.Content.ReadAsStringAsync();
				products = JsonSerializer.Deserialize<List<ProductViewModel>>(data);
				Debug.WriteLine("An error occurred: " ,data);

			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred: " + ex.Message);
			}
			return products;
		}
		public async Task<bool> AddProductAsync(ProductViewModel product)
		{
			try
			{
				Debug.WriteLine($"Status: {product.Status}");
				var response = await _httpClient.PostAsJsonAsync("/api/Product", product);

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while adding product: " + ex.Message);
				return false;
			}
		}

		public async Task<ProductViewModel> GetProductByIdAsync(int id)
		{
			ProductViewModel product = null;

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"/api/Product/{id}");

				if (response.IsSuccessStatusCode)
				{
					string data = await response.Content.ReadAsStringAsync();
					product = JsonSerializer.Deserialize<ProductViewModel>(data);
				}
				else
				{
					Debug.WriteLine("Failed to retrieve product. Status code: " + response.StatusCode);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while getting product: " + ex.Message);
			}

			return product;
		}

		public async Task<bool> UpdateProductAsync(ProductViewModel product)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"/api/Product/{product.Id}", product);

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while updating product: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> DeleteProductAsync(int id)
		{
			try
			{
				var response = await _httpClient.DeleteAsync($"/api/Product/{id}");

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while deleting product: " + ex.Message);
				return false;
			}
		}

	}
}
