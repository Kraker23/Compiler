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
- Editar aplicaciones existentes, incluyendo carpeta y reglas asociadas.
- Configurar en aplicaciones:
  - carpeta
  - ubicacion de compilacion
  - carpeta de publicacion
  - comando de compilacion
  - reglas de exclusion
  - reglas de admitidos
- Crear y borrar carpetas.
- Editar carpetas existentes.
- Crear, editar y borrar reglas de exclusion y admitidos.
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

### Arrancar Web y Tray
```powershell
e:\Code\Compiler\Start-Compiler.ps1
```

### Arrancar solo Web y Tray publicados
```powershell
e:\Code\Compiler\Start-Compiler-RunOnly.ps1
```

### Detener Web y Tray publicados
```powershell
e:\Code\Compiler\Stop-Compiler.ps1
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
- La persistencia de Web y Tray usa una carpeta compartida `artifacts/published/SharedData` (via `Storage:DataDirectory = ..\\SharedData`).
- El servicio compartido de ejecucion usa `xcopy` para copiar y `comandoCompilado` o `dotnet build` como fallback para compilar.
- El tray abre la web desde una URL configurable en `appsettings.json` y puede autoabrirla al iniciar si se activa esa opcion.
- La Web publicada se esta sirviendo en `http://localhost:5000` y el tray apunta a esa URL por defecto.
- La mayor parte de las advertencias de nullability heredadas ya se redujo con inicializacion por defecto en el dominio.
- Existe una carpeta de salida publicada en `artifacts/published/` para arrancar Web y Tray sin recompilar.
- El script de arranque inicializa `SharedData` automaticamente desde `Web/Data` y `Tray/Data` si aun no hay datos compartidos.

## Limitaciones actuales
- La UI sigue siendo funcional/pragmatica; aun puede pulirse, pero ya tiene filtros y busqueda basica en las pantallas CRUD.
- No hay arranque automatico completo coordinado entre Web y Tray; solo existe autoapertura opcional de la web desde el tray.
- Falta una validacion con datos reales de operacion.

## Siguientes pasos recomendados
1. Probar un flujo real con datos tuyos: crear carpeta, reglas, aplicacion, proyecto y ejecutar copiar/compilar.
2. Revisar nombres legacy y consistencia de contratos para reducir deuda tecnica restante.
3. Evaluar si merece la pena un arranque coordinado mas avanzado entre Web y Tray.
4. Mantener y ampliar las pruebas automatizadas para los casos criticos de negocio.

## Punto exacto para continuar manana
- Validar en entorno real el flujo completo con una carpeta, reglas, aplicacion y proyecto de prueba.
- Si aparece algun detalle de comportamiento, corregir primero la logica antes de tocar la UI.
- Luego decidir si vale la pena invertir en arranque coordinado mas fuerte o en mas pruebas.
