using System.Text.RegularExpressions;

namespace MyProject;

/// <summary>
///     Classe que gerencia o cadastro dos usuarios
/// </summary>
class Gerenciador {
    private List<Usuario> list;

    public Gerenciador() {
        this.list = new List<Usuario>();
    }

    /// <summary>
    ///     Cadastra um novo usuario no sistema
    /// </summary>
    /// <param name="nome">Nome do novo usuario</param>
    /// <param name="email">Email do novo usuario</param>
    /// <param name="idade">Idade do novo usuario</param>
    public void addUsuario(string nome, string email, int idade) {
        try {
            if(idade <= 0 || idade > 100) throw new Exception($"ERRO => Gerenciar.addUsuario(): Idade inválida -> {idade}");
            if(nome.Trim().Equals("")) throw new Exception($"ERRO => Gerenciar.addUsuario(): Nome inválido -> {nome}");
            if(!this.validateEmail(email.Trim())) throw new Exception($"ERRO => Gerenciar.addUsuario(): Email inválido -> {email}");
            if(this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.addUsuario(): Email já cadastrado -> {email}");
            
            Usuario user = new Usuario(nome, email, idade);
            this.list.add(user);

        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
    }
    
    /// <summary>
    ///     Pega os dados de um usuário específico.
    /// </summary>
    /// <param name="index">Índice do usuário na lista.</param>
    /// <returns>
    ///      O objeto <see cref="Usuario"/> se encontrado; caso contrário, <c>null</c>.
    /// </returns>
    public Usuario? getUsuario(int index) {
        return this.list.get(index);
    }

    /// <summary>
    ///     Informa de existe algum usuario cadastro
    /// </summary>
    /// <returns>
    ///      Caso exista cadastro retorna <c>true</c>, caso contrario, <c>false</c>
    /// </returns>
    public bool existeCadastro() {
        return !this.list.isEmpty();
    }

    /// <summary>
    ///     Busca e exibe informações de um usuario em específico
    /// </summary>
    /// <param name="email">Email do usuario que deseja buscar</param>
    public void exibirUmUsuario(string email) {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não há nenhum usuario");
            return;
        }
        try {
            if(!this.validateEmail(email.Trim())) throw new Exception($"ERRO => Gerenciar.exibirUmUsuario(): Email inválido -> {email}");
            if(!this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.exibirUmUsuario(): O email informado não entá cadastrado -> {email}");

            Usuario? user = null;
            this.list.forEach(value => {
                if(value.email.Equals(email)) {
                    user = value;
                }
            });
            if(user != null) {
                Console.WriteLine("---------------------------Usuario--------------------------");
                Console.WriteLine($"Nome: {user.nome} | Email: {user.email} | Idade: {user.idade}");
                Console.WriteLine("------------------------------------------------------------");
            } else {
                throw new Exception($"ERRO => Gerenciar.exibirUsuario(): Usuario não encontrado");
            }

        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
    }

    /// <summary>
    ///     Busca o usuario que deseja editar os dados
    /// </summary>
    /// <param name="email">Email do usuario que deseja editar</param>
    /// <returns>
    ///     Caso encontre, retorna a instância do usuario buscado, caso contrario, <c>null</c>
    /// </returns>
    public Usuario? editarUsuario(string email) {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não há nenhum usuario");
            return null;
        }
        Usuario? user = null;
        try {
            if(!this.validateEmail(email.Trim())) throw new Exception($"ERRO => Gerenciar.removerUsuario(): Email inválido -> {email}");
            if(!this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.removerUsuario(): O email informado não foi cadastrado -> {email}");

           
            this.list.forEach(value => {
                if(value.email.Equals(email)) {
                    user = value;
                }
            });
            
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return null;
        }
        return user;
    }

    /// <summary>
    ///     Busca e remove o cadastro do usuario desejado
    /// </summary>
    /// <param name="email">Email do usuario que deseja remover</param>
    public void removerUsuario(string email) {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não há nenhum usuario");
            return;
        }
        try {
            if(!this.validateEmail(email.Trim())) throw new Exception($"ERRO => Gerenciar.removerUsuario(): Email inválido -> {email}");
            if(!this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.removerUsuario(): O email informado não foi cadastrado -> {email}");

            int index = 0;
            bool find = false;
            this.list.forEach(value => {
                if(value != null && value.email.Equals(email)) {
                    find = true;
                } 
                if(!find) {
                    index++;
                }
            });
            this.list.remove(index);
            
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
    }

    /// <summary>
    ///     Exibi os dados de todos os usuarios cadastrados
    /// </summary>
    public void exibirUsuarios() {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não há nenhum usuario");
            return;
        }
        Console.WriteLine("---------------------Todos os usuarios----------------------");
        this.list.forEach(value => {
            Console.WriteLine($"Nome: {value.nome} | Email: {value.email} | Idade: {value.idade}");
        });
        Console.WriteLine("------------------------------------------------------------");
    }

    /// <summary>
    ///     Verifica se o email enviado é válido
    /// </summary>
    /// <param name="email">Email a ser verificado</param>
    /// <returns>
    ///     Caso seja válido, retorna <c>true</c>, caso contrario, <c>false</c>
    /// </returns>
    private bool validateEmail(string email) {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success;
    }

    /// <summary>
    ///     Verifica se o email enviado já foi cadastrado
    /// </summary>
    /// <param name="email">Email a ser verificado</param>
    /// <returns>
    ///     Caso seja encontrado, retorna <c>true</c>, caso contrario, <c>false</c>
    /// </returns>
    private bool emailExist(string email) {
        bool exist = false;
        try {
            if(!this.validateEmail(email.Trim())) throw new Exception($"=> Gerenciar.emailExist(): Email inválido -> {email}");
            this.list.forEach(value => {
                if(value.email.Equals(email)) exist = true;
            });
        } catch (Exception err) {
            Console.WriteLine(err.Message);
        }
        
        return exist;
    }
}