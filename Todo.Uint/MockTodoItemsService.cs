using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Y76.Entities;
using Y76.Repository;

namespace Y76.TodoApi.Tests
{
    public class MockTodoItemsService
    {
        private static readonly List<TodoItem> todoItems;

        static MockTodoItemsService()
        {
            todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.Parse("1482229b-0332-45a0-b219-25cb8fd9c5be"), Description = "Todo 1", IsCompleted = false },
                new TodoItem { Id = Guid.NewGuid(), Description = "Todo 2", IsCompleted = true }
            };

        }

        public static Mock<ITodoItemRepository> GetAllItems()
        {
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(todoItems);
            return mockRepo;
        }

        public static Mock<ITodoItemRepository> CreateItem()
        {
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(x => x.AddAsync(It.IsAny<TodoItemDto>()))
            .Returns((TodoItemDto itemDto) =>
            {
                var item = new TodoItem
                {
                    Id = Guid.NewGuid(),
                };
                todoItems.Add(item);
                return Task.FromResult(item.Id);
            });
            return mockRepo;
        }

        public static Mock<ITodoItemRepository> UpdateItem()
        {
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(x => x.UpdateAsync(It.IsAny<Guid>(),It.IsAny<TodoItemDto>()))
            .Returns((Guid id,TodoItemDto itemDto) =>
            {
                var existingItem = todoItems.FirstOrDefault(x => x.Id == id);

                if (existingItem is not null)
                {
                    existingItem = new TodoItem
                    {
                        Description = itemDto.Description,
                        IsCompleted = itemDto.IsCompleted,
                    };
                }
                return Task.CompletedTask;
            });
            return mockRepo;
        }

        public static Mock<ITodoItemRepository> DeleteItem()
        {
            var mockRepo = new Mock<ITodoItemRepository>();
            mockRepo.Setup(x => x.DeleteAsync(It.IsAny<Guid>()))
            .Returns((Guid id) =>
            {
                var existingItem = todoItems.FirstOrDefault(x => x.Id == id);

                if (existingItem is not null)
                {
                   todoItems.Remove(existingItem);
                }
                return Task.CompletedTask;
            });
            return mockRepo;
        }
    }
}
