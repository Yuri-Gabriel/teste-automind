namespace MyProject;

/// <summary>
///     Nó da lista encadeada
/// </summary>
/// <typeparam name="T">Tipo que será usado para o valor inserido no nó</typeparam>
class Node<T> {
    public T? value;
    public int index;
    public Node<T>? next;
    public Node<T>? prev;

    public Node(T value) {
        this.value = value;
        this.next = null;
        this.prev = null;
    }
}