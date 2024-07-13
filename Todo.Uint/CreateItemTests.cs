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
    public class CreateItemTests
    {
        private readonly Mock<ITodoItemRepository> _mockRepoCreate;
        private readonly TodoItemsController _controller;

        public CreateItemTests()
        {
            _mockRepoCreate = MockTodoItemsService.CreateItem();
            _controller = new TodoItemsController(_mockRepoCreate.Object);
        }

        [Fact]
        public async Task CreateItemTest()
        {
            var item = new TodoItemDto
            {
                Description = "description test",
                IsCompleted = false,
            };
            var result = await _controller.CreateTodoItem(item);

            var createdResult = result.Result as CreatedResult;

            createdResult.ShouldNotBeNull();
            createdResult.StatusCode.ShouldBe(201);

            var createdItemId = (Guid)createdResult.Value!;
            createdItemId.ShouldNotBe(Guid.Empty);

        }

    }
}
