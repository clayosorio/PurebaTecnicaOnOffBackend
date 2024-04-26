using Microsoft.EntityFrameworkCore;
using PruebaTecnicaOnOff.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Repository.Context
{
	public class PruebaTecnicaOnOffContext : DbContext
	{
		public PruebaTecnicaOnOffContext() { }

		public DbSet<NumeroAsignado> NumeroAsignado { get; set; }

		public PruebaTecnicaOnOffContext(DbContextOptions options) : base(options)
		{
		}
	}
}
