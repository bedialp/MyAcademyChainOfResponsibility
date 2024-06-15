using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
	public abstract class Employee
	{
		protected Employee _nextApprover;
		public void SetNextApprover(Employee supervisor)
		{
			_nextApprover = supervisor;
		}
		public abstract void Process(CustomerProcessViewModel request);
	}
}
