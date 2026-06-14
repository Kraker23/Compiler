# Diseno base del frontend (Blazor)

## Objetivo
Definir una base web clara para administrar Proyectos, Aplicaciones, Carpetas y Reglas (admitidos/excluidos), y ejecutar acciones operativas sin depender de APIs de escritorio.

## Stack propuesto
- Blazor Web App (modo server para acelerar arranque y reutilizacion de C#).
- Componentes UI: Radzen para tablas, arboles, dialogs y notificaciones.
- Estado simple por pagina (sin estado global complejo en la primera iteracion).

## Principios de UX
- Flujo principal en tres niveles: listar, editar, ejecutar.
- Confirmaciones siempre por dialog web, nunca por `System.Windows`.
- Feedback visible en cada accion: exito, error, progreso.
- Navegacion lateral fija por modulo.

## Mapa de paginas (v1)
- `/dashboard`: resumen operativo (ultimas tareas, accesos rapidos).
- `/proyectos`: CRUD de proyectos y asociacion de aplicaciones.
- `/aplicaciones`: CRUD de aplicaciones, carpetas y rutas.
- `/reglas/exclusion`: CRUD de reglas de exclusion.
- `/reglas/admitidos`: CRUD de reglas admitidas.
- `/ejecucion`: lanzar copiar/compilar y ver estado de tarea.
- `/configuracion`: rutas base, parametros operativos y ajustes.

## Componentes reutilizables
- `EntityListPanel`: listado y filtros.
- `EntityEditorPanel`: formulario de edicion con validaciones.
- `ConfirmActionDialog`: confirmaciones estandar.
- `ExecutionConsole`: salida resumida de tareas (log).
- `ProjectQuickActions`: acciones frecuentes por proyecto.

## Contratos UI -> Application
- `IProjectService`: operaciones de proyecto.
- `IApplicationService`: operaciones de aplicacion/carpeta.
- `IRuleService`: operaciones de admitidos y exclusiones.
- `ITaskRunnerService`: copiar/compilar y estado de ejecucion.

## Estrategia de migracion de pantallas
- Reutilizar idea de rutas de la app vieja (`Proyectos`, `Aplicaciones`, `ArchivosExclusion`, `ArchivosAdmitidos`).
- Reescribir eventos de UI para usar dialogs web y servicios de aplicacion.
- Mover logica de ejecucion fuera de la pagina (`UsarAplicacion`) hacia `ITaskRunnerService`.

## Primer entregable frontend
- Dashboard basico.
- CRUD funcional de Proyectos y Aplicaciones.
- CRUD funcional de Reglas.
- Vista de ejecucion con boton de copiar y resultados.

## Riesgos conocidos
- Si la ejecucion de tareas queda en la UI, se repetira deuda tecnica.
- Si no se centralizan notificaciones/dialogos, la UX sera inconsistente.

## Criterio de listo (v1)
- Todas las operaciones CRUD del dominio principal disponibles en web.
- Confirmaciones y mensajes totalmente web.
- Al menos una accion operativa (copiar) ejecutable desde `/ejecucion`.
