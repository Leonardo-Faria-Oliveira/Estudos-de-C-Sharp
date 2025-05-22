using Dapper;
using Domain.Adapters.Request.User;
using Domain.Repositories.User;

namespace Infrastructure.Persistence.SQLServer.Repositories
{
    internal class UserRepository(IWriteDbConnection connection) : IUserWriteRepository
    {

        private readonly IWriteDbConnection _connection = connection;

        public async Task CreateUser(CreateUserRequest user)
        {

            using var connection = _connection.CreateConnection();

            var sql = @"
                INSERT INTO [user] (id, name, surname, email, password_hash, username, is_active, updated_at, created_at, refresh_token, refresh_expiration_time)
                VALUES (@Id, @Name, @Surname, @Email, @PasswordHash, @Username, @IsActive, @UpdatedAt, @CreatedAt, @RefreshToken, @Expiration);
            ";

            await connection.ExecuteAsync(sql, new
            {
                Id = new Guid(),
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                Username = user.Username,
                IsActive = user.IsActive,
                UpdatedAt = DateTimeOffset.Now,
                CreatedAt = DateTimeOffset.Now,
                RefreshToken = "",
                Expiration = DateTime.Now,
            });

        }
    }
}
