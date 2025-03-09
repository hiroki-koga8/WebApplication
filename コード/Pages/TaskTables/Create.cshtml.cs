using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplicationTest.Pages.TaskTables;
/// <summary>
/// タスク登録画面のバックエンド側の処理をするクラス
/// </summary>
public class CreateModel : PageModel
{
	private readonly ApplicationDbContext _applicationDbContext;

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
	public CreateModel(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}


	/// <summary>
	/// 初期表示時の処理
	/// </summary>
	public IActionResult OnGet()
	{
		return Page();
	}

	/// <summary>
	/// 登録ボタン押下時の処理
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
