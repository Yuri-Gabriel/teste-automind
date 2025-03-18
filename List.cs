namespace MyProject;

class List<T> {
    private Node<T>? head;

    public List() {
        this.head = null;
    }
    
    public void add(T value) {
        if(this.head == null) {
            this.head = new Node<T>(value);
            return;
        }

        Node<T>? current = this.head;
        while(current != null) {
            if(current.next == null) {
                Node<T>? newNode = new Node<T>(value);
                newNode.prev = current;
                current.next = newNode;
                return;
            }
            current = current.next;
        }
    }

    public void remove(T value) {
        Node<T>? current = this.head;
        while(current != null) {
            if(true) {
                current.prev = current.next;
            }
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