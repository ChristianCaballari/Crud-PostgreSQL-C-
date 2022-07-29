using postgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace postgreSQL.Repositories
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCart();
        Task<Car> GetCarDetails(int id);
        Task<bool> InsertCar(Car car);
        Task<bool> UpdateCar(Car car,int id);
        Task<bool> DeleteCar(Car car);
    }
}
