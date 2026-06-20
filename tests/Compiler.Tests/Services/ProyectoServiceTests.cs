using Compiler.Application.Services;
using Compiler.Domain.Entities;
using Compiler.Tests.Support;

namespace Compiler.Tests.Services;

public class ProyectoServiceTests
{
    [Fact]
    public void GetProyectos_OrdersByName()
    {
        var data = new FakeProyectoData();
        data.Add(new Proyecto { nombre = "Zulu" });
        data.Add(new Proyecto { nombre = "Alpha" });

        var service = new ProyectoService(data);

        var proyectos = service.GetProyectos();

        Assert.Equal(["Alpha", "Zulu"], proyectos.Select(x => x.nombre).ToArray());
    }

    [Fact]
    public void ModificarProyecto_UpdatesExistingProject()
    {
        var data = new FakeProyectoData();
        var project = new Proyecto { nombre = "Inicial" };
        data.Add(project);
        var service = new ProyectoService(data);

        project.nombre = "Editado";

        service.ModificarProyecto(project);

        Assert.Equal("Editado", data.GetById(project.id)?.nombre);
    }

    [Fact]
    public void AnyProyectoConAplicacion_ReturnsTrueWhenProjectContainsApp()
    {
        var appId = Guid.NewGuid();
        var data = new FakeProyectoData();
        data.Add(new Proyecto { aplicaciones = [appId] });
        var service = new ProyectoService(data);

        Assert.True(service.AnyProyectoConAplicacion(appId));
    }
}