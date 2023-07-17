using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagerAPI.ViewModels
{
    public class GetByIdBooksViewModel
    { 
        public long Id { get; set; }
        
        public string NameBook { get; set; }

        public long CodeSerial { get; set; }

        public bool BkExists { get; set; }
    }
}