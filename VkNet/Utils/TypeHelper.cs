using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using VkNet.Abstractions.Authorization;
using VkNet.Abstractions.Core;
using VkNet.Abstractions.Utils;
using VkNet.Enums;
using VkNet.Infrastructure;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using VkNet.Utils.AntiCaptcha;

namespace VkNet.Utils
{
	/// <summary>
	/// Методы расширения для типов
	/// </summary>
	public static class TypeHelper
	{
		/// <summary>
		/// DI регистрация зависимостей по умолчанию
		/// </summary>
		/// <param name="container"> DI контейнер </param>
		public static void RegisterDefaultDependencies(this IServiceCollection container)
		{
			container.TryAddSingleton<IBrowser, Browser>();
			container.TryAddSingleton<INeedValidationHandler, Browser>();
			container.TryAddSingleton(typeof(ILogger<>), typeof(NullLogger<>));
			container.TryAddSingleton<IRestClient, RestClient>();
			container.TryAddSingleton<IWebProxy>(t => null);
			container.TryAddSingleton<IVkApiVersionManager, VkApiVersionManager>();
			container.TryAddSingleton<ICaptchaHandler, CaptchaHandler>();
			container.TryAddSingleton<ILanguageService, LanguageService>();
			container.TryAddSingleton<ICaptchaSolver>(sp => null);
			container.TryAddSingleton<HttpClient>();
			container.TryAddSingleton<IRateLimiter, RateLimiter>();
			container.TryAddSingleton<IAwaitableConstraint, CountByIntervalAwaitableConstraint>();
			container.RegisterAuthorization();
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <typeparam name="T"> Тип ответа </typeparam>
		/// <returns> Результат выполнения функции. </returns>
		public static Task<T> TryInvokeMethodAsync<T>(Func<T> func)
		{
			var tcs = new TaskCompletionSource<T>();

			Task.Factory.StartNew(() =>
				{
					try
					{
						var result = func.Invoke();
						tcs.SetResult(result);
					}
					catch (OperationCanceledException)
					{
						tcs.SetCanceled();
					}
					catch (System.Exception ex)
					{
						tcs.SetException(ex);
					}
				})
				.ConfigureAwait(false);

			return tcs.Task;
		}

		/// <summary>
		/// Попытаться асинхронно выполнить метод.
		/// </summary>
		/// <param name="func"> Синхронный метод. </param>
		/// <returns> Результат выполнения функции. </returns>
		public static Task TryInvokeMethodAsync(Action func)
		{
			var tcs = new TaskCompletionSource<Task>();

			Task.Factory.StartNew(() =>
			{
				try
				{
					func.Invoke();
					tcs.SetResult(null);
				}
				catch (OperationCanceledException)
				{
					tcs.SetCanceled();
				}
				catch (System.Exception ex)
				{
					tcs.SetException(ex);
				}
			});

			return tcs.Task;
		}

		private static void RegisterAuthorization(this IServiceCollection services)
		{
			services.TryAddSingleton<IAuthorizationFlow, Browser>();
			services.TryAddSingleton<IVkAuthorization<ImplicitFlowPageType>, ImplicitFlowVkAuthorization>();
			services.TryAddSingleton<IAuthorizationFormHtmlParser, AuthorizationFormHtmlParser>();
			services.TryAddSingleton<DefaultHttpClientFactory, ProxyHttpClientFactory>();
			services.TryAddSingleton<IAuthorizationFormFactory, AuthorizationFormFactory>();
			services.TryAddSingleton<IAuthorizationForm, ImplicitFlowCaptchaLoginForm>();
			services.TryAddSingleton<IAuthorizationForm, ImplicitFlowLoginForm>();
			services.TryAddSingleton<IAuthorizationForm, TwoFactorForm>();
			services.TryAddSingleton<IAuthorizationForm, ConsentForm>();
		}
	}
}