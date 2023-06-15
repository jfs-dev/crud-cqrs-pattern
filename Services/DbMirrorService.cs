using crud_cqrs_pattern.Data;

namespace crud_cqrs_pattern.Services;

public static class DbMirrorService
{
    public static void Sync(AppDbContextWrite contextWrite, AppDbContextRead contextRead)
    {
        contextRead.AddRange(contextWrite.Clientes);
        contextRead.SaveChanges();
    }
}
