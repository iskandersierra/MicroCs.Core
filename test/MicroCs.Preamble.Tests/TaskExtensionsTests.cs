namespace MicroCs.Preamble.Tests;

using MicroCs;

public class TaskExtensionsTests
{
    [Fact]
    public async Task WhenAll_WhenCalledWithTasksOfT_ThenAllTasksAreExecuted()
    {
        // Given
        async Task<int> Task1()
        {
            await Task.Yield();
            return 1;
        }

        async Task<int> Task2()
        {
            await Task.Yield();
            return 2;
        }

        async Task<int> Task3()
        {
            await Task.Yield();
            return 3;
        }

        // When
        var tasks = new List<Task<int>> { Task1(), Task2(), Task3() };

        var results = await tasks.WhenAll();

        // Then
        Assert.Equivalent(new[] { 1, 2, 3 }, results, strict: true);
    }

    [Fact]
    public async Task WhenAll_WhenCalledWithTasks_ThenAllTasksAreExecuted()
    {
        // Given
        var task1Executed = false;
        var task2Executed = false;
        var task3Executed = false;

        // Given
        async Task Task1()
        {
            await Task.Yield();
            task1Executed = true;
        }

        async Task Task2()
        {
            await Task.Yield();
            task2Executed = true;
        }

        async Task Task3()
        {
            await Task.Yield();
            task3Executed = true;
        }

        // When
        var tasks = new List<Task> { Task1(), Task2(), Task3() };
        
        await tasks.WhenAll();

        // Then
        Assert.True(task1Executed);
        Assert.True(task2Executed);
        Assert.True(task3Executed);
    }
}
