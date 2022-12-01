using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stdiscm_parallel_programming
{
    /*
     * This struct is used to hold a single
     * entry within the output text file.
     */
    public struct DataEntry
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

    internal class Output
    {
        // Output variables
        const string OUTPUT_TEXT = "data.txt";
        const string STATISTICS_TEXT = "statistics.txt";

        private static uint numberOfPagesScraped = 0;

        private static List<DataEntry> entries = new List<DataEntry>();

        public static void OutputDataFile()
        {
            string outputText = "";

            foreach (DataEntry dataEntry in Entries)
            {
                outputText += dataEntry.emailAddress
                    + ","
                    + dataEntry.associatedName
                    + ","
                    + dataEntry.office
                    + ","
                    + dataEntry.department
                    + "\n";
            }

            File.WriteAllText(OUTPUT_TEXT, outputText);
        }

        public static void OutputStatisticsFile()
        {
            File.WriteAllText(STATISTICS_TEXT, "URL : "
                + Source.URL
                + "\nNumber of pages scraped : "
                + NumberOfPagesScraped
                + "\nNumber of email addresses found : "
                + NumberOfEmailAddressesFound);
        }

        public static void AddEntry(DataEntry newData)
        {
            entries.Add(newData);
        }

        public static List<DataEntry> Entries
        {
            get
            {
                return new List<DataEntry>(entries);
            }
        }

        public static uint NumberOfPagesScraped
        {
            get { return numberOfPagesScraped; }
        }

        /*
         * Note: The implementation of this property
         * relies on the number of dataEntries
         * within entry List.
         */
        public static uint NumberOfEmailAddressesFound
        {
            get { return (uint)Entries.Count; }
        }
    }
}
