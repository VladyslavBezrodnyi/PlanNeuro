using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlanNeuro.BLL.Interfaces
{
    public interface IPlanningService
    {
        Task Plan(int cardListId);
    }
}
