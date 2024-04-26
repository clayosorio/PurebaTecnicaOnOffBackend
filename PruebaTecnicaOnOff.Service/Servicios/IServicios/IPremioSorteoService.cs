using PruebaTecnicaOnOff.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaOnOff.Service.Servicios.IServicios
{
	public interface IPremioSorteoService
	{
		void InsertarPremio(PremioSorteo premio);
		Task<string> InsertarNumeroAsignado(NumeroAsignado numeroAsignado);
	}
}
