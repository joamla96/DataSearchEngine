using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManagementAPI.Interfaces;
using FileManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileManagementAPI.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class FileController : ControllerBase {
		private IFileRepository _fileRepository;

		public FileController(IFileRepository fileRepository) {
			this._fileRepository = fileRepository;
		}

		// GET api/values
		[HttpGet]
		public async Task<IActionResult> Get() {
			return NotFound("Method not implemented");
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id) {
			return NotFound("Method not implemented");
		}

		// POST api/values
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] FileDTO value) {
			await _fileRepository.Insert(value);
			return Ok();
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] FileDTO value) {
			return NotFound("Method not implemented");
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id) {
			return NotFound("Method not implemented");
		}
	}
}
