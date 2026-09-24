namespace NK_COLLECTION.metodos_ordenamiento;

internal sealed class NodoArbolBinario<T>
{
    public NodoArbolBinario(string clave, T valor)
    {
        Clave = clave;
        Valores.Add(valor);
    }

    public string Clave { get; }
    public List<T> Valores { get; } = new();
    public NodoArbolBinario<T>? Izquierdo { get; set; }
    public NodoArbolBinario<T>? Derecho { get; set; }
}
