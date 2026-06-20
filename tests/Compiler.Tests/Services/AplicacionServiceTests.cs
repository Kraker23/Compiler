using Compiler.Application.Services;
using Compiler.Domain.Entities;
using Compiler.Tests.Support;

namespace Compiler.Tests.Services;

public class AplicacionServiceTests
{
    [Fact]
    public void GetAplicaciones_OrdersByName()
    {
        var data = new FakeAplicacionData();
        data.Add(new Aplicacion { nombre = "Zulu" });
        data.Add(new Aplicacion { nombre = "Alpha" });

        var service = new AplicacionService(data);

        var aplicaciones = service.GetAplicaciones();

        Assert.Equal(["Alpha", "Zulu"], aplicaciones.Select(x => x.nombre).ToArray());
    }

    [Fact]
    public void ModificarAplicacion_UpdatesExistingApplication()
    {
        var data = new FakeAplicacionData();
        var app = new Aplicacion { nombre = "Inicial" };
        data.Add(app);
        var service = new AplicacionService(data);

        app.nombre = "Editado";

        service.ModificarAplicacion(app);

        Assert.Equal("Editado", data.GetById(app.id)?.nombre);
    }

    [Fact]
    public void AnyAplicacionConCarpeta_ReturnsTrueWhenAppUsesFolder()
    {
        var carpetaId = Guid.NewGuid();
        var data = new FakeAplicacionData();
        data.Add(new Aplicacion { fk_IdCarpeta = carpetaId });
        var service = new AplicacionService(data);

        Assert.True(service.AnyAplicacionConCarpeta(carpetaId));
    }
}