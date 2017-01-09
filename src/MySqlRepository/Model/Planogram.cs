using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlRepository.Models
{
    public class Planogram
    {
        public int StoreNbr { get; set; }
        public int UPCNbr { get; set; }
        public int DeptNbr { get; set; }
        public int PlanogramId { get; set; }
        public int ModularPlanId { get; set; }
        public string CategoryNbr { get; set; }
        public string CategoryName { get; set; }
        public string PlanogramDesc { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime DiscontinueDate { get; set; }
        public string Width { get; set; }
    }
}
