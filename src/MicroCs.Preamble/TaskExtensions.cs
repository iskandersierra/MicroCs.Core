using System.Runtime.CompilerServices;

namespace MicroCs;

public static class TaskExtensions
{
    #region [ WhenAll ]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<T[]> WhenAll<T>(this IEnumerable<Task<T>> tasks) =>
        Task.WhenAll(tasks);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task WhenAll(this IEnumerable<Task> tasks) =>
        Task.WhenAll(tasks);
    
    #endregion [ WhenAll ]
}
