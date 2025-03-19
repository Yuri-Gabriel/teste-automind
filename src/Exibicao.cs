namespace MyProject;

class Exibicao {

    private Gerenciador g;
    public Exibicao() {
        this.g = new Gerenciador();
    }

    public void start() {
        int option = 0;
        do {
            Console.WriteLine("=======Cadastro de usuarios=======");
            Console.WriteLine("[1] Listar todos os usuarios");
            Console.WriteLine("[2] Mostrar apenas um usuario");
            Console.WriteLine("[3] Adicionar um usuario");
            Console.WriteLine("[4] Remover um usuario");
            Console.WriteLine("[5] Sair");
            Console.WriteLine("==================================");

            option = this.getInputOption(5);
            Console.WriteLine("==================================");
            switch (option) {
                case 1: { //Listar todos
                    this.g.exibirUsuarios();
                    break;
                }
                case 2: { // Listar apenas um
                    Console.Write("Digite o email do usuario que deseja buscar: ");
                    string email = Console.ReadLine();
                    this.g.exibirUmUsuario(email);
                    break;
                }
                case 3: { // Adicionar
                    Console.Write("Digite um nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite um email: ");
                    string email = Console.ReadLine();
                    Console.Write("Digite uma idade: ");
                    int idade = 0;
                    int.TryParse(Console.ReadLine(), out idade);

                    this.g.addUsuario(nome, email, idade);
                    break;
                }
                case 4: { // Remover
                    Console.Write("Digite o email do usuario que deseja remover: ");
                    string email = Console.ReadLine();

                    this.g.removerUsuario(email);
                    break;
                }
                case 5: { // Sair
                    option = 0;
                    break;
                }
            }
        } while (option != 0);
    }

    private int getInputOption(int maxValue) {
        int option = -1;
        do {
            try {
                Console.Write("Escolha uma opção: ");
                int.TryParse(Console.ReadLine(), out option);
                if(option < 1 || option > maxValue) {
                    Console.WriteLine("Opção inválida!");
                }
            } catch (Exception err) {
                Console.WriteLine(err.Message);
            }
        } while(option < 1 || option > maxValue);
        return option;
    }
}