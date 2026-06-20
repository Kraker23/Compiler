using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;

namespace Compiler.Tests.Support;

internal sealed class FakeAplicacionData : InMemoryData<Aplicacion>, IAplicacionData
{
    public override Aplicacion? GetById(Guid id)
    {
        return Items.FirstOrDefault(x => x.id == id);
    }

    public override Aplicacion Add(Aplicacion dato)
    {
        Items.Add(dato);
        return dato;
    }

    public override Aplicacion Update(Aplicacion dato)
    {
        var index = Items.FindIndex(x => x.id == dato.id);
        if (index >= 0)
        {
            Items[index] = dato;
        }

        return dato;
    }
}