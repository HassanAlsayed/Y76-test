using Microsoft.EntityFrameworkCore;
using Y76.Entities;
using Y76.Repository;

namespace Y76.Data
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<Guid> AddAsync(TodoItemDto todoItemDto)
        {
            var todoItem = new TodoItem
            {
                Description = todoItemDto.Description,
                IsCompleted = todoItemDto.IsCompleted
            };

            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync();
            return todoItem.Id;
        }

        public async Task UpdateAsync(Guid id,TodoItemDto todoItemDto)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            todoItem!.Description = todoItemDto.Description;
            todoItem.IsCompleted = todoItemDto.IsCompleted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }
    }
}
