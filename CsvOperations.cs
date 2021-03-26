using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimMembersProject
{
    public class CsvOperations
    {


        public List<MemberModel> GetMemberList()
        {
            // CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            using (var reader = new StreamReader(Path.Combine("CSVData/Member.Csv")))
            // CsvConfiguration sc = new CsvConfiguration();
            using (var csvReader = new CsvReader(reader))
            {
                var records = csvReader.GetRecords<MemberModel>();
                return records.ToList();
            }

        }

        public List<ClaimInfoModel> GetClaimList()
        {
            TextReader reader = new StreamReader(Path.Combine("CSVData/Claim.Csv"));
            using (var csvReader = new CsvReader(reader))
            {
                var records = csvReader.GetRecords<ClaimInfoModel>();
                return records.ToList();
            }
        }
    }
}

