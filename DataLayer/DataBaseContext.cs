

using Microsoft.EntityFrameworkCore;
using RestfulWebApiEx.Models;

namespace RestfulWebApi.DataLayer
{
    public class DataBaseContext:DbContext
    {
        //DB Tabloları DbContext ile burada tanımlanır. CodeFirst ile DB ye yollanması gerek
        
        public DataBaseContext(DbContextOptions<DataBaseContext> opt): base (opt)
        {
            
        }
      
      public DbSet<Posts>? Posts{get;set;}
      public DbSet<Users>? Users{get;set;}
    }
}