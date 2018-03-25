using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using static DevOps.Build.AppVeyor.AzureStorageTableLedger.Builder.AppveyorBuildTableHelper;
using static DevOps.Build.AppVeyor.GetAzureTable.AzureTableGetter;

namespace DevOps.Build.AppVeyor.AddBuild
{
    /// <summary>Function adds the given repository build information to an Azure Storage Table ledger</summary>
    public static class BuildAdder
    {
        /// <summary>Adds a table entry to an Azure Table named "appveyor"</summary>
        public static async Task AddBuildAsync(string name, string version, string dependencies = null, string fileHashes = null)
        {
var entry = BuildTableEntry(name, version, dependencies, fileHashes);
var operation = TableOperation.InsertOrReplace(entry);
var table = await GetTable();
await table.ExecuteAsync(operation);;
        }
    }
}
