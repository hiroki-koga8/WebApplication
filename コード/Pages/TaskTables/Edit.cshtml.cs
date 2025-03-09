using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationTest.Pages.TaskTables;

/// <summary>
/// タスク編集画面のバックエンド側の処理をするクラス
/// </summary>
public class EditModel : PageModel
{
	private readonly ApplicationDbContext _applicationDbContext;

	/// <summary>
	/// タスク
	/// </summary>
	[BindProperty]
	public Database.Entities.Task Task { get; set; } = default!;

	/// <summary>
	/// タスクの状況を表すドロップダウンリストの配列
	/// </summary>
	public SelectList StatusLists { get; set; } = new SelectList(new string[] { "未対応", "対応中", "完了" });

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="applicationDbContext">DBコンテキスト</param>
	public EditModel(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	/// <summary>
	/// 画面表示時の処理
	/// </summary>
	/// <param name="Id">タスクID</param>
	public IActionResult OnGet(int? Id)
    {
		Task = _applicationDbContext.Tasks.FirstOrDefault(a => a.Id == Id)!;

		return Page();
	}

	/// <summary>
	/// 保存時の処理
	/// </summary>
	/// <param name="Id">タスクID</param>
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
	/// 削除時の処理
	/// </summary>
	/// <param name="Id">タスクID</param>
	public async Task<IActionResult> OnPostDelete(int? Id)
	{
		var targetTask = _applicationDbContext.Tasks.Find(Id);
		if (targetTask == null) return Page();

		_applicationDbContext.Remove(targetTask);
		await _applicationDbContext.SaveChangesAsync();

		return RedirectToPage("./Index");
	}
}
