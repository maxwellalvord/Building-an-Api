


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

  }
}
