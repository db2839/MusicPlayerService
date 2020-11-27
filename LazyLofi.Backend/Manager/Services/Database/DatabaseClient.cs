using Dapper;
using LazyLofi.Backend.Manager.Services.Database.Models;
using LazyLofi.Backend.Manager.Services.Youtube.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LazyLofi.Backend.Manager.Services.Database
{
    public class DatabaseClient
    {
        private const string tableName = "VideoTable";
        private readonly string connectionString;

        private readonly string CreateTableCommand = "CREATE TABLE IF NOT EXISTS VideoTable ( VideoId INTEGER PRIMARY KEY, Title TEXT NOT NULL, Url TEXT NOT NULL);";
        private SQLiteConnection sqlLiteConnection;

        /// <summary>
        /// Doeses the table exist.
        /// </summary>
        /// <returns></returns>
        private bool DoesTableExist()
        {
            bool exists;

            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                exists = ExecuteNonQuery($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';") == 1;

                sqlLiteConnection.Close();
            }

            return exists;
        }

        /// <summary>
        /// Executes the non query asynchronous.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        private int ExecuteNonQuery(string sql)
        {
            var sqlCommand = sqlLiteConnection.CreateCommand();
            sqlCommand.CommandText = sql;
            var result = sqlCommand.ExecuteNonQuery();
            return result;
        }

        /// <summary>
        /// Ares the there videos currently.
        /// </summary>
        /// <returns></returns>
        internal bool AreThereVideosCurrently()
        {
            bool result;

            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                result = this.sqlLiteConnection.QueryFirstOrDefault<int>($"SELECT EXISTS (SELECT 1 FROM {tableName});") == 1;

                sqlLiteConnection.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets the videos from database.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<VideoDatabaseResposne> GetVideosFromDatabase()
        {
            var videoList = new List<VideoDatabaseResposne>();

            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                videoList = sqlLiteConnection.Query<VideoDatabaseResposne>($"select Title, Url from {tableName}")
                    .AsList<VideoDatabaseResposne>();

                sqlLiteConnection.Close();
            }

            return videoList;
        }

        /// <summary>
        /// Initializes the database.
        /// </summary>
        internal bool InitializeDatabase()
        {
            if (DoesTableExist())
            {
                return false;
            }

            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                this.ExecuteNonQuery(this.CreateTableCommand);

                sqlLiteConnection.Close();
            }

            return true;
        }

        /// <summary>
        /// Loads the videos into database.
        /// </summary>
        /// <param name="videos">The videos.</param>
        internal void LoadVideosIntoDatabase(IEnumerable<VideoModel> videos)
        {
            var itemCount = 0;
            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                foreach (var video in videos)
                {
                    var sql = $"INSERT INTO {tableName} (Title, Url) VALUES('{video.Ttile}','{video.Url}')";
                    var result = ExecuteNonQuery(sql);
                    itemCount += result;
                    //Console.WriteLine(itemCount);
                }

                sqlLiteConnection.Close();
            }

            if (itemCount == 0)
            {
                throw new Exception("No Videos Found");
            }
        }

        /// <summary>
        /// Refreshes the database.
        /// </summary>
        internal void RefreshDatabase()
        {
            var sqlCommand = $"Delete from {tableName};";

            using (sqlLiteConnection = new SQLiteConnection(connectionString))
            {
                sqlLiteConnection.Open();

                this.ExecuteNonQuery(sqlCommand);

                sqlLiteConnection.Close();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseClient"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DatabaseClient(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}