namespace ITBIT.CORE.Entidades
{
    public class Usuario
    {
        public int UsuarioId { get; internal set; }

        public string Nome { get; internal set; }

        public string DataNascimento { get; internal set; }

        public string Senha { get; internal set; }
        
        public string Email { get; internal set; }

        public bool Status { get; internal set; }

        public Sexo Sexo { get; internal set; }

        protected Usuario() { }

        public Usuario(string pNome,string pDataNascimento,string pSenha,string pEmail, Sexo pSexo ,bool pSatus = true)
        {
            Nome           = pNome;
            DataNascimento = pDataNascimento;
            Senha          = pSenha;
            Sexo           = pSexo;
            Email          = pEmail;
            Status         = pSatus;
        }

        public Usuario(int pId, string pNome, string pDataNascimento, string pSenha, string pEmail, Sexo pSexo, bool pSatus = true)
        {
            UsuarioId = pId;
            Nome = pNome;
            DataNascimento = pDataNascimento;
            Senha = pSenha;
            Sexo = pSexo;
            Email = pEmail;
            Status = pSatus;
        }
    }
}
