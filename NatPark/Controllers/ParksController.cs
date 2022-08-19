


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NatPark.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
    // GET api/parks
    [HttpGet]
    public async Task<List<Park>> Get(string location, string name, int popularity)
    {
      IQueryable<Park> query = _db.Parks.AsQueryable();

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
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
    /// <param name="location"></param>
    /// <param name="name"></param>
    /// <param name="popularity"></param>
    /// <returns>A newly created Park</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Park
    ///     {
    ///        "ParkId": 1,
    ///        "Name": "Garage #1",
    ///        "Location": "Portland",
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
    // DELETE: api/parks/5
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

    /// <summary>
    /// modifies a specific park.
    /// </summary>
    /// <param name="park"></param>
    /// <param name="id"></param>
    /// <returns>A newly updated Park</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT api/Parks/5
    ///     {
    ///        "ParkId": 1,
    ///        "Name": "Crater Lake",
    ///        "Location": "Portland",
    ///        "Popularity": 7,
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly updated park</response>
    /// <response code="400">If the park is null</response>
    // PUT: api/parks/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, Park park)
    {
      if (id != park.ParkId)
      {
        return BadRequest();
      }

      _db.Entry(park).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ParkExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    /// <summary>
    /// Grabs a specific Park by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A specific Park</returns>
    // GET: api/parks/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Park>> GetPark(int id)
    {
        var park = await _db.Parks.FindAsync(id);

        if (park == null)
        {
            return NotFound();
        }

        return park;
    }

    /// <summary>
    /// Grabs a random Park.
    /// </summary>
    /// <returns>A random Park</returns>
    // GET: api/parks/random
    [HttpGet("random")]
    public async Task<ActionResult<Park>> RanPark()
    {
        using(HttpClient client = new HttpClient())
        {
            var result = await client.GetAsync("http://localhost:5004/api/parks");
            if(result.IsSuccessStatusCode)
            {
              var parkListString = await result.Content.ReadAsStringAsync();
              var parkList = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Park>>(parkListString);;
              return parkList.ElementAt(new Random().Next(0, parkList.Count() -1));
            }
            else
            {
                return NotFound();
            }
        }        
    }

     private bool ParkExists(int id)
    {
      return _db.Parks.Any(e => e.ParkId == id);
    }
  }
}
