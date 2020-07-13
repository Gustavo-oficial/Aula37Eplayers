using System.Collections.Generic;

namespace Aula37E_players.Models
{
    public interface INoticia
    {
        void Create(Noticias a);

        List<Noticias> ReadAll();

        void Update(Noticias a);

        void Delete(int id);
    }
}