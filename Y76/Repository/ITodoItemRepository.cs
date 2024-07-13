using Y76.Entities;

namespace Y76.Repository
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetAllAsync();
        Task<Guid> AddAsync(TodoItemDto todoItem);
        Task UpdateAsync(Guid id,TodoItemDto todoItem);
        Task DeleteAsync(Guid id);
    }
}
    