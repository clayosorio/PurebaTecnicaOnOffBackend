﻿using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaOnOff.Model.Models;
using PruebaTecnicaOnOff.Service.Servicios.IServicios;

namespace PruebaTecnicaOnOff.Infrastructure.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class SorteoController : ControllerBase
	{
		IPremioSorteoService _premioSorteoService;
		public SorteoController(IPremioSorteoService premioSorteoService)
		{
			_premioSorteoService = premioSorteoService;
		}

		[HttpPost]
		public async Task<IActionResult> InsertarPremio(PremioSorteo premio)
		{
			_premioSorteoService.InsertarPremio(premio);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> InsertarNumeroAsignado(NumeroAsignado numeroAsignado)
		{
			string result = await _premioSorteoService.InsertarNumeroAsignado(numeroAsignado);
			return Ok(result);
		}
	}
}
