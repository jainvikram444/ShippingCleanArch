using Ardalis.Result;

namespace ShippingCleanArch.Core.Interfaces;
public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
