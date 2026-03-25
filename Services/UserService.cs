using Amrod_E_Commerce.Data.Context;
using Amrod_E_Commerce.Data.Entities;
using Amrod_E_Commerce.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Amrod_E_Commerce.Services
{
    public class UserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email is required.", nameof(user.Email));

            if (string.IsNullOrWhiteSpace(user.PasswordHash))
                throw new ArgumentException("Password is required.", nameof(user.PasswordHash));

            user.PasswordHash = Hasher.HashPassword(user.PasswordHash);

            try
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return user;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error creating user: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while creating the user.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not save user due to data conflict or constraint violation.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error creating user: {ex.Message}");
                throw;
            }
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password is required.", nameof(password));

            try
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null) 
                    return null;

                var hashedPassword = Hasher.HashPassword(password);
                if (user.PasswordHash != hashedPassword) return null;

                return user;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error during login: {ex.Message}");
                throw;
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _db.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error getting all users: {ex.Message}");
                throw;
            }
        }

        public async Task<User?> GetUserById(Guid id)
        {
            try
            {
                return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error getting user by Id: {ex.Message}");
                throw;
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            try
            {
                return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error getting user by email: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);

                if (user == null)
                    return false;

                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.Error.WriteLine($"SQL Error deleting user: {sqlEx.Message}");
                throw new InvalidOperationException("Database error occurred while deleting the user.", sqlEx);
            }
            catch (DbUpdateException dbEx)
            {
                Console.Error.WriteLine($"EF Core update error: {dbEx.Message}");
                throw new InvalidOperationException("Could not delete user due to data conflict or constraint violation.", dbEx);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error deleting user: {ex.Message}");
                throw;
            }
        }
    }
}