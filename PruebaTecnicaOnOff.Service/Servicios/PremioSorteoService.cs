using PruebaTecnicaOnOff.Model.Models;
using PruebaTecnicaOnOff.Service.Servicios.IServicios;
using PruebaTecnicaOnOff.Repository.Repository.IRepository;
using PruebaTecnicaOnOff.Repository.Context;
using System.Text.RegularExpressions;

namespace PruebaTecnicaOnOff.Service.Servicios
{
	public class PremioSorteoService : IPremioSorteoService
	{
		private readonly IPremioSorteoRepository _premioSorteoRepository;
		private readonly PruebaTecnicaOnOffContext _context;
		public PremioSorteoService(IPremioSorteoRepository premioSorteoRepository, PruebaTecnicaOnOffContext context)
		{
			_premioSorteoRepository = premioSorteoRepository;
			_context = context;
		}

		public void InsertarPremio(PremioSorteo premio)
		{
			_premioSorteoRepository.InsertarPremio(premio);
		}

		public async Task<string> InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			string numeroAsignar = GenerarNumeroAleatorio(numeroAsignado);
			numeroAsignado.Numero = numeroAsignar;
			await _premioSorteoRepository.InsertarNumeroAsignado(numeroAsignado);
			return numeroAsignar;
		}

		private string GenerarNumeroAleatorio(NumeroAsignado numeroAsignado)
		{
			string numero;
			Random random = new();
			do
			{
				int longitud = 5;
				numero = random.Next(1, 100000).ToString().PadLeft(longitud, '0');
				numeroAsignado.Numero = numero;
			} while (MasDeTresNumerosIguales(numero.ToString()) && _premioSorteoRepository.ValidarAsignacionDeNumero(numeroAsignado));

			return numero;
		}


		private static bool MasDeTresNumerosIguales(string numero)
		{
			string patron = @"(\d)\1{2}";
			Match coincidencia = Regex.Match(numero, patron);
			return coincidencia.Success;
		}
	}
}
