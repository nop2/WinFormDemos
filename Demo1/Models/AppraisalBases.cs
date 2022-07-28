using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1.Utils;

namespace Demo1.Models
{
    public class AppraisalBases
    {
        public int Id { get; set; }
        public string? BaseType { get; set; }
        public int AppraisalBase { get; set; }
        public bool IsDel { get; set; }

        public static List<AppraisalBases> ListAll()
        {
            // var dataTable = SqlHelper.ExecuteTable("select * from AppraisalBases;");
            // return (from DataRow dataTableRow in dataTable.Rows 
            //         select ToModel(dataTableRow))
            //     .ToList();
            return new List<AppraisalBases>
            {
                new() { Id = 1, AppraisalBase = 1, BaseType = "类型1", IsDel = false },
                new() { Id = 2, AppraisalBase = 1, BaseType = "类型2", IsDel = false },
                new() { Id = 3, AppraisalBase = 1, BaseType = "类型3", IsDel = false },
                new() { Id = 4, AppraisalBase = 1, BaseType = "类型4", IsDel = false },
            };
        }

        private static AppraisalBases ToModel(DataRow row)
        {
            return new AppraisalBases
            {
                Id = (int)row["Id"],
                BaseType = row["BaseType"].ToString(),
                AppraisalBase = (int)row["AppraisalBase"],
                IsDel = (bool)row["IsDel"],
            };
        }
    }
}