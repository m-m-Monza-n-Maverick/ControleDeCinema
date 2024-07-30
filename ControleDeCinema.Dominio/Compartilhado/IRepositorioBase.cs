namespace ControleDeCinema.Dominio.Compartilhado
{
    public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        void Inserir(TEntidade registro);
        bool Editar(TEntidade registroAtualizado);
        bool Excluir(TEntidade registro);
        TEntidade SelecionarPorId(int id);
        List<TEntidade> SelecionarTodos();
    }
}
