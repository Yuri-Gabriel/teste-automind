namespace MyProject;

class Program {
    public static void Main(string[] args) {
        Gerencia<Usuario> g = new Gerencia<Usuario>();

        g.cadastrar(new Usuario("yuri", "yuri1234@gmail.com", 18));
        g.cadastrar(new Usuario("joao", "joao@hotmail.com", 12));
        g.cadastrar(new Usuario("mario", "mario10@outlook.com", 22));

        g.forEach(value => {
            Console.WriteLine($"Nome: {value.nome} | Email: {value.email} | Idade: {value.idade}");
        });
    }
}
