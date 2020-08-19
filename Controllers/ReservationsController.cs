using System.Linq;
using ExpressoAPI.Data;
using ExpressoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpressoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ExpressoDbContext _expressoDbContext;
        public ReservationsController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;

        }

        [HttpPost]
        public IActionResult Post(Reservation reservation){
            _expressoDbContext.Reservations.Add(reservation);
            _expressoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public IActionResult GetTodos(){
            var reservas = _expressoDbContext.Reservations;
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public IActionResult GetUm(int id){
            var reservas = _expressoDbContext.Reservations.FirstOrDefault(r=>r.Id==id);
            if(reservas==null){
                return NotFound();
            }else{
            return Ok(reservas.Name+" - "+reservas.Email+" - "+reservas.Date+" - "+reservas.Time);
            }
        }
    }
}