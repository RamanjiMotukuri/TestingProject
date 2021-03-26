using System;
using System.Collections.Generic;

namespace ClaimMembersProject
{

    public class MemberModel
    {

        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }

    public class ClaimInfoModel
    {
        public int MemberID { get; set; }
        public DateTime ClaimDate { get; set; }
        public decimal ClaimAmount { get; set; }
    }

    public class MemberClaimsModel
    {
        public int MemberID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<ClaimInfoModel> ClaimList{ get; set; }
    }





}
