using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Yoga.Client.Services
{
    public class HttpErrorInterceptor : DelegatingHandler
    {
        private readonly ToastService _toastService;

        public HttpErrorInterceptor(ToastService toastService)
        {
            _toastService = toastService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);
                
                if (!response.IsSuccessStatusCode)
                {
                    HandleErrorResponse(response.StatusCode);
                }

                return response;
            }
            catch (HttpRequestException)
            {
                _toastService.ShowError("Ошибка сети", "Не удалось подключиться к серверу. Проверьте интернет-соединение.");
                throw;
            }
        }

        private void HandleErrorResponse(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    _toastService.ShowWarning("Сессия истекла", "Пожалуйста, авторизуйтесь заново.");
                    break;
                case HttpStatusCode.Forbidden:
                    _toastService.ShowError("Отказано в доступе", "У вас нет прав для выполнения этой операции.");
                    break;
                case HttpStatusCode.NotFound:
                    // _toastService.ShowInfo("Не найдено", "Запрашиваемый ресурс не найден.");
                    break;
                case HttpStatusCode.InternalServerError:
                    _toastService.ShowError("Ошибка сервера", "Произошла внутренняя ошибка сервера. Повторите попытку позже.");
                    break;
                case HttpStatusCode.BadRequest:
                    _toastService.ShowWarning("Ошибка в данных", "Проверьте правильность введенных данных.");
                    break;
                default:
                    _toastService.ShowError("Ошибка", $"Произошла ошибка ({statusCode}).");
                    break;
            }
        }
    }
}