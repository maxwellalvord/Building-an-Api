


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatPark.Models;

namespace NatPark.Controllers
{

  [Route("api/[controller]")] // api/parks?
  [Produces("application/json")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly NatParkContext _db;

    public ParksController(NatParkContext db)
    {
      _db = db;
    }

    /// <summary>
    /// Grabs a list of Parks.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="name"></param>
    /// <param name="popularity"></param>
    // GET api/Parks
    [HttpGet]
    public async Task<List<Park>> Get(string state, string name, int popularity)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (popularity > 0)
      {
        query = query.Where(entry => entry.Popularity >= popularity);
      }

      return await query.ToListAsync();
    }

    /// <summary>
    /// Creates a Park.
    /// </summary>
    /// <param name="park"></param>
    /// <returns>A newly created Park</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Park
    ///     {
    ///        "ParkId": 1,
    ///        "Name": "Garage #1",
    ///        "State": "Portland",
    ///        "Popularity": 5,
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created park</response>
    /// <response code="400">If the park is null</response>
    // POST api/Parks
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }

    /// <summary>
    /// Deletes a specific park.
    /// </summary>
    /// <param name ="id"></param>
    /// <returns></returns>
    // DELETE: api/Parks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePark(int id)
    {
      var park = await _db.Parks.FindAsync(id);
      if (park == null)
      {
        return NotFound();
      }

      _db.Parks.Remove(park);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}
