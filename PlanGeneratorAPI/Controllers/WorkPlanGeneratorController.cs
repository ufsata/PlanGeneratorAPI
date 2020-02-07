using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PlanGeneratorDto.WorkPlan;
using PlanGeneratorRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanGeneratorAPI.Controllers
{
    //[Route("api/[controller]")]
    //public class WorkPlanGeneratorController : Controller
    //{
    //    private readonly IWorkPlanGeneratorRepository _workPlanGeneratorRepository;

    //    public WorkPlanGeneratorController(IWorkPlanGeneratorRepository workPlanGeneratorRepository)
    //    {
    //        _workPlanGeneratorRepository = workPlanGeneratorRepository;
    //    }

    //    [HttpPost]
    //    public async Task<ActionResult<WorkPlanDto>> PostWorkPlan([FromBody] WorkPlanDto workPlanDto)
    //    {
    //        await _workPlanGeneratorRepository.GenerateWorkPlan();
            
    //    }
    //}
}
