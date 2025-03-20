namespace MyProject;
/// <summary>
///     Classe que representa o usuario a ser cadastrado
/// </summary>
class Usuario {
    public string nome {get; set;}
    public string email {get; set;}
    public int idade {get; set;}

    public Usuario(string nome, string email, int idade) {
        this.nome = nome.Trim();
        this.email = email.Trim();
        this.idade = idade;
    }

    
}