using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _7semester_ASP_ThirdTask;

namespace _7semester_ASP_SecondTask.Data
{
    public class SlavesContext : DbContext
    {
        public SlavesContext (DbContextOptions<SlavesContext> options)
            : base(options)
        {
			//Database.EnsureDeleted();
			Database.EnsureCreated();

			if (!Masters.Any())
			{
				Master window = new Master { Name = "Window" };
				Master oracle = new Master { Name = "Oracle" };

				Slave slave1 = new Slave { SkinTone = "Black", Master = oracle, Age = 18, Price = 100 };
				Slave slave2 = new Slave { SkinTone = "WhiterThanBlack", Master = oracle, Age = 14, Price = 100 };
				Slave slave3 = new Slave { SkinTone = "TotallyBlack", Master = null, Age = 16, Price = 100 };

				Masters.AddRange(oracle, window);
				Slaves.AddRange(slave1, slave2, slave3);
				Slave slave4 = new Slave { SkinTone = "Black", Master = oracle, Age = 18, Price = 100 };
				Slave slave5 = new Slave { SkinTone = "WhiterThanBlack", Master = window, Age = 14, Price = 100 };
				Slave slave6 = new Slave { SkinTone = "TotallyBlack", Master = null, Age = 16, Price = 100 };
				Slaves.AddRange(slave4, slave5, slave6);
				SaveChanges();
			}
		}

        public DbSet<_7semester_ASP_ThirdTask.Slave> Slaves { get; set; } = default!;
		public DbSet<_7semester_ASP_ThirdTask.Master> Masters { get; set; } = default!;
	}
}
