using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTest.Pages.TaskTables;

/// <summary>
/// タスク一覧画面のバックエンド側の処理をするクラス
/// </summary>
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    /// <summary>
    /// 表示するタスクのリスト
    /// </summary>
    public List<Database.Entities.Task> Tasks { get; set; } = null!;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="applicationDbContext"></param>
    public IndexModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext; 
    }

    /// <summary>
    /// 初期表示時の処理
    /// </summary>
    public IActionResult OnGet()
    {
        Tasks = _applicationDbContext.Tasks.ToList();

        return Page();
    }
}
