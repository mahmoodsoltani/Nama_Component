using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Component
{
    public abstract class BaseNamaComponents 
    {
        private bool bol_IsRequired=false;

        private string str_FieldName;

        public bool IsRequired
        {
            get { return bol_IsRequired; }
            set { bol_IsRequired = true; }
        }

        public string FieldName
        {
            get { return str_FieldName; }
            set { str_FieldName = value; }
        }

        public virtual void Clear()
        { 

        }
    }
}
