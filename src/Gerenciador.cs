using System.Text.RegularExpressions;

namespace MyProject;

class Gerenciador {
    private List<Usuario> list;

    public Gerenciador() {
        this.list = new List<Usuario>();
    }

    public void addUsuario(string nome, string email, int idade) {
        try {
            if(idade < 0 || idade > 100) throw new Exception("Idade inválida");
            if(nome.Trim().Equals("")) throw new Exception("Nome inválido");
            if(!this.validateEmail(email.Trim())) throw new Exception("Email inválido");
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }
        Usuario user = new Usuario(nome, email, idade);
        this.list.add(user);
    }

    private bool validateEmail(string email) {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        return match.Success;
    }
}