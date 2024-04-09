using GKKVWT_HFT_2023241.Endpoint.Services;
using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GKKVWT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        IArtistLogic logic;
        IHubContext<SignalRHub> hub;
        public ArtistController(IArtistLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ArtistCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Artist value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ArtistUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var artistToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ArtistDeleted", artistToDelete);
        }
    }
}
