﻿using EasyBuy_Frontend_Admin.Models;
using System.Diagnostics;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EasyBuy_Frontend_Admin.Services.VoucherSvc
{
	public class VoucherService : IVoucherService
	{
		private readonly HttpClient _httpClient;

		public VoucherService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_httpClient.BaseAddress = new Uri("https://localhost:7084");
		}
		public async Task<List<VoucherViewModel>> GetVouchersAsync()
		{
			List<VoucherViewModel> vouchers = new List<VoucherViewModel>();

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync("/api/Voucher");

				string data = await response.Content.ReadAsStringAsync();
				vouchers = JsonSerializer.Deserialize<List<VoucherViewModel>>(data);

			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred: " + ex.Message);
			}

			return vouchers;
		}

		public async Task<bool> AddVoucherAsync(VoucherViewModel voucher)
		{
			voucher.Id = "abcdf";
			try
			{
				var res = await _httpClient.GetAsync("/api/Voucher/getLatestId");

				if (res.IsSuccessStatusCode) {
					string data = await res.Content.ReadAsStringAsync();
					Debug.WriteLine("Response Data: " + data);
					voucher.Id = data;
				}
				else {
					return false;
				}

				var response = await _httpClient.PostAsJsonAsync("/api/Voucher", voucher);

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while adding voucher: " + ex.Message);
				return false;
			}
		}

		public async Task<VoucherViewModel> GetVoucherByIdAsync(string id)  
		{
			VoucherViewModel voucher = null;

			try
			{
				HttpResponseMessage response = await _httpClient.GetAsync($"/api/Voucher/{id}");

				if (response.IsSuccessStatusCode)
				{
					string data = await response.Content.ReadAsStringAsync();
					voucher = JsonSerializer.Deserialize<VoucherViewModel>(data);
				}
				else
				{
					Debug.WriteLine("Failed to retrieve voucher. Status code: " + response.StatusCode);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while getting voucher: " + ex.Message);
			}

			return voucher;
		}

		public async Task<bool> UpdateVoucherAsync(VoucherViewModel voucher)
		{
			try
			{
				var response = await _httpClient.PutAsJsonAsync($"/api/Voucher/{voucher.Id}", voucher);

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while updating voucher: " + ex.Message);
				return false;
			}
		}

		public async Task<bool> DeleteVoucherAsync(string id) 
		{
			try
			{
				var response = await _httpClient.DeleteAsync($"/api/Voucher/{id}");

				if (response.IsSuccessStatusCode)
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				Debug.WriteLine("An error occurred while deleting voucher: " + ex.Message);
				return false;
			}
		}
	}
}
