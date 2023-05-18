using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage;
using WebApplication7.Controllers;
using WebApplication7.Data;

namespace WebApplication7.Models
{
    public class ActualPolicyholder
    {
        // vytvoření třídy pro přenos hodnot mezi kontrolery
        // 
        public PolicyholdersController? policyholdersController = new PolicyholdersController(context);
        private static ApplicationDbContext context;

        public int ActualId { get; set; }
        public string ActualFirstName { get; set; }
        public string ActualLastName { get; set; }


        //při využití konstruktoru mi to vyhazuje chybu - Nelze vytvořit instanci typu 'WebApplication7.Models.ActualPolicyholder'.
        //Komplexní typy vázané na model nesmí být abstraktní nebo hodnotové typy a musí mít konstruktor bez parametrů.
        //Typy záznamů musí mít jeden primární konstruktor. Alternativně zadejte parametru 'actualPolicyholder' nenulovou výchozí hodnotu.

        /*public ActualPolicyholder(PolicyholdersController policyholdersController)
        {
            ActualId = policyholdersController.ActualPolicyholderId;
            ActualFirstName = policyholdersController.ActualPolicyholderFirstName;
            ActualLastName = policyholdersController.ActualPolicyhoderLastName;
        }*/

        //při využití metod mi to vyhazuje chybu
        //Při zpracování požadavku došlo k neošetřené výjimce.
        //SqlException: Příkaz INSERT byl v konfliktu s omezením FOREIGN KEY "FK_Assurance_Policyholder_PolicyholderId".
        //Ke konfliktu došlo v databázi "aspnet-WebApplication7", tabulce "dbo.Policyholder", sloupci 'Id'.
        //Výpis byl ukončen.
        //Microsoft.Data.SqlClient.SqlConnection.OnError(výjimka SqlException, bool breakConnection, Action<Action> wrapCloseInAction)

        //DbUpdateException: Při ukládání změn entity došlo k chybě.Podrobnosti viz vnitřní výjimka.
        //Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
        public int ForwardId (int ActualId, PolicyholdersController policyholdersController)
        {
            ActualId = policyholdersController.ActualPolicyholderId;
            return ActualId;
        }
        public string ForwardFirstName (string ActualFirstName, PolicyholdersController policyholdersController)
        {
            ActualFirstName = policyholdersController.ActualPolicyholderFirstName;
            return ActualFirstName;
        }
        public string ForwardLastName (string ActualLastName,  PolicyholdersController policyholdersController)
        {
            ActualLastName = policyholdersController.ActualPolicyhoderLastName;
            return ActualLastName;
        }
    }
}
