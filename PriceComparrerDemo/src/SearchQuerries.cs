using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceComparrerWinforms.src
{
    public static class SearchQuerries
    {
        public static string ReadComponentModelOneSearchItem(string tableName, string webSiteName, string componentCategory) => $"Select ComponentTitle , ComponentHyperlink   from {tableName} where WebSiteName = '{webSiteName}' and ComponentTitle Like '%25{componentCategory}%25'";

        public static string ReadComponentModelTwoSearchItems(string tableName, string webSiteName, string componentCategory, string componentModel) => $"Select ComponentTitle , ComponentHyperlink From {tableName} Where WebSiteName = '{webSiteName}' and ComponentTitle Like '%25{componentCategory}%25{componentModel}%25'";

        public static string ReadComponentModelThreeSearchItems(string tableName, string webSiteName, string componentCategory, string componentModel, string componentSeries) => $"Select ComponentTitle , ComponentHyperlink From {tableName} Where WebSiteName = '{webSiteName}' and ComponentTitle Like '%25{componentCategory}%25{componentModel}%25{componentSeries}%25'";

        public static string ReadComponentModelFourSearchItems(string tableName, string webSiteName, string componentCategory, string componentModel, string componentSeries, string key) => $"Select ComponentTitle , ComponentHyperlink From {tableName} Where WebSiteName = '{webSiteName}' and ComponentTitle Like '%25{componentCategory}%25{componentModel}%25{componentSeries}%25{key}%25'";
    }
}
