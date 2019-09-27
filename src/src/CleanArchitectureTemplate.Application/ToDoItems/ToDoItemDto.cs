namespace CleanArchitectureTemplate.Application.ToDoItems
{
    public class ToDoItemDto
    {
        public ToDoItemDto(int id) => Id = id;

        public int Id { get; }
    }
}
