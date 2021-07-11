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
        [Route("GetById")]
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
        [Route("Update")]
        public IActionResult Update(Sales sale)
        {
            try
            {
                var result = _salesData.GetById(sale.Id);
                if (result == null)
                {
                    return Ok("No such sale found");
                }
                else
                {
                    return Ok(_salesData.Update(sale));
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
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
                    _salesData.Delete(id);
                    return Ok($"Successfully deleted sale with id {id}");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

    }
}
