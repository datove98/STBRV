﻿namespace STBRV.Entities.Repositories
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<bool> Insertar(TEntityModel modelo);

        Task<bool> Actualizar(TEntityModel modelo);

        Task<bool> Eliminar(int id);

        Task <IQueryable<TEntityModel>> Obtener();

        Task<TEntityModel> ObtenerPorId(int id);
    }
}
