using System.Data;
using Dapper;

namespace Customers.Api.Database;

public class DapperGuidTypeHandler : SqlMapper.TypeHandler<Guid>
{
    public override void SetValue(IDbDataParameter parameter, Guid value)
    {
        parameter.Value = value;
    }

    public override Guid Parse(object value)
    {
        return Guid.Parse(value.ToString() ?? string.Empty);
    }
}