using Compiler.Application.Services;
using Compiler.Domain.Entities;
using Compiler.Tests.Support;

namespace Compiler.Tests.Services;

public class CatalogServiceTests
{
    [Fact]
    public void CarpetaService_ModificarCarpeta_UpdatesExistingFolder()
    {
        var data = new FakeCarpetaData();
        var folder = new Carpeta { nombre = "Inicial" };
        data.Add(folder);
        var service = new CarpetaService(data);

        folder.nombre = "Editada";

        service.ModificarCarpeta(folder);

        Assert.Equal("Editada", data.GetById(folder.id)?.nombre);
    }

    [Fact]
    public void ArchivoExclusionService_ModificarArchivoExclusion_UpdatesExistingRule()
    {
        var data = new FakeArchivoExclusionData();
        var rule = new ArchivoExclusion { texto = "bin" };
        data.Add(rule);
        var service = new ArchivoExclusionService(data);

        rule.texto = "obj";

        service.ModificarArchivoExclusion(rule);

        Assert.Equal("obj", data.GetById(rule.id)?.texto);
    }

    [Fact]
    public void ArchivoAdmitidoService_ModificarArchivoAdmitido_UpdatesExistingRule()
    {
        var data = new FakeArchivoAdmitidoData();
        var rule = new ArchivoAdmitido { texto = "txt" };
        data.Add(rule);
        var service = new ArchivoAdmitidoService(data);

        rule.texto = "md";

        service.ModificarArchivoAdmitido(rule);

        Assert.Equal("md", data.GetById(rule.id)?.texto);
    }
}