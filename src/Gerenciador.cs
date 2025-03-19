using System.Text.RegularExpressions;

namespace MyProject;

class Gerenciador {
    private List<Usuario> list;

    public Gerenciador() {
        this.list = new List<Usuario>();
    }

    public int numeroUsuarios() {
        return this.list.lenght;
    }

    public void addUsuario(string nome, string email, int idade) {
        try {
            if(idade <= 0 || idade > 100) throw new Exception($"ERRO => Gerenciar.addUsuario(): Idade inválida -> {idade}");
            if(nome.Trim().Equals("")) throw new Exception($"ERRO => Gerenciar.addUsuario(): Nome inválido -> {nome}");
            if(!this.validateEmail(email.Trim())) throw new Exception($"=> Gerenciar.addUsuario(): Email inválido -> {email}");
            if(this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.addUsuario(): Email já cadastrado -> {email}");
            //Console.WriteLine(nome + email + idade);
            Usuario user = new Usuario(nome, email, idade);
            this.list.add(user);
            //Console.WriteLine(nome + email + idade);

        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
    }
    
    /// <summary>
    ///     Pegar os dados de um usuario em especifico
    /// </summary>
    /// 
    /// <param name="index">
    ///     Indice do elemento que deseja pegar os dados
    /// </param>
    /// 
    /// <returns>
    ///     Se for encontrado, irá retornar um objeto Usuario.
    /// </returns>
    public Usuario? getUsuario(int index) {
        return this.list.get(index);
    }

    public void exibirUmUsuario(string email) {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não foi cadastrado nenhum usuario");
            return;
        }
        try {
            if(!this.validateEmail(email.Trim())) throw new Exception($"ERRO => Gerenciar.exibirUmUsuario(): Email inválido -> {email}");
            if(!this.emailExist(email)) throw new Exception($"ERRO => Gerenciar.exibirUmUsuario(): O email informado não entá cadastrado -> {email}");

            Usuario? user = null;
            this.list.forEach(value => {
                if(value.email.Equals(email)) {
                    user = value;
                    return;
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

    public void removerUsuario(string email) {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não foi cadastrado nenhum usuario");
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

    public void exibirUsuarios() {
        if(this.list.isEmpty()) {
            Console.WriteLine("Não foi cadastrado nenhum usuario");
            return;
        }
        int index = 0;
        Console.WriteLine("---------------------Todos os usuarios----------------------");
        this.list.forEach(value => {
            Console.WriteLine($"Indice: {index} | Nome: {value.nome} | Email: {value.email} | Idade: {value.idade}");
            index++;
        });
        Console.WriteLine("------------------------------------------------------------");
    }

    private bool validateEmail(string email) {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success;
    }

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