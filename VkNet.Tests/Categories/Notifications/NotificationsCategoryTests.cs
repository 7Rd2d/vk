﻿using FluentAssertions;
using NUnit.Framework;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Notifications
{
	[TestFixture]

	public class NotificationsCategoryTests : CategoryBaseTest
	{
		[Test]
		public void MarkAsViewed()
		{
			Url = "https://api.vk.com/method/notifications.markAsViewed";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notifications.MarkAsViewed();

			result.Should().BeTrue();
		}

		protected override string Folder => "Notifications";
	}
}