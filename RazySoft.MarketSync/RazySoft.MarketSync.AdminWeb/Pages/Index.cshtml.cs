using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazySoft.MarketSync.AdminWeb.Services;
using RazySoft.MarketSync.AdminWeb.Services.Models;

namespace RazySoft.MarketSync.AdminWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ISyncApiTenant _tenant;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ISyncApiTenant tenant, ILogger<IndexModel> logger)
        {
            _tenant = tenant;
            _logger = logger;
        }

        public SyncStatus? Status { get; set; }
        public List<string>? LogLines { get; set; }
        public bool IsBusy { get; set; }

        public async Task OnGetAsync()
        {
            await LoadAsync();
        }

        public async Task<IActionResult> OnPostRefreshAsync()
        {
            await LoadAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostRunSyncAsync()
        {
            IsBusy = true;
            try
            {
                var ok = await _tenant.RunSyncAsync();
                if (!ok)
                {
                    TempData["Error"] = "Failed to call service. Check logs or service availability.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "RunSync failed");
                TempData["Error"] = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }

            await LoadAsync();
            return Page();
        }

        private async Task LoadAsync()
        {
            try
            {
                Status = await _tenant.GetStatusAsync();
                LogLines = await _tenant.GetLogsAsync() ?? new List<string>();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "LoadAsync failed");
                Status = null;
                LogLines = null;
            }
        }
    }
}
