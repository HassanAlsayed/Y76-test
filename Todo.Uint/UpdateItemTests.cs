using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Y76.Controller;
using Y76.Entities;
using Y76.Repository;
using Y76.TodoApi.Tests;

namespace Todo.Uint
{
    public class UpdateItemTests
    {
        private readonly Mock<ITodoItemRepository> _mockRepoUpdate;
        private readonly TodoItemsController _controller;

        public UpdateItemTests()
        {
            _mockRepoUpdate = MockTodoItemsService.UpdateItem();
            _controller = new TodoItemsController(_mockRepoUpdate.Object);
        }

            [Fact]
            public async Task UpdateItemTest()
            {
                var Item = new TodoItemDto
                {
                    Description = "description test",
                    IsCompleted = false,
                };
                var id = Guid.Parse("1482229b-0332-45a0-b219-25cb8fd9c5be");
                var result = await _controller.UpdateAsync(id,Item);

                var Result = result as OkObjectResult;
                Result!.Value.ShouldBe("Successfully updated");

        }
    }
}
