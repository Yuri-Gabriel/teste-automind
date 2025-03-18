namespace MyProject;

class Usuario {
    public string nome {get; set;}
    public string email {get; set;}
    public int idade {get; set;}

    public Usuario(string nome, string email, int idade) {
        this.nome = nome;
        this.email = email;
        this.idade = idade;
    }
}