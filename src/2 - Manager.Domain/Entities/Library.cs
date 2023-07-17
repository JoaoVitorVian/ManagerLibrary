using System;
using System.Collections.Generic;
using Manager.Domain.Validators;
using Manager.Core.Exceptions;

namespace Manager.Domain.Entities
{
    public class Library : Base
    {
        //private set para deixar a entidade fechada, é possivel mudar a entidade através de metodos
        //para deixar a entidade protegida a erros de insercao.
        public string NameBook { get; set; }

        public long CodeSerial { get; set; }

        public bool BkExists { get; set; }

        protected Library() { }

        public Library(string nameBook, long codeSerial, bool bkExists)
        {
            NameBook = nameBook;
            CodeSerial = codeSerial;
            BkExists = bkExists;
            _errors = new List<string>();
        }


        public override bool Validate()
        {
            var validator = new LibraryValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estão invalidos, corrija-os", _errors);
            }
            return true;
        }
    }
}