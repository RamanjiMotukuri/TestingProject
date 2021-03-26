using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClaimMembersProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembeClaimController : ControllerBase
    {
        private readonly CsvOperations csvOperation;
        public MembeClaimController()
        {
            csvOperation = new CsvOperations();
        }

        [HttpGet]
        [RouteAttribute("GetMemberDetails")]
        public IEnumerable<MemberModel> GetMemberDetails()
        {
            try
            {
                var membersList = csvOperation.GetMemberList();
                return membersList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
        [HttpGet]
        [RouteAttribute("GetMemberClaimDetails")]
        public IEnumerable<MemberClaimsModel> GetClaimDetailsByMember()
        {
            try
            {
                var membersList = csvOperation.GetMemberList();
                var claimList = csvOperation.GetClaimList();
                var memberClaimList = (from m in membersList
                                        select new MemberClaimsModel
                                        {
                                            MemberID = m.MemberID,
                                            FirstName=m.FirstName,
                                            LastName=m.LastName,
                                            ClaimList=(from c in claimList
                                                       where c.MemberID==m.MemberID
                                                       select new ClaimInfoModel()
                                                       {
                                                           ClaimAmount = c.ClaimAmount,
                                                           ClaimDate = c.ClaimDate
                                                       }).ToList()
                                        }).ToList();
                return memberClaimList;


            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }

}