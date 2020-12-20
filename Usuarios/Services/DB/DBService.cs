using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Models;

namespace Usuarios.Services
{
    public class DBService : IDBService
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        SqlConnection _connection;

        public DBService()
        {
            builder.DataSource = "jonathan-db.database.windows.net";
            builder.UserID = "master";
            builder.Password = "CGUFzCCIEB21";
            builder.InitialCatalog = "usuarios";
        }

        public void PrepararConexao()
        {
            try
            {
                if (_connection == null)
                    _connection = new SqlConnection(builder.ConnectionString);
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Consultas -------------------------------------------------------------------------------
        public List<User> ObterUsuarios()
        {
            try
            {
                PrepararConexao();
                string sql = $"select id, name, password, email, type from dbo.Usuarios";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                List<User> Usuarios = new List<User>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Usuarios.Add(new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Password = reader.GetString(2), Email = reader.GetString(3), Type = reader.GetInt32(4) });
                    }
                    reader.Close();
                }

                return Usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User ObterUsuarioPorNome(string name)
        {
            try
            {
                PrepararConexao();
                string sql = $"select top 1 name, password, email, type from dbo.Usuarios where name = '{name}'";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                User usuario = null;
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usuario = new User() { Name = reader.GetString(0), Password = reader.GetString(1), Email = reader.GetString(2), Type = reader.GetInt32(3) };
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User ObterUsuarioPorId(int id)
        {
            try
            {
                PrepararConexao();
                string sql = $"select id, name, password, email, type from dbo.Usuarios where id = {id}";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                User usuario = null;
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usuario = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Password = reader.GetString(2), Email = reader.GetString(3), Type = reader.GetInt32(4) };
                    }
                    reader.Close();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //CRUD ------------------------------------------------------------------------------------
        public User CriarUsuario(User _usuario)
        {
            try
            {
                PrepararConexao();
                string sql = $"insert into dbo.Usuarios (name, password, email, type) " +
                    $" values ('{_usuario.Name}', '{_usuario.Password}', '{_usuario.Email}', {_usuario.Type});" +
                    $"select top 1 id, name, password, email, type from dbo.Usuarios order by id desc;";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                User usuario = null;
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usuario = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Password = reader.GetString(2), Email = reader.GetString(3), Type = reader.GetInt32(4) };
                    }

                    reader.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User AlterarUsuario(User _usuario)
        {
            try
            {
                PrepararConexao();
                string sql = $"Update dbo.usuarios set name = '{_usuario.Name}', email = '{_usuario.Email}', type = {_usuario.Type} where id = {_usuario.Id};" +
                    $"select id, name, password, email, type from dbo.usuarios where id = {_usuario.Id}";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                User usuario = null;
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usuario = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Password = reader.GetString(2), Email = reader.GetString(3), Type = reader.GetInt32(4) };
                    }

                    reader.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoverUsuario(User _usuario)
        {
            try
            {
                PrepararConexao();
                string sql = $"delete from dbo.usuarios where id = {_usuario.Id};";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User TrocarSenha(User _usuario)
        {
            try
            {
                PrepararConexao();
                string sql = $"Update dbo.usuarios set password = '{_usuario.Password}' where id = {_usuario.Id};" +
                    $"select id, name, password, email, type from dbo.usuarios where id = {_usuario.Id}";
                SqlCommand command = new SqlCommand(sql, _connection);
                SqlDataReader reader = command.ExecuteReader();
                User usuario = null;
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        usuario = new User() { Id = reader.GetInt32(0), Name = reader.GetString(1), Password = reader.GetString(2), Email = reader.GetString(3), Type = reader.GetInt32(4) };
                    }

                    reader.Close();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
