using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.DAL.Repositories.Interfaces
{
    public interface ICrudCommandsGenerator<T>
    {
        string DeleteEntity(T entity);

        string CreateEntity(T entity);

        string UpdateEntity(T entity);

        string GetEntity(int id);

        string GetAllEntities();
    }
}
