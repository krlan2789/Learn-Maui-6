using LearnMaui6.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnMaui6
{
    public class PersonRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        private SQLiteAsyncConnection conn;

        private async Task Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Person>();
        }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                await Init();

                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                result = await conn.InsertAsync(new Person { Name = name });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            } catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<Person>> GetAllPeople()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<Person>().ToListAsync();
            } catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
