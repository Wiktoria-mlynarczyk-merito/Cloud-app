using Xunit;

public class UnitTest1
{
    [Fact]
    public void NewTask_ShouldNotBeCompleted()
    {
        // tworzenie obiektu
        var task = new TaskItem();

        // nadanie nazwy
        task.Name = "Przetestować bezpiecznik";

        // sprawdzenie
        Assert.False(task.IsCompleted);
    }
}