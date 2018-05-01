using System;

namespace Itc.Am.DL.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        StoreEntities Init();
    }
}