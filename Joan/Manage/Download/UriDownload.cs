using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joan.Manage.Download
{
    public class UriDownload:Download
    {
        public IEnumerable<string> Uris { get; set; }
    }
}
