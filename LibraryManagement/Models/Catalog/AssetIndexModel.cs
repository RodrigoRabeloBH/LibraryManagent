using System.Collections.Generic;

namespace LibraryManagement.Models.Catalog
{
    public class AssetIndexModel
    {
        public IEnumerable<AssetIndexListModel> Assets { get; set; }
    }
}
