# Nk_Colletion

## Búsqueda y ordenamiento de Productos

La carpeta `metodos_ordenamiento` contiene la implementación del árbol binario de búsqueda usado por el módulo Productos. El inventario se carga desde PostgreSQL y se organiza en memoria en un árbol balanceado por nombre de producto. La búsqueda visual, los filtros y el orden A-Z / Z-A trabajan sobre esta estructura, evitando consultar la base de datos por cada tecla escrita.

- `NodoArbolBinario.cs`: nodo con clave y colección de valores repetidos.
- `ArbolBinarioBusqueda.cs`: construcción balanceada, búsqueda, filtrado y recorrido ascendente/descendente.
