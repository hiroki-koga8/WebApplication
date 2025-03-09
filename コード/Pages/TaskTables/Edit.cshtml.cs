using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationTest.Pages.TaskTables;

/// <summary>
/// �^�X�N�ҏW��ʂ̃o�b�N�G���h���̏���������N���X
/// </summary>
public class EditModel : PageModel
{
	private readonly ApplicationDbContext _applicationDbContext;

	/// <summary>
	/// �^�X�N
	/// </summary>
	[BindProperty]
	public Database.Entities.Task Task { get; set; } = default!;

	/// <summary>
	/// �^�X�N�̏󋵂�\���h���b�v�_�E�����X�g�̔z��
	/// </summary>
	public SelectList StatusLists { get; set; } = new SelectList(new string[] { "���Ή�", "�Ή���", "����" });

	/// <summary>
	/// �R���X�g���N�^
	/// </summary>
	/// <param name="applicationDbContext">DB�R���e�L�X�g</param>
	public EditModel(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	/// <summary>
	/// ��ʕ\�����̏���
	/// </summary>
	/// <param name="Id">�^�X�NID</param>
	public IActionResult OnGet(int? Id)
    {
		Task = _applicationDbContext.Tasks.FirstOrDefault(a => a.Id == Id)!;

		return Page();
	}

	/// <summary>
	/// �ۑ����̏���
	/// </summary>
	/// <param name="Id">�^�X�NID</param>
	public async Task<IActionResult> OnPostAsync(int? Id)
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}
		var targetTask = _applicationDbContext.Tasks.Find(Id);

		targetTask!.Name = Task.Name;
		targetTask!.StartDate = Task.StartDate;
		targetTask!.EndDate = Task.EndDate;
		targetTask!.Contents = Task.Contents;
		targetTask!.Status = Task.Status;
		targetTask!.PlanManHour = Task.PlanManHour;
		targetTask!.ResultManHour = Task.ResultManHour;
		targetTask!.Deviation = Task.Deviation;
		targetTask!.Note = Task.Note;

		await _applicationDbContext.SaveChangesAsync();

		return RedirectToPage("./Index");
	}

	/// <summary>
	/// �폜���̏���
	/// </summary>
	/// <param name="Id">�^�X�NID</param>
	public async Task<IActionResult> OnPostDelete(int? Id)
	{
		var targetTask = _applicationDbContext.Tasks.Find(Id);
		if (targetTask == null) return Page();

		_applicationDbContext.Remove(targetTask);
		await _applicationDbContext.SaveChangesAsync();

		return RedirectToPage("./Index");
	}
}
