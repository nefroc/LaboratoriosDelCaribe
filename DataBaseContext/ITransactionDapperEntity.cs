using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataBaseContext
{
    public interface ITransactionDapperEntity
    {
        public IDbConnection Connection { get; }
    }
}