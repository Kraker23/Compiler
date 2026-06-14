# Plan del proyecto

## Objetivo
Construir una nueva base de aplicación web usando la idea del proyecto actual, reutilizando lo que siga siendo útil de la carpeta `Aplicacion Vieja/`.

## Decisiones iniciales
- Frontend elegido: Blazor Web App / Blazor Server.
- Arquitectura base: monolito ordenado, con separación clara por capas.
- Reutilización prioritaria: estructura útil de proyectos/carpetas, NotifyIcon como acceso rápido, y reglas de negocio que aporten valor.

## Forma de trabajo
- Este archivo se actualizará cada vez que se complete un paso relevante.
- Si aparece un problema, se registrará aquí junto con la solución aplicada o la alternativa elegida.
- Todo lo que se reutilice desde `Aplicacion Vieja/` se moverá o adaptará solo cuando haga falta.

## Checklist de pasos
- [ ] Revisar el proyecto viejo y localizar piezas reutilizables.
- [ ] Definir la estructura nueva de solución y proyectos.
- [ ] Identificar qué lógica de negocio merece conservarse.
- [ ] Diseñar la base del frontend en Blazor.
- [ ] Definir cómo convivirá la UI web con el NotifyIcon.
- [ ] Separar lo que se migrará, lo que se reescribirá y lo que se descartará.
- [ ] Crear un primer esquema de mejoras funcionales y técnicas.
- [ ] Documentar decisiones y problemas encontrados a medida que avance el trabajo.

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
- Ninguno por ahora.

## Notas
- La carpeta `Aplicacion Vieja/` queda como base de referencia y reutilización progresiva.
- La prioridad es avanzar sin reescribir todo de golpe.
