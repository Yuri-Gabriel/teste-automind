namespace MyProject;

class Program {
    public static void Main(string[] args) {
        Gerenciador g = new Gerenciador();

        g.addUsuario("yuri", "yuri@1234gmail.com", 18);
        g.addUsuario("joao", "joao@hotmail.com", 12);
        g.addUsuario("mario", "mario10@outlook.com", 22);

        g.exibirUsuarios();

        

        g.removerUsuario("joao@hotmail.com");
        g.exibirUsuarios();
        Usuario? user = g.getUsuario(0);
        g.exibirUmUsuario(user.email);
    }
}
