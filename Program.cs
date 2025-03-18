namespace MyProject;

class Program {
    public static void Main(string[] args) {
        List<Usuario> g = new List<Usuario>();

        g.add(new Usuario("yuri", "yuri1234@gmail.com", 18));
        g.add(new Usuario("joao", "joao@hotmail.com", 12));
        g.add(new Usuario("mario", "mario10@outlook.com", 22));

        g.forEach(value => {
            Console.WriteLine($"Nome: {value.nome} | Email: {value.email} | Idade: {value.idade}");
        });
    }
}
