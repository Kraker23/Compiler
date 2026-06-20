using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;

namespace Compiler.Tests.Support;

internal sealed class FakeProyectoData : InMemoryData<Proyecto>, IProyectoData
{
    public override Proyecto? GetById(Guid id)
    {
        return Items.FirstOrDefault(x => x.id == id);
    }

    public override Proyecto Add(Proyecto dato)
    {
        Items.Add(dato);
        return dato;
    }

    public override Proyecto Update(Proyecto dato)
    {
        var index = Items.FindIndex(x => x.id == dato.id);
        if (index >= 0)
        {
            Items[index] = dato;
        }

        return dato;
    }
}