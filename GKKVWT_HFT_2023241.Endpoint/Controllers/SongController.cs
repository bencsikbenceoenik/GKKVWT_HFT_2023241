using GKKVWT_HFT_2023241.Endpoint.Services;
using GKKVWT_HFT_2023241.Logic.Interfaces;
using GKKVWT_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace GKKVWT_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic logic;
        IHubContext<SignalRHub> hub;
        public SongController(ISongLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("SongCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Song value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("SongUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var songToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("SongDeleted", songToDelete);
        }
    }
}
