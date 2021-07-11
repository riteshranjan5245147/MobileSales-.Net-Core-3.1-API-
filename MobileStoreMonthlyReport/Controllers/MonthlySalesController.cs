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
    public class MonthlySalesController : ControllerBase
    {
        private IGenericCRUD<Sales> _salesData;
        public MonthlySalesController(IGenericCRUD<Sales> salesData)
        {
            _salesData = salesData;
        }

        [HttpGet]
        [Route("GetMonthlySales/{fromDate}/{toDate}")]
        public IActionResult GetMonthlySales(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var allData = _salesData.GetAll();
                var requiredData = allData.FindAll(x => x.DateOfSelling >= fromDate && x.DateOfSelling <= toDate);
                if (requiredData.Count > 0)
                {
                    return Ok(requiredData);
                }
                else
                {
                    return Ok("No Data Found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

        [HttpGet]
        [Route("GetMonthlyBrandWiseSales/{fromDate}/{toDate}")]
        public IActionResult GetMonthlyBrandWiseSales(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var allData = _salesData.GetAll();
                var requiredData = allData.FindAll(x => x.DateOfSelling >= fromDate && x.DateOfSelling <= toDate).OrderBy(y=>y.ProductName).ToList();
                if (requiredData.Count > 0)
                {
                    return Ok(requiredData);
                }
                else
                {
                    return Ok("No Data Found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.InnerException.Message);
            }
        }

    }
}
