namespace ViewPoints.DependencyServices
{
    /// <summary>
    /// Třída pro získání cest ke speciálním složkám na daném systému
    /// </summary>
    public interface IPathHelper
    {
       string GetDocumentsDirectoryPath();
    }
}
