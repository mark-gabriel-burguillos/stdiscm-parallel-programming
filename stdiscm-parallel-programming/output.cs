using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stdiscm_parallel_programming
{
    internal struct DataEntry
    {
        public string emailAddress;
        public string associatedName;
        public string office;
        public string department;

        public DataEntry(string emailAddress)
            : this(emailAddress, null, null, null)
        {
        }

        public DataEntry(string emailAddress,
            string associatedName,
            string office,
            string department)
        {
            this.emailAddress = emailAddress;
            this.associatedName = associatedName;
            this.office = office;
            this.department = department;
        }
    }
}
