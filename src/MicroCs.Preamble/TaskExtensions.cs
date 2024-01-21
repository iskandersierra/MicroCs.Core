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

    #region [ WhenAny ]

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<Task<T>> WhenAny<T>(this IEnumerable<Task<T>> tasks) =>
        Task.WhenAny(tasks);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Task<Task> WhenAny(this IEnumerable<Task> tasks) =>
        Task.WhenAny(tasks);
    
    #endregion [ WhenAny ]
}
