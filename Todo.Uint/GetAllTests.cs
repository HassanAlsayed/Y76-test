using Moq;
using Y76.Controller;
using Y76.Entities;
using Y76.Repository;
using Shouldly;
using Microsoft.AspNetCore.Mvc;

namespace Y76.TodoApi.Tests
{
    public class GetAllTests
    {
        private readonly Mock<ITodoItemRepository> _mockRepoGetAll;
        private readonly TodoItemsController _controller;

        public GetAllTests()
        {
            _mockRepoGetAll = MockTodoItemsService.GetAllItems();
            _controller = new TodoItemsController(_mockRepoGetAll.Object);
        }

        [Fact]
        public async Task GetAllItemsTest()
        {
            var result = await _controller.GetTodoItems();
            var okResult = result as OkObjectResult;

            var items = okResult!.Value as List<TodoItem>;
            items.ShouldBeOfType<List<TodoItem>>();
            items.Count.ShouldBe(2);
        }

       
    }
}
