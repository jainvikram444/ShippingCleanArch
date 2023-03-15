﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShippingCleanArch.Core.ProjectAggregate;
using ShippingCleanArch.Core.ProjectAggregate.Specifications;
using ShippingCleanArch.SharedKernel.Interfaces;

namespace ShippingCleanArch.Web.Pages.ProjectDetails;
public class IncompleteModel : PageModel
{
  private readonly IRepository<Project> _repository;

  [BindProperty(SupportsGet = true)]
  public int ProjectId { get; set; }

  public List<ToDoItem>? ToDoItems { get; set; }

  public IncompleteModel(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return;
    }

    var spec = new IncompleteItemsSpec();

    ToDoItems = spec.Evaluate(project.Items).ToList();
  }
}
