using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        //Criar db, tabela, migração
        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;Database=dbAPI;Uid=root;Pwd=root";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            
            optionBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            
            return new MyContext(optionBuilder.Options);
        }
    }
}