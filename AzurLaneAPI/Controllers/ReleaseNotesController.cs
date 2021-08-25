using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzurLaneClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzurLaneAPI.Controllers
{
	public class ReleaseNotesController : Controller
	{
		private AzurLaneDbContext _context;

		public ReleaseNotesController(AzurLaneDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieve all the release notes 
		/// </summary>
		[HttpGet(Routes.V1.Routes.ReleaseNotes.GetAll)]
		public async Task<ActionResult<List<ALReleaseNote>>> GetAllReleaseNotes()
		{
			try
			{
				return await _context.ReleaseNotes.ToListAsync();
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		/// <summary>
		/// Get the latest release note
		/// </summary>
		[HttpGet(Routes.V1.Routes.ReleaseNotes.GetLatest)]
		public async Task<ActionResult<ALReleaseNote>> GetLatestReleaseNote()
		{
			try
			{
				return await _context.ReleaseNotes.LastAsync();
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		/// <summary>
		/// Get a release note by id
		/// </summary>
		/// <param name="id">Release note id</param>
		[HttpGet(Routes.V1.Routes.ReleaseNotes.GetId)]
		public async Task<ActionResult<ALReleaseNote>> GetReleaseNoteById(Int32 id)
		{
			try
			{
				if (await _context.ReleaseNotes.AnyAsync(r => r.Id == id))
				{
					return await _context.ReleaseNotes.SingleAsync(r => r.Id == id);
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		[HttpGet(Routes.V1.Routes.ReleaseNotes.GetVersion)]
		public async Task<ActionResult<ALReleaseNote>> GetReleaseNoteByVersion(String version)
		{
			try
			{
				if (await _context.ReleaseNotes.AnyAsync(r => r.Version == version))
				{
					return await _context.ReleaseNotes.SingleAsync(r => r.Version == version);
				}
				else
				{
					return NotFound(Errors.V1.Errors.X400.ResourceWithIdDoesNotExist);
				}
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}

		/// <summary>
		/// (Developer Only) Create a new release note
		/// </summary>
		/// <param name="releaseNote"><see cref="ALReleaseNote" /> object</param>
		[HttpPost(Routes.V1.Routes.ReleaseNotes.Create)]
		public async Task<ActionResult<ALReleaseNote>> CreateReleaseNote([FromBody] ALReleaseNote releaseNote)
		{
			try
			{
                if (await _context.ReleaseNotes.AnyAsync(r => r.Version == releaseNote.Version))
                {
                    return BadRequest("A release note with that version already exists");
                }

                if (await _context.ReleaseNotes.AnyAsync(r => r.Title == releaseNote.Title))
                {
                    return BadRequest("A release note with that title already exists");
                }

				await _context.ReleaseNotes.AddAsync(releaseNote);
				await _context.SaveChangesAsync();
				return releaseNote;
			}
			catch
			{
				return StatusCode(500, Errors.V1.Errors.X500.RequestFailure);
			}
		}
	}
}