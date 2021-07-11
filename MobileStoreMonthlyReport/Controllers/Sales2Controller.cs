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
    [ApiController]
    [Route("[controller]")]
    public class Sales2Controller : ControllerBase
    {
        private IGenericCRUD<Sales> _salesData;
        public Sales2Controller(IGenericCRUD<Sales> salesData)
        {
            _salesData = salesData;
        }

        [HttpGet]
        [Route("api/[controller]/GetAll")]
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
