namespace ITBIT.CORE.DTO
{
    public class UsuarioRequest
    {
        public int UsuarioId { get; set; }
        public string Nome { get;set; }

        public string DataNascimento { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public int SexoId { get; set; }
    }
}
