using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColabManager360.Domain.Entities.Business.Requests
{
    public class WorkInfoRequest
    {

        public virtual string UserId { get; set; }
        public string Position { get; set; }
        public  int WorkAreaTeamId { get; set; }
        public  int WorkAreaId { get; set; }
    

    }
}
