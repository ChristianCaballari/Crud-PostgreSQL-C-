using Dapper;
using Npgsql;
using postgreSQL.Model;
using postgreSQL.PostgreSQLConfiguration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace postgreSQL.Repositories
{

    public class CarRepository : ICarRepository
    {
        private  PostgreeSQLConfiguration _connection;

        public CarRepository(PostgreeSQLConfiguration conection) {
        _connection = conection;
         }

        protected NpgsqlConnection dbConnection() {
            return new NpgsqlConnection(_connection.ConnectionString);
        }
        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM ""Car""
                        WHERE id = @Id";
            var result = await db.ExecuteAsync(sql, new { car.Id });
            return result > 0;
        }

        public async Task<IEnumerable<Car>> GetAllCart()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, make, model, color, year, doors
                        FROM ""Car""
                        ";
            return await db.QueryAsync<Car>(sql, new { });


        }

        public async Task<Car> GetCarDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, make, model, color, year, doors
                        FROM ""Car""
                         WHERE id=@id";
            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { Id = id });

        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO ""Car"" (make, model, color, year, doors)
                         VALUES(@Make, @Model, @Color, @Year, @Doors)";
            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model,car.Color, car.Year, car.Doors });
            return result > 0;
        }

        public async Task<bool> UpdateCar(Car car,int id)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE ""Car""
                        SET make = @Make,
                            model = @Model,
                            color = @Color,
                            year = @Year,
                            doors = @Doors
                         WHERE id=@id";
            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors, id });
            return result > 0;
        }
    }
}
