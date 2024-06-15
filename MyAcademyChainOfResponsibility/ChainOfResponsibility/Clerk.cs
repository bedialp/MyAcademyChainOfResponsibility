using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
	public class Clerk : Employee
	{
		private readonly CoFContext _context;

		public Clerk(CoFContext context)
		{
			_context = context;
		}
		public override void Process(CustomerProcessViewModel request)
		{
			if (request.Price <= 50000)
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Fevzi Alp Kutuk - Gise Memuru",
					Description = "Para cekme islemi basariyla gerceklesti, Musteriye para odendi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();
			}
			else if (_nextApprover != null)
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Fevzi Alp Kutuk - Gise Memuru",
					Description = "Para cekme islemi basarisiz oldu, Musteri Mudur Yardimcisina yonlendirildi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();

				_nextApprover.Process(request);
			}
		}
	}
}
