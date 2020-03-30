/// <author> Kiwin Bendtsen Andersen </author>

/// <summary>
/// This namespace contains a bad example of the dependency inversion principle.
/// </summary>
namespace dependencyInversionPrinciple.BadExample { 

    public class WareReporter
    {
        MySQLDatabase database;

        public void OpenWareReport()
        {
            //Database ware retrieval.
        }
        public void SaveWareReport()
        {
            //Save the report locally.
        }
    }

    public class MySQLDatabase
    {
        public void Create()
        {
            /* Creation code */
        }

        public void Read()
        {
            /* Retrieval code */
        }

        public void Update()
        {
            /* Altering code */
        }

        public void Delete()
        {
            /* Deletion code */
        }
    }

}

/// <summary>
/// This namespace contains a good example of the dependency inversion principle.
/// </summary>
namespace dependencyInversionPrinciple.GoodExample
{

    public interface IDatabase
    {
        public void Create();
        public void Read();
        public void Update();
        public void Delete();
    }

    public class WareReporter
    {
        IDatabase database; //Any IDatabase!

        public void OpenWareReport()
        {
            //Database ware retrieval.
        }
        public void SaveWareReport()
        {
            //Save the report locally.
        }
    }

    public class MySQLDatabase : IDatabase
    {
        public void Create()
        {
            /* Creation code */
        }

        public void Read()
        {
            /* Retrieval code */
        }

        public void Update()
        {
            /* Altering code */
        }

        public void Delete()
        {
            /* Deletion code */
        }
    }

    public class Neo4jDatabase : IDatabase
    {
        public void Create()
        {
            /* Creation code */
        }

        public void Read()
        {
            /* Retrieval code */
        }

        public void Update()
        {
            /* Altering code */
        }

        public void Delete()
        {
            /* Deletion code */
        }
    }

}