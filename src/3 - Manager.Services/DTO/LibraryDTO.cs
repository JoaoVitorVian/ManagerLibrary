using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  Manager.Services.DTO
{
    public class LibraryDTO
    {
        public long Id { get; set; }
        
        public string NameBook { get; set; }

        public long CodeSerial { get; set; }

        public bool BkExists { get; set; }

        public LibraryDTO(string nameBook, long codeSerial, bool bkExists)
        {
            NameBook = nameBook;
            CodeSerial = codeSerial;
            BkExists = bkExists;
        }
    }
}