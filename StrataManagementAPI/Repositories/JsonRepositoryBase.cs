using System.Text.Json;

namespace StrataManagementAPI.Repositories;

public class JsonRepositoryBase<T> where T : class
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _fileLock = new(1, 1);

    protected JsonRepositoryBase(string filePath)
    {
        _filePath = filePath;
        EnsureFileExists();
    }

    private void EnsureFileExists()
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    protected async Task<List<T>> GetAllAsync()
    {
        await _fileLock.WaitAsync();
        try
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
        finally
        {
            _fileLock.Release();
        }
    }

    protected async Task SaveAllAsync(List<T> items)
    {
        await _fileLock.WaitAsync();
        try
        {
            var json = JsonSerializer.Serialize(items);
            await File.WriteAllTextAsync(_filePath, json);
        }
        finally
        {
            _fileLock.Release();
        }
    }
}
