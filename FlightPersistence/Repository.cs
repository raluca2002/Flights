using System;
using System.Collections.Generic;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
    public interface Repository<TId, TEntity>
    {
        List<TEntity> findAll();
        TEntity findOne(int id);
        TEntity findByName(string nume);
        TEntity findByDestination(string destinatie, DateTime data);
        TEntity save(TEntity entity);
        TEntity update(TEntity entity);
    }
}