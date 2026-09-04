public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input) => int.TryParse(input, out int result) ? result : null;

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        result = 0;
        if (int.TryParse(input, out var r))
        {
            result = r;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        disposableObject.Dispose();
        throw new Exception();
    }
}
