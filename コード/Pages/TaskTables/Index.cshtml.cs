using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTest.Pages.TaskTables;

/// <summary>
/// �^�X�N�ꗗ��ʂ̃o�b�N�G���h���̏���������N���X
/// </summary>
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _applicationDbContext;

    /// <summary>
    /// �\������^�X�N�̃��X�g
    /// </summary>
    public List<Database.Entities.Task> Tasks { get; set; } = null!;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    /// <param name="applicationDbContext"></param>
    public IndexModel(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext; 
    }

    /// <summary>
    /// �����\�����̏���
    /// </summary>
    public IActionResult OnGet()
    {
        Tasks = _applicationDbContext.Tasks.ToList();

        return Page();
    }
}
