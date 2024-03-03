using Microsoft.AspNetCore.Mvc.Filters;

namespace WebClient2.BackGroundServices
{
    public class SemaphoreActionFilter: IAsyncActionFilter
    {
        private static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                await next.Invoke();
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }
    }
}
