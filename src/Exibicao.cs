namespace MyProject;

/// <summary>
///     Classe que exibe as opções no terminal para a interação com o programa
/// </summary>
class Exibicao {

    private Gerenciador g;
    public Exibicao() {
        this.g = new Gerenciador();
    }

    /// <summary>
    ///     Inicia o a visualização do projeto no terminal
    /// </summary>
    public void start() {
        int option = 0;
        do {
            Console.WriteLine("=======Cadastro de usuarios=======");
            Console.WriteLine("[1] Listar todos os usuarios");
            Console.WriteLine("[2] Mostrar apenas um usuario");
            Console.WriteLine("[3] Adicionar um usuario");
            Console.WriteLine("[4] Editar um usuario");
            Console.WriteLine("[5] Remover um usuario");
            Console.WriteLine("[6] Sair do programa");
            Console.WriteLine("==================================");

            option = this.getInputOption(6);
            Console.WriteLine("==================================");
            switch (option) {
                case 1: { //Listar todos
                    this.g.exibirUsuarios();
                    break;
                }
                case 2: { // Listar apenas um
                    this.g.exibirUsuarios();
                    
                    if(!this.g.existeCadastro()) break;

                    Console.Write("Digite o email do usuario que deseja buscar: ");
                    string email = Console.ReadLine();
                    this.g.exibirUmUsuario(email);
                    break;
                }
                case 3: { // Adicionar
                    Console.Write("Digite um nome: ");
                    string nome = Console.ReadLine();
                    if(string.IsNullOrEmpty(nome)) {
                        Console.WriteLine("Nome inválido");
                        break;
                    }

                    Console.Write("Digite um email: ");
                    string email = Console.ReadLine();
                    if(string.IsNullOrEmpty(email)) {
                        Console.WriteLine("Email inválido");
                        break;
                    }

                    Console.Write("Digite uma idade: ");
                    int idade = 0;
                    int.TryParse(Console.ReadLine(), out idade);
                    if(idade < 1) {
                        Console.WriteLine("Idade inválida");
                        break;
                    }
                    

                    this.g.addUsuario(nome, email, idade);
                    Console.WriteLine("Usuario adicionado!");
                    break;
                }
                case 4: { // Editar
                    this.g.exibirUsuarios();

                    if(!this.g.existeCadastro()) break;

                    Console.Write("Digite o email do usuario que deseja editar: ");
                    string email = Console.ReadLine();
                    if(!string.IsNullOrEmpty(email)) {
                        Usuario? user = this.g.editarUsuario(email);
                        option = this.editarUsuario(user);
                        option = option == 4 ? 0 : -1;
                    } else {
                        Console.WriteLine("Email inválido");
                    }
                    break;
                }
                case 5: { // Remover
                    this.g.exibirUsuarios();

                    if(!this.g.existeCadastro()) break;

                    Console.Write("Digite o email do usuario que deseja remover: ");
                    string email = Console.ReadLine();
                    if(!string.IsNullOrEmpty(email)) {
                        this.g.removerUsuario(email);
                        Console.WriteLine("Usuario removido!");
                    } else {
                        Console.WriteLine("Email inválido");
                    }
                    break;
                }
                case 6: { // Sair
                    option = 0;
                    break;
                }
            }
        } while (option != 0);
    }

    /// <summary>
    ///     Exibe as opções para editar um usuario em específico
    /// </summary>
    /// <param name="user">Instância do usuario que deseja editar</param>
    /// <returns>Retorna um <c>int</c> para dar continuidade na navegação</returns>
    private int editarUsuario(Usuario? user) {
        if(user == null) {
            return 3;
        }
        int option = 0;
        do {
            Console.WriteLine("=======O que deseja editar?=======");
            Console.WriteLine("[1] Nome");
            Console.WriteLine("[2] Idade");
            Console.WriteLine("[3] Voltar para a guia anterior");
            Console.WriteLine("[4] Sair do programa");
            Console.WriteLine("==================================");

            option = this.getInputOption(4);
            Console.WriteLine("==================================");
            switch (option) {
                case 1: { // Editar nome
                    Console.Write("Digite o novo nome: ");
                    string nome = Console.ReadLine().Trim();
                    if(!string.IsNullOrEmpty(nome)) {
                        user.nome = nome;
                        Console.WriteLine("Nome editado!");
                    } else {
                        Console.WriteLine("Nome inválido");
                    }
                    return -1;
                }
                case 2: { // Editar idade
                    Console.Write("Digite a nova idade: ");
                    int idade = 0;
                    int.TryParse(Console.ReadLine(), out idade);
                    if(option > 0) {
                        user.idade = idade;
                        Console.WriteLine("Idade editada!");
                    } else {
                        Console.WriteLine("Idade inválida");
                    }
                    option = 0;
                    break;
                }
                case 3: { // Voltar
                    option = 0;
                    break;
                }
                case 4: { // Sair do programa
                option = 4;
                   return option;
                }
            }
        } while (option != 0);
        return option;
    }

    /// <summary>
    ///     Pegar o input do terminal, faz verificações e o retorna
    /// </summary>
    /// <param name="maxValue">Valor máximo que pode ser inserido</param>
    /// <returns>O valor <c>int</c> inserido no terminal</returns>
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