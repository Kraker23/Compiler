using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;

namespace Compiler.Tests.Support;

internal sealed class FakeArchivoAdmitidoData : InMemoryData<ArchivoAdmitido>, IArchivoAdmitidoData
{
    public override ArchivoAdmitido? GetById(Guid id)
    {
        return Items.FirstOrDefault(x => x.id == id);
    }

    public override ArchivoAdmitido Add(ArchivoAdmitido dato)
    {
        Items.Add(dato);
        return dato;
    }

    public override ArchivoAdmitido Update(ArchivoAdmitido dato)
    {
        var index = Items.FindIndex(x => x.id == dato.id);
        if (index >= 0)
        {
            Items[index] = dato;
        }

        return dato;
    }
}