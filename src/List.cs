namespace MyProject;

class List<T> {
    private Node<T>? head;
    private int lenght;

    public List() {
        this.head = null;
        this.lenght = 0;
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
                this.lenght++;
                return;
            }
            current = current.next;
        }
        this.resetIndexes();
    }

    public void remove(int index) {
        Node<T>? current = this.head;
        while(current != null) {
            if(current.index == index) {
                current.prev = current.next;
            }
        }
        this.resetIndexes();
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

    private void resetIndexes() {
        int i = 0;
        Node<T>? current = this.head;
		while(current != null) {
			current.index = i;
			current = current.next;
            i++;
		}
    }
}