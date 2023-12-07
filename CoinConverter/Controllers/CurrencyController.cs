using CoinConverter.Entities;
using CoinConverter.Models.DTO;
using CoinConverter.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CoinConverter.Controllers
{
    [Route("api/currency")]
    [ApiController]
    [Authorize]

    public class CurrencyController : Controller
    {
        private readonly ICurrencyServices _currencyServices;
        public CurrencyController(ICurrencyServices currencyServices)
        {
            _currencyServices = currencyServices;
        }

        [HttpPost]
        public IActionResult CreateCurrency(CurrencyForCreation_Update dto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            try
            {
                _currencyServices.Create(dto, userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex + "error aca");
            }
            return Created("Created", dto);
        }

        [HttpDelete]
        public IActionResult DeleteCurrency(int id)
        {
            Currency currency = _currencyServices.GetById(id);
            if (currency is null)
            {
                return BadRequest("Not existing id");
            }
            else
            {
                _currencyServices.Delete(id);
            }
            return NoContent();

        }

        [HttpPut("{currencyId}")]
        public IActionResult UpdateCurrency(CurrencyForCreation_Update dto, int currencyId)
        {
            if (!_currencyServices.CheckIfCurrencyExists(currencyId))
            {
                return NotFound();
            }
            try
            {
                _currencyServices.Update(dto, currencyId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetCurrency(int currencyId)
        {
                if (currencyId == 0)
                {
                    return BadRequest("El ID ingresado debe ser distinto de 0");
                }

                Currency? currency = _currencyServices.GetById(currencyId);

                if (currency is null)
                {
                    return NotFound();
                }

                return Ok(currency);

            }

        [HttpGet("GetAll")]
        public IActionResult GetAllCurrencies()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            return Ok(_currencyServices.GetAllCurrencies(userId));
        }

        [HttpGet("Convertions")]
        public IActionResult ConvertCurrency([FromQuery] CurrencyConvertionRequest request)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier"))!.Value);
            try
            {
                Currency fromCurrency = _currencyServices.GetById(request.FromCurrencyId);
                Currency toCurrency = _currencyServices.GetById(request.ToCurrencyId);

                if (fromCurrency == null || toCurrency == null)
                {
                    return BadRequest("Moneda no encontrada");
                }

                // Calcular la conversión basada en el índice de conversión y el total
                float conversionResult = _currencyServices.ConvertCurrency(fromCurrency, toCurrency, request.Amount, userId);

                return Ok(conversionResult);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error en la conversión de moneda: {ex.Message}");
            }
        }

        


        
    }

    }



  

