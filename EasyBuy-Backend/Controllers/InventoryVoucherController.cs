﻿using EasyBuy_Backend.Models;
using EasyBuy_Backend.Repositories.InventoryVoucherRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyBuy_Backend.Controllers
{
    //localhost:xxxx/api/Category
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryVoucherController : ControllerBase
    {
        private readonly IInventoryVoucherRepository _inventoryVoucherRepository;

        public InventoryVoucherController(IInventoryVoucherRepository inventoryVoucherRepositor)
        {
            _inventoryVoucherRepository = inventoryVoucherRepositor;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var inventoryVouchers = _inventoryVoucherRepository.GetAll();

            return Ok(inventoryVouchers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inventoryVoucher = _inventoryVoucherRepository.GetById(id);

            return Ok(inventoryVoucher);
        }

        [HttpPost]
        public IActionResult Create([FromBody] InventoryVoucher inventoryVoucher)
        {
            if (_inventoryVoucherRepository.Create(inventoryVoucher))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] InventoryVoucher inventoryVoucher, int id)
        {
            inventoryVoucher.Id = id;
            if (_inventoryVoucherRepository.Update(inventoryVoucher))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inventoryVoucher = _inventoryVoucherRepository.GetById(id);

            if (_inventoryVoucherRepository.Delete(inventoryVoucher))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
