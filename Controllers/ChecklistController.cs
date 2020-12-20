using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreVueChecklist.Data;
using AspnetCoreVueChecklist.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreVueChecklist.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChecklistController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ChecklistController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChecklistItem item)
        {
            await _dbContext.ChecklistItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return Ok(item.Id);
        }

        [HttpGet]
        public async Task<IEnumerable<ChecklistItem>> Get()
        {
            var items = await _dbContext.ChecklistItems.ToListAsync();

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ChecklistItem> Get(int id)
        {
            var item = await _dbContext.ChecklistItems.FirstOrDefaultAsync(_ => _.Id == id);

            return item;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, ChecklistItem item)
        {
            var existingItem = await _dbContext.ChecklistItems.FirstOrDefaultAsync(_ => _.Id == id);
            existingItem.Text = item.Text;
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.ChecklistItems.FirstOrDefaultAsync(_ => _.Id == id);
            _dbContext.ChecklistItems.Remove(item);
            var result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
