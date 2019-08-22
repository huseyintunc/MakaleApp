using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Makaleler.Business.Abstract;
using Makaleler.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Makaleler.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        private readonly IKategoriService _service;

        public KategorilerController(IKategoriService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var list = _service.GetAll();
            if (list.Count()>0)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("{kategoriId}")]
        [Route("list")]
        public IActionResult Get(int kategoriId)
        {
            var result = _service.GetById(kategoriId);
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Could not find the category");
            }
        }

        [HttpPost]
        [Route("add")]
        [Authorize]
        public IActionResult AddKategori([FromBody] Kategori kategori)
        {
            try
            {
                _service.Add(kategori);
                return Ok(kategori);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public IActionResult Update(int kategoriId,[FromBody] Kategori kategori)
        {
            try
            {
                if (_service.GetById(kategoriId)!=null)
                {
                    _service.Update(kategori);
                    return Ok(kategori);
                }
                else
                {
                    return NotFound("Kategori Bulunamadı!.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete(int kategoriId)
        {
            try
            {
                if (_service.GetById(kategoriId) != null)
                {
                    _service.Delete(kategoriId);
                    return Ok();
                }
                else
                {
                    return NotFound("Kategori Bulunamadı");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}