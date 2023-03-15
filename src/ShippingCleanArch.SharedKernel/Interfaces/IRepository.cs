using Ardalis.Specification;

namespace ShippingCleanArch.SharedKernel.Interfaces;
// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
