using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;

namespace Compiler.Tests.Support;

internal sealed class FakeArchivoExclusionData : InMemoryData<ArchivoExclusion>, IArchivoExclusionData
{
    public override ArchivoExclusion? GetById(Guid id)
    {
        return Items.FirstOrDefault(x => x.id == id);
    }

    public override ArchivoExclusion Add(ArchivoExclusion dato)
    {
        Items.Add(dato);
        return dato;
    }

    public override ArchivoExclusion Update(ArchivoExclusion dato)
    {
        var index = Items.FindIndex(x => x.id == dato.id);
        if (index >= 0)
        {
            Items[index] = dato;
        }

        return dato;
    }
}