using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GKKVWT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic logic;
        public ArtistController(IArtistLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Artist> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Artist Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Artist value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
