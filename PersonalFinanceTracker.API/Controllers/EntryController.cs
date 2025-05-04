using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.API.Interfaces;
using PersonalFinanceTracker.API.Models;
using PersonalFinanceTracker.Shared.DTOs;

namespace PersonalFinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntryController : BaseController<Entry, EntryController>
    {
        public EntryController(IRepository<Entry> repository, IMapper mapper, ILogger<EntryController> logger)
            : base(repository, mapper, logger)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var entries = await _repository.GetAllAsync();
                return Ok(_mapper.Map<List<EntryDto>>(entries));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching all entries: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var entry = await _repository.GetByIdAsync(id);
                if (entry == null)
                {
                    return NotFound(new { message = "Entry not found" });
                }

                return Ok(_mapper.Map<EntryDto>(entry));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while fetching the entry with ID {id}: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEntry(EntryDto entry)
        {
            try
            {
                var entity = _mapper.Map<Entry>(entry);
                await _repository.AddAsync(entity);
                return CreatedAtAction(nameof(Get), new { id = entity.Id }, _mapper.Map<EntryDto>(entity));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding a new entry: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(EntryDto entry)
        {
            try
            {
                var existingEntry = await _repository.GetByIdAsync(entry.Id);

                if (existingEntry == null)
                    return NotFound(new { message = "Entry not found" });

                _mapper.Map(entry, existingEntry);
                await _repository.UpdateAsync(existingEntry);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while updating entry with ID {entry.Id}: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingEntry = await _repository.GetByIdAsync(id);
                if (existingEntry == null)
                    return NotFound(new { message = "Entry not found" });

                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while deleting entry with ID {id}: {ex.Message}");
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }
    }
}