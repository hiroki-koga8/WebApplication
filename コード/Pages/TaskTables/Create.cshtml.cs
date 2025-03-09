using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationTest.Pages.TaskTables;
/// <summary>
/// �^�X�N�o�^��ʂ̃o�b�N�G���h���̏���������N���X
/// </summary>
public class CreateModel : PageModel
{
	private readonly ApplicationDbContext _applicationDbContext;

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
	public CreateModel(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}


	/// <summary>
	/// �����\�����̏���
	/// </summary>
	public IActionResult OnGet()
	{
		return Page();
	}

	/// <summary>
	/// �o�^�{�^���������̏���
	/// </summary>
	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			return Page();
		}

		_applicationDbContext.Tasks.Add(Task);
		await _applicationDbContext.SaveChangesAsync();

		return RedirectToPage("./Index");
	}
}
