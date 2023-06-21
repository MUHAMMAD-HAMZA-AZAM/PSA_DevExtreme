using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Wrappers
{
    public class PagingParams
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public string? TextToSearch { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}
