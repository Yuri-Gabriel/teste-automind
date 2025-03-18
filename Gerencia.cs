namespace MyProject;

class Gerencia<T> {
    private Node<T>? head;

    public Gerencia() {
        this.head = null;
    }
    
    public void cadastrar(T value) {
        if(this.head == null) {
            this.head = new Node<T>(value);
            return;
        }

        Node<T>? current = this.head;
        while(current != null) {
            if(current.next == null) {
                current.next = new Node<T>(value);
                return;
            }
            current = current.next;
        }
    }

    public void show() {
        Node<T>? current = this.head;
		while(current != null) {
			Console.Write(current.next != null ? current.value + " -> " : current.value + "\n");
			current = current.next;
		}
    }

    public void forEach(Action<T> action) {
        Node<T>? current = this.head;
		while(current != null) {
			action(current.value);
			current = current.next;
		}
    }
}