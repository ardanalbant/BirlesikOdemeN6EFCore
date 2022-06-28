using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BirlesikOdemeN6EFCore.Configuration;
using BirlesikOdemeN6EFCore.Models;

namespace BirlesikOdemeN6EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerRepository : ControllerBase
    {
        
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.Customer.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var item = await _unitOfWork.Customer.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                Customer.Id = Guid.NewGuid();

                await _unitOfWork.Customer.Add(Customer);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetCustomer", new { Customer.Id }, Customer);
            }

            return new JsonResult("Something Went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var item = await _unitOfWork.Customer.GetById(id);

            if (item == null)
                return BadRequest();

            await _unitOfWork.Customer.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
