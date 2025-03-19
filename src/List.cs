namespace MyProject;

class List<T> {
    private Node<T>? head;
    public int lenght;

    public List() {
        this.head = null;
        this.lenght = 0;
    }
    
    public void add(T value) {
        if(this.head == null) {
            this.head = new Node<T>(value);
        } else {
            Node<T>? current = this.head;
            while(current != null) {
                if(current.next == null) {
                    Node<T>? newNode = new Node<T>(value);
                    newNode.prev = current;
                    current.next = newNode;
                    this.lenght += 1;
                    break;
                }
                current = current.next;
            }
        }
        this.updateNodeIndex();
    }

    public T? get(int index) {
        try {
            if(index < 0 || index > this.lenght) throw new Exception($"ERRO => List.get(): index out of bound, [0, {this.lenght}] -> {index}");
            Node<T>? current = this.head;
            while(current != null) {
                if(current.index.Equals(index)) {
                    return current.value;
                }
                current = current.next;
            }
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return default;
        }
        return default;
    }

    public void remove(int index) {
        try {
            if(index < 0 || index > this.lenght) throw new Exception($"ERRO => List.remove(): index out of bound, [0, {this.lenght}] -> {index}");

            Node<T>? current = this.head;
            while(current != null) {
                if(current.index == index) {
                    if (current.prev != null) {
                        current.prev.next = current.next;
                    } else {
                        this.head = current.next; 
                    }

                    if (current.next != null) {
                        current.next.prev = current.prev;
                    }
                    this.updateNodeIndex();
                    this.lenght -= 1;
                    break;
                }
                current = current.next;
            }
            this.updateNodeIndex();
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
        
    }

    public void show() {
        Node<T>? current = this.head;
		while(current != null) {
			Console.Write(current.next != null ? current.value + " -> " : current.value + "\n");
			current = current.next;
		}
    }

    public bool isEmpty() {
        return this.lenght == 0;
    }

    public void forEach(Action<T> action) {
        Node<T>? current = this.head;
		while(current != null) {
			action(current.value);
			current = current.next;
		}
    }

    private void updateNodeIndex() {
        int i = 0;
        Node<T>? current = this.head;
		while(current != null) {
			current.index = i;
			current = current.next;
            i++;
		}
    }
}