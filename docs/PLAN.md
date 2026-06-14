# Plan del proyecto

## Objetivo
Construir una nueva base de aplicación web usando la idea del proyecto actual, reutilizando lo que siga siendo útil de la carpeta `Aplicacion Vieja/`.

## Decisiones iniciales
- Frontend elegido: Blazor Web App / Blazor Server.
- Arquitectura base: monolito ordenado, con separación clara por capas.
- Reutilización prioritaria: estructura útil de proyectos/carpetas, NotifyIcon como acceso rápido, y reglas de negocio que aporten valor.

## Mapa inicial del legado
- `Compiler.AppBlazor` ya contiene una base web funcional sobre `BlazorDesktop` con registro de BL y EF.
- `Compiler.AppNotifyIcon` funciona como entrada de bandeja independiente y hoy reutiliza la misma inyección de dependencias.
- `Compiler.UI` concentra un NotifyIcon más completo, con menú contextual y acciones sobre proyectos; parece la mejor referencia para conservar comportamiento de bandeja.
- `Compiler.Starter` es otro punto de arranque WinForms que también tira de la misma composición de dependencias.
- `Compiler.BL`, `Compiler.EF` y `Compiler.Shared` son las capas más valiosas para reutilizar y refactorizar.

## Dominio detectado
- Entidades principales: `Proyecto`, `Aplicacion`, `Carpeta`, `ArchivoExclusion` y `ArchivoAdmitido`.
- El negocio gira alrededor de agrupar aplicaciones por proyecto, gestionar rutas de compilado/publicación y aplicar reglas de copiado.
- La persistencia actual es ligera y basada en JSON, no en una base de datos relacional tradicional.
- Esto hace que la reutilización de la capa de negocio sea bastante viable, siempre que se ordenen bien los contratos y dependencias.

## Estructura propuesta
### Objetivo de la solución nueva
- Separar la experiencia web de las acciones rápidas de bandeja, pero compartiendo la misma lógica de negocio.
- Evitar que la UI arrastre detalles de persistencia o de ejecución de scripts.
- Mantener una base simple al principio y crecer por capas.

### Propuesta de proyectos
- `Compiler.Web`: interfaz principal en Blazor para administración y uso diario.
- `Compiler.Tray`: app de NotifyIcon para accesos rápidos y acciones urgentes.
- `Compiler.Application`: casos de uso, orquestación y reglas de operación.
- `Compiler.Domain`: entidades, contratos y modelos base del negocio.
- `Compiler.Infrastructure`: JSON, filesystem, PowerShell y otras integraciones técnicas.
- `Compiler.Shared`: utilidades comunes si realmente siguen aportando valor compartido.

### Criterio de convivencia
- La web será el centro operativo para consultar, editar y administrar.
- El NotifyIcon quedará como atajo permanente para ejecutar acciones frecuentes.
- Ambas entradas consumirán la misma capa de aplicación para no duplicar reglas.
- Si una funcionalidad solo sirve a la bandeja, se mantendrá aislada en `Compiler.Tray`.

## Matriz de migración
### Reutilizar casi directo
- `Compiler.Shared`: entidades y contratos del dominio (con limpieza de nombres y nullability).
- `Compiler.BL`: reglas de negocio y validaciones existentes.
- `Compiler.EF` (parcial): estrategia de persistencia JSON y repositorios como base inicial.

### Reescribir o adaptar
- `Compiler.AppBlazor`: conservar rutas, navegación y casos de uso, pero adaptar para web real (sin dependencias de escritorio).
- `Compiler.UI`: extraer lógica de copiar/compilar y menús contextuales a capa de aplicación.
- `Compiler.AppNotifyIcon`: rehacer sobre nueva capa de aplicación para evitar lógica duplicada.

### Descartar o congelar
- `Compiler.Starter`: se puede congelar como legado una vez que la nueva web y tray queden estables.
- Dependencias externas no controladas por solución (dlls utilitarias fuera del repo) deben evitarse en la nueva base.

## Fases de ejecución
1. Crear solución nueva con estructura `Web + Tray + Application + Domain + Infrastructure`.
2. Migrar entidades y contratos desde `Compiler.Shared` a `Compiler.Domain`.
3. Migrar reglas BL a `Compiler.Application` y desacoplar de UI.
4. Migrar persistencia JSON a `Compiler.Infrastructure` con rutas de datos configurables.
5. Levantar `Compiler.Web` con CRUD básico de Proyectos, Aplicaciones y Reglas.
6. Levantar `Compiler.Tray` con menú de proyectos y acciones rápidas de copiado.
7. Unificar la ejecución de copiar/compilar en servicios compartidos y eliminar duplicidades. (copiar: completado, compilar: completado)

## Estado de ejecución actual
- Se creó la solución nueva `Compiler.Next.slnx` en la raíz del workspace.
- Se crearon proyectos base en `src/`: `Compiler.Web`, `Compiler.Tray`, `Compiler.Application`, `Compiler.Domain`, `Compiler.Infrastructure`.
- Se configuraron referencias entre proyectos para respetar la arquitectura por capas.
- Se migraron entidades base del dominio desde el legado hacia `src/Compiler.Domain/Entities`.
- Se migraron apoyos de dominio necesarios (`Enums` y `Extenders`) para mantener compatibilidad inicial.
- Se migraron contratos de negocio/datos y servicios base a `Compiler.Application`.
- Se migró la persistencia JSON inicial a `Compiler.Infrastructure` y quedó registrada en DI.
- `Compiler.Web` ya consume servicios reales y expone un primer CRUD funcional para Proyectos (`/proyectos`).
- `Compiler.Web` ya expone un CRUD inicial de Aplicaciones (`/aplicaciones`).
- `Compiler.Web` ya expone un CRUD inicial de Carpetas (`/carpetas`).
- `Compiler.Web` ya expone CRUD inicial de reglas de exclusión (`/reglas-exclusion`) y admitidos (`/reglas-admitidos`).
- `Compiler.Web` incorpora página de ejecución (`/ejecucion`) para lanzar copiado, compilación y compilar+copiar por proyecto.
- `Compiler.Web` ya permite asociar aplicaciones a proyectos, y configurar aplicaciones con carpeta y reglas base.
- `Compiler.Tray` quedó conectado por DI a la misma capa de servicios, con acciones reales de copiar, compilar y compilar+copiar por proyecto.
- Se implementó `ITaskRunnerService` con ejecución unificada de copiado y compilación en Application + Infrastructure.
- La solución compila correctamente con integración completa entre capas.
- El siguiente paso es mejorar edición de entidades existentes y cerrar pruebas funcionales completas con datos reales.

## Siguientes pasos
1. Añadir edición completa de aplicaciones existentes.
2. Añadir edición completa de carpetas existentes.
3. Añadir edición completa de reglas de exclusión y admitidos.
4. Ejecutar una prueba funcional real con datos completos desde la web.
5. Mejorar configuración/persistencia para no depender solo de `AppContext.BaseDirectory`.
6. Reducir deuda técnica: nullability, nombres legacy y consistencia de contratos.
7. Revisar arranque coordinado o detección automática entre Web y Tray.

## Checklist de implementación inicial
- [x] Crear la nueva solución y proyectos base.
- [x] Configurar referencias entre capas.
- [x] Migrar entidades principales al nuevo `Compiler.Domain`.
- [x] Migrar contratos de negocio y datos a `Compiler.Application`.
- [x] Migrar persistencia JSON inicial a `Compiler.Infrastructure`.
- [x] Conectar `Compiler.Web` a servicios de aplicación para primer CRUD.
- [x] Conectar `Compiler.Tray` a servicios compartidos para acciones rápidas.
- [x] Unificar copiar, compilar y compilar+copiar en un servicio compartido.

## Forma de trabajo
- Este archivo se actualizará cada vez que se complete un paso relevante.
- Si aparece un problema, se registrará aquí junto con la solución aplicada o la alternativa elegida.
- Todo lo que se reutilice desde `Aplicacion Vieja/` se moverá o adaptará solo cuando haga falta.

## Checklist de pasos
- [x] Revisar el proyecto viejo y localizar piezas reutilizables.
- [x] Definir la estructura nueva de solución y proyectos.
- [x] Identificar qué lógica de negocio merece conservarse.
- [x] Diseñar la base del frontend en Blazor.
- [x] Definir cómo convivirá la UI web con el NotifyIcon.
- [x] Separar lo que se migrará, lo que se reescribirá y lo que se descartará.
- [x] Crear un primer esquema de mejoras funcionales y técnicas.
- [x] Documentar decisiones y problemas encontrados a medida que avance el trabajo.

## Posibles mejoras
### Técnicas
- Mejorar la mantenibilidad con capas más claras.
- Reducir acoplamiento entre UI, negocio y persistencia.
- Introducir validaciones y contratos más consistentes.
- Preparar el proyecto para crecer sin depender del código legado completo.

### UX / funcionales
- Acciones rápidas desde el NotifyIcon.
- Navegación web más clara para tareas frecuentes.
- Paneles y vistas más enfocadas a operación diaria.
- Mejor configuración centralizada.

### Evolución futura
- Evaluar automatización de tareas repetitivas.
- Revisar opciones de instalación y despliegue.
- Añadir pruebas para las partes más críticas.

## Registro de problemas
- Problema: parte de `Compiler.AppBlazor` usa `System.Windows.MessageBox`, lo que acopla la UI a escritorio y rompe el enfoque web puro.
	Solución propuesta: reemplazar confirmaciones y alertas por componentes web (Radzen Dialog/Notification), moviendo confirmaciones de negocio a servicios de aplicación cuando aplique.
- Problema: la lógica de copiado/PowerShell está repetida entre `Compiler.UI` y `Compiler.AppNotifyIcon`.
	Solución propuesta: crear un servicio único de ejecución de tareas en `Compiler.Application` + `Compiler.Infrastructure`, y consumirlo desde web/tray.
- Problema: al crear la solución con .NET 10 se generó `slnx` en vez de `sln`, y el alta inicial de proyectos falló por ruta/archivo esperado.
	Solución aplicada: registrar los proyectos directamente en `Compiler.Next.slnx` usando rutas absolutas.
- Problema: en `Compiler.Tray` hubo colisión de nombre entre `Compiler.Application` (namespace) y `Application` de WinForms.
	Solución aplicada: usar `System.Windows.Forms.Application` totalmente calificado y un arranque WinForms clásico.
- Problema: al migrar entidades aparecieron advertencias de nullability heredadas del código legacy.
	Solución aplicada: se mantuvo compatibilidad para avanzar rápido y se planifica normalizar nullability en una pasada de calidad dedicada.
- Problema: la implementación inicial hereda nombres legacy mixtos (es/en) y convenciones no uniformes.
	Solución aplicada: priorizar funcionalidad en esta fase; normalizar nombres y estilo en una etapa de refactor controlado.
- Problema: el acceso "Abrir Web" desde tray requiere que la app web esté levantada en local.
	Solución aplicada: se dejó enlace directo a la ruta base y se planifica detección/arranque automático del host web en una fase posterior.

## Registro de hallazgos
- El punto más prometedor para arrancar no es `Compiler.Starter`, sino la base de `Compiler.AppBlazor`.
- El NotifyIcon útil no está aislado en una sola app; la referencia más rica está en `Compiler.UI`.
- La solución actual mezcla varias vías de entrada, así que el siguiente paso debe ordenar el arranque antes de ampliar funcionalidades.
- El dominio está razonablemente acotado y gira en torno a proyectos, aplicaciones y reglas de copiado, lo que facilita una migración incremental.
- La nueva solución debería separar claramente web, tray, aplicación e infraestructura para evitar repetir la confusión del legado.
- La migración puede ser incremental sin perder funcionalidad: primero se comparte dominio/servicios y luego se migra cada interfaz.

## Notas
- La carpeta `Aplicacion Vieja/` queda como base de referencia y reutilización progresiva.
- La prioridad es avanzar sin reescribir todo de golpe.
- El backlog inicial de mejoras quedó documentado en `docs/MEJORAS.md`.
- El diseño base del frontend web quedó documentado en `docs/FRONTEND-BLAZOR.md`.
- El estado listo para retomar mañana quedó documentado en `docs/ESTADO-ACTUAL.md`.
- La implementación ya empezó en una estructura nueva bajo `src/`, manteniendo intacto el legado en `Aplicacion Vieja/`.
