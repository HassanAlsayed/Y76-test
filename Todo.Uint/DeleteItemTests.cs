using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Y76.Controller;
using Y76.Entities;
using Y76.Repository;
using Y76.TodoApi.Tests;

namespace Todo.Uint
{
    public class DeleteItemTests
    {
        private readonly Mock<ITodoItemRepository> _mockRepoCreate;
        private readonly TodoItemsController _controller;

        public DeleteItemTests()
        {
            _mockRepoCreate = MockTodoItemsService.DeleteItem();
            _controller = new TodoItemsController(_mockRepoCreate.Object);
        }

        [Fact]
        public async Task DeleteItemTest()
        {
            var id = Guid.Parse("1482229b-0332-45a0-b219-25cb8fd9c5be");
            var result = await _controller.DeleteAsync(id);

            var Result = result as OkObjectResult;
            Result!.Value.ShouldBe("Successfully deleted");
        }

    }
}
