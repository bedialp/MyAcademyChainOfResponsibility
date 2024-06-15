using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
	public class RegionalManager : Employee
	{
		private readonly CoFContext _context;

		public RegionalManager(CoFContext context)
		{
			_context = context;
		}

		public override void Process(CustomerProcessViewModel request)
		{
			if (request.Price <= 500000)
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Meltem Ozturkcan - Bolge Muduru",
					Description = "Para cekme islemi basariyla gerceklesti, Musteriye para odendi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();
			}
			else
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Meltem Ozturkcan - Bolge Muduru",
					Description = "Para cekme islemi basarisiz oldu, Musteriye Odenecek para limiti asildi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();
			}
		}
	}
}
