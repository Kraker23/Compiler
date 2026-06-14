# Esquema de mejoras

## Criterios de prioridad
- Impacto en operación diaria.
- Riesgo técnico reducido.
- Esfuerzo de implementación.

## Mejora 1: Servicio unificado de tareas (copiar/compilar)
- Objetivo: evitar duplicar lógica entre web, notifyicon y posibles futuros clientes.
- Impacto: alto.
- Esfuerzo: medio.
- Acciones:
  - Definir contrato de servicio de tareas en capa de aplicación.
  - Implementar ejecución en infraestructura (PowerShell/comandos).
  - Reutilizar el mismo servicio desde Web y Tray.
- Riesgo actual que resuelve: inconsistencia de comportamiento entre interfaces.

## Mejora 2: Frontend web de administración más claro
- Objetivo: ordenar flujos de Proyectos, Aplicaciones y Reglas.
- Impacto: alto.
- Esfuerzo: medio.
- Acciones:
  - Vistas separadas para consulta, edición y ejecución.
  - Confirmaciones y errores con componentes web, sin dependencias desktop.
  - Filtros y búsquedas para reducir tiempo operativo.
- Riesgo actual que resuelve: UX mezclada con lógica y confirmaciones de escritorio.

## Mejora 3: Configuración centralizada
- Objetivo: evitar rutas rígidas y parámetros dispersos.
- Impacto: alto.
- Esfuerzo: bajo.
- Acciones:
  - Configurar rutas de datos/publicación en settings.
  - Definir valores por entorno (desarrollo, producción).
  - Validar configuración al inicio.
- Riesgo actual que resuelve: fallos por rutas hardcodeadas o inconsistentes.

## Mejora 4: Mantenibilidad y calidad interna
- Objetivo: reducir deuda técnica para acelerar cambios.
- Impacto: medio.
- Esfuerzo: medio.
- Acciones:
  - Normalizar nombres de interfaces y métodos.
  - Eliminar dependencias externas no controladas.
  - Añadir pruebas unitarias a casos críticos de negocio.
- Riesgo actual que resuelve: regresiones silenciosas y acoplamiento innecesario.

## Mejora 5: NotifyIcon orientado a productividad
- Objetivo: mantener acciones rápidas sin duplicar UI completa.
- Impacto: medio.
- Esfuerzo: medio.
- Acciones:
  - Menú dinámico por proyectos favoritos.
  - Últimas ejecuciones y estado de tarea.
  - Acción de abrir vista web en contexto.
- Riesgo actual que resuelve: tray limitado o inconsistente con la web.

## Secuencia recomendada
1. Servicio unificado de tareas.
2. Configuración centralizada.
3. Frontend web base para CRUD y ejecución.
4. NotifyIcon conectado al mismo servicio.
5. Calidad interna y pruebas.
