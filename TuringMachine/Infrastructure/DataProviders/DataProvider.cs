using System;
using System.Collections.Generic;
using TuringMachine.Models;
using System.Data;

namespace TuringMachine.Infrastructure.DataProviders
{
    internal class DataProvider : IDataProvider
    {
        public Rules GetRules(string alphabet)
        {
            Rules rules = new();

            rules.DataTable.Columns.Add(new DataColumn("A\\S"));
            for (int i = 1; i < 8; ++i)
            {
                rules.DataTable.Columns.Add(new DataColumn($"Q{i}"));
            }
            foreach (var letter in alphabet)
            {
                rules.DataTable.Rows.Add(rules.DataTable.NewRow().ItemArray = new object[] { letter });
            }
            return rules;
        }

        public Rules GetRules()
        {
            Rules rules = new();
            rules.DataTable = new();

            rules.DataTable.Columns.Add(new DataColumn("A\\S"));
            for (int i = 1; i < 8; ++i)
            {
                rules.DataTable.Columns.Add(new DataColumn($"Q{i}"));
            }

            rules.DataTable.Rows.Add(rules.DataTable.NewRow().ItemArray = new object[] { "\u03BB", "", "\u03BB\u21925", "\u03BB\u21925", "\u03BB\u21925", "\u03BB\u21907", "\u03BB!0", "a\u21906" });
            rules.DataTable.Rows.Add(rules.DataTable.NewRow().ItemArray = new object[] { "a", "a\u21902", "a\u21903", "a\u21904", "a\u21906", "\u03BB\u21925", "a\u21906" });
            rules.DataTable.Rows.Add(rules.DataTable.NewRow().ItemArray = new object[] { "b", "b\u21902", "b\u21903", "b\u21904", "b\u21906", "\u03BB\u21925", "b\u21906" });

            return rules;
        }

        public Rules SetRules(DataTable dataTable)
        {
            return new Rules(dataTable);
        }

        public Dictionary<KeyValuePair<char, int>, string> TranslateForTuringMachine(DataTable rulesTb)
        {
            Dictionary<KeyValuePair<char, int>, string> configuration = new();

            int numberOfColumns = rulesTb.Columns.Count;
            foreach (DataRow row in rulesTb.Rows)
            {
                for (int i = 1; i < numberOfColumns; ++i)
                {
                    configuration.Add(new KeyValuePair<char, int>(Convert.ToChar(row[0]), i), row[i].ToString());
                }
            }



            return configuration;
        }
    }
}