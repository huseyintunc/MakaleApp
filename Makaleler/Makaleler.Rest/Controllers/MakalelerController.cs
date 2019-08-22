using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class MakalelerController : ControllerBase
    {
        private readonly IMakaleService _service;

        public MakalelerController(IMakaleService service)
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


        [HttpGet]
        [Route("makale")]
        public IActionResult Get(int id)
        {
            var makale = _service.GetById(id);

            if (makale!=null)
            {
                return Ok(makale);
            }
            else
            {
                return NotFound("Could not find the makale");
            }
        }


        [HttpGet]
        [Route("kategoriMakale")]
        public IActionResult GetKategoriById(int id)
        {
            var makale = _service.GetAll().Where(_=>_.KategoriId==id);

            if (makale != null)
            {
                return Ok(makale);
            }
            else
            {
                return NotFound("Could not find the makale");
            }
        }


        [HttpGet]
        [Route("search")]
        public IActionResult GetSearchAll(string search)
        {
            var makaleSearch = _service.GetSearchAll(search);

            if (makaleSearch.Count()>0)
            {
                return Ok(makaleSearch);
            }
            else
            {
                return NotFound("Could not find the makale");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("add")]
        public IActionResult Add([FromBody]Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                makale.EklenmeTarihi = DateTime.Now;
                makale.YazarId = GetYazarId();
                _service.Add(makale);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public IActionResult Update(int makaleId,[FromBody]Makale makale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                try
                {
                    var model = _service.GetById(makaleId);
                    if (model==null)
                    {
                        return NotFound();
                    }

                    else
                    {
                        if (model.YazarId!=GetYazarId())
                        {
                            return BadRequest("Bu Makale Başka Bir yazarımıza aittir.");
                        }
                        makale.YazarId = GetYazarId();
                        makale.GuncellenmeTarihi = DateTime.Now;
                        _service.Update(makale);
                        return Ok();
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }

        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public IActionResult Delete(int makaleId)
        {
            try
            {
                if (_service.GetById(makaleId)!=null)
                {
                    _service.Delete(makaleId);
                    return Ok();
                }
                else
                {
                    return NotFound("Makale Bulunamadı!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        public int GetYazarId()
        {
            return int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

    }
}
