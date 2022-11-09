namespace Application.Infrastructure
{
#warning consider add a DomainModel
    public interface IDomainModelPersistence<TDomainModel> //where TDomainModel : DomainModel
    {
        Task Persist(TDomainModel domainModel);
    }
}
