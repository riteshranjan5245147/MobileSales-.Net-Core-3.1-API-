using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileStoreMonthlyReport.MobileSalesData;
using MobileStoreMonthlyReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreMonthlyReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private IGenericCRUD<Sales> _salesData;
        public SalesController(IGenericCRUD<Sales> salesData)
        {
            _salesData = salesData;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_salesData.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public IActionResult Add(Sales sale)
        {
            try
            {
                return Ok(_salesData.Insert(sale));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _salesData.GetById(id);
                if (result == null)
                {
                    return Ok("No such sale found");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        [Route("Update")]
        public IActionResult Update(Sales sale)
        {
            try
            {
                return Ok(_salesData.Update(sale));
            }
            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                {
                    return Ok("No such sale found");
                }
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _salesData.Delete(id);
                return Ok($"Successfully deleted sale with id {id}");
            }
            catch (Exception ex)
            {
                if (ex.GetType().ToString() == "System.ArgumentNullException")
                {
                    return Ok("No such sale found");
                }
                return StatusCode(500, ex.InnerException.Message);
            }
        }

    }
}
