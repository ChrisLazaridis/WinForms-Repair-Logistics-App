using System.Xml.Linq;

namespace OptionCo
{
    public class DBConnection(string name)
    {
        public string ConnectionString { get; } = $"Data Source={name};Version=3;";
    }
}