# Estado actual y continuacion

## Resumen rapido
- La nueva solucion activa es `Compiler.Next.slnx`.
- El legado permanece intacto en `Aplicacion Vieja/`.
- La nueva implementacion vive bajo `src/`.
- La solucion compila correctamente con `dotnet build`.

## Estructura actual
- `src/Compiler.Domain`: entidades y helpers de dominio migrados.
- `src/Compiler.Application`: contratos, servicios de negocio y `ITaskRunnerService`.
- `src/Compiler.Infrastructure`: persistencia JSON, repositorios y ejecucion de comandos.
- `src/Compiler.Web`: frontend Blazor principal.
- `src/Compiler.Tray`: app NotifyIcon conectada a los mismos servicios.

## Funcionalidad ya disponible
### Web
Rutas disponibles:
- `/proyectos`
- `/aplicaciones`
- `/carpetas`
- `/reglas-exclusion`
- `/reglas-admitidos`
- `/ejecucion`

Capacidades actuales:
- Crear y borrar proyectos.
- Asociar aplicaciones a proyectos.
- Crear y borrar aplicaciones.
- Configurar en aplicaciones:
  - carpeta
  - ubicacion de compilacion
  - carpeta de publicacion
  - comando de compilacion
  - reglas de exclusion
  - reglas de admitidos
- Crear y borrar carpetas.
- Crear y borrar reglas de exclusion y admitidos.
- Ejecutar por proyecto:
  - copiar
  - compilar
  - compilar y copiar

### Tray
- Carga proyectos dinamicamente.
- Acciones disponibles por proyecto:
  - copiar
  - compilar
  - compilar y copiar
- Requiere que los datos ya existan en la persistencia JSON usada por la nueva app.

## Comandos para retomar
### Compilar
```powershell
dotnet build "e:\Code\Compiler\Compiler.Next.slnx"
```

### Ejecutar Web
```powershell
dotnet run --project "e:\Code\Compiler\src\Compiler.Web\Compiler.Web.csproj"
```

### Ejecutar Tray
```powershell
dotnet run --project "e:\Code\Compiler\src\Compiler.Tray\Compiler.Tray.csproj"
```

## Estado tecnico importante
- La persistencia sigue siendo JSON en `AppContext.BaseDirectory/Data/`.
- El servicio compartido de ejecucion usa `xcopy` para copiar y `comandoCompilado` o `dotnet build` como fallback para compilar.
- El tray abre la web apuntando a una URL local fija; eso aun no esta automatizado.
- Existen advertencias de nullability heredadas del modelo legacy, pero no bloquean compilacion.

## Limitaciones actuales
- No hay edicion completa de entidades existentes; muchas pantallas permiten crear y borrar, pero no editar en profundidad.
- La UI sigue siendo funcional/pragmatica; falta una pasada de UX.
- No hay arranque automatico coordinado entre Web y Tray.
- No hay pruebas automatizadas todavia.

## Siguientes pasos recomendados
1. Añadir edicion completa de aplicaciones existentes.
2. Añadir edicion completa de carpetas y reglas.
3. Probar un flujo real con datos tuyos: crear carpeta, reglas, aplicacion, proyecto y ejecutar copiar/compilar.
4. Mejorar la gestion de persistencia/configuracion para no depender de rutas implicitas de `AppContext.BaseDirectory`.
5. Revisar nullability y nombres legacy para reducir deuda tecnica.
6. Preparar arranque conjunto o deteccion de Web desde Tray.

## Punto exacto para continuar manana
- Empezar por `src/Compiler.Web/Components/Pages/Aplicaciones.razor` para convertir el CRUD inicial en una pantalla de edicion real.
- Despues seguir con `src/Compiler.Web/Components/Pages/Carpetas.razor`, `ReglasExclusion.razor` y `ReglasAdmitidos.razor`.
- Si se quiere validar funcionalmente antes de refinar UI, ejecutar la web y cargar un caso real completo desde cero.
