
using PruebaTecnicaOnOff.Model.Models;

namespace PruebaTecnicaOnOff.Repository.Repository.IRepository
{
	public interface IPremioSorteoRepository
	{
		void InsertarPremio(PremioSorteo premio);
		bool ValidarAsignacionDeNumero(NumeroAsignado numeroAsignado);
		//bool ValidarNumeroAsignado(NumeroAsignado numeroAsignado, int numero);
		Task InsertarNumeroAsignado(NumeroAsignado numeroAsignado);
	}
}
