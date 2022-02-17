using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDCliente.Data.Database
{
    public static class PreMigration
    {
        public static void Execute(MigrationBuilder builder)
        {
            // adicionar isso no início do Up da primeira migration manualmente
            builder.Sql(@"
            -- @outersql will build a command for each database
            -- @innersql will be the db-specific commands for each user
            DECLARE @outersql NVARCHAR(MAX), @innersql NVARCHAR(MAX);
            SELECT @outersql = N'', @innersql = N'';
            -- here we build a USE command and all of the ALTER USER commands for each database
            SELECT @outersql = @outersql + N'SELECT
            @innersql = @innersql + N''USE ' + QUOTENAME(name) + ';
            ALTER USER '' + QUOTENAME(name) + '' WITH DEFAULT_SCHEMA = dbo;
            '' FROM ' + QUOTENAME(name) + '.sys.database_principals
            WHERE type_desc = N''SQL_USER''
            AND default_schema_name <> N''dbo''
            AND name NOT IN (N''dbo'',N''guest'');'
            FROM sys.databases WHERE database_id > 4 -- non-system databases
            AND state = 0; -- online
            -- we need to execute the outer SQL to pull out the inner SQL
            EXEC sp_executesql @outersql,
            N'@innersql NVARCHAR(MAX) OUTPUT',
            @innersql OUTPUT;
            EXEC sp_executesql @innersql;
            ");
        }
    }
}
