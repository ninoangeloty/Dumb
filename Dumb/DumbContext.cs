using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb
{
    public abstract class DumbContext<T> where T : new()
    {
        public DumbContext(string key)
        {
            const string pw = "y@d$t&a%09$pa%ad";
            _conntectionString = string.Format(ConfigurationManager.ConnectionStrings[key].ConnectionString, pw);
        }

        public IEnumerable<T> Query(string sql)
        {
            return this.ExecuteQuery(sql, EntityCache.Get<T>());
        }

        private IEnumerable<T> ExecuteQuery(string sql, ModelInfo modelInfo)
        {
            var items = new List<T>();

            using (var conn = new SqlConnection(this.ConnectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    this.Columns = this.GetColumnNames(reader);
                    while (reader.Read())
                    {
                        items.Add(this.Get(reader, modelInfo));
                    }
                }
            }

            return items;
        }

        private T Get(SqlDataReader reader, ModelInfo modelInfo)
        {
            var item = new T();

            foreach (var column in this.Columns)
            {
                if (modelInfo.Properties.Any(_ => _.Field != null && _.Field.Name == column))
                {
                    var prop = modelInfo.Properties.Single(_ => _.Field != null && _.Field.Name == column);
                    typeof(T).GetProperty(prop.Member.Name).SetValue(item, reader[prop.Field.Name]);
                }
            }

            return item;
        }

        private IEnumerable<string> GetColumnNames(SqlDataReader reader)
        {
            var columns = new List<string>();
            var count = reader.VisibleFieldCount;

            for (int i = 0; i < count; i++)
            {
                columns.Add(reader.GetName(i));
            }

            return columns;
        }

        private string _conntectionString;
        public string ConnectionString
        {
            get { return _conntectionString; }
        }

        private IEnumerable<string> Columns { get; set; }
    }
}
