﻿using FluentAssertions;
using NUnit.Framework;
using VkNet.Model.RequestParams.Notes;
using VkNet.Tests.Infrastructure;

namespace VkNet.Tests.Categories.Notes
{
	[TestFixture]

	public class NotesCategoryTests : CategoryBaseTest
	{
		protected override string Folder => "Notes";

		[Test]
		public void Add()
		{
			Url = "https://api.vk.com/method/notes.add";
			ReadCategoryJsonPath(nameof(Add));

			var result = Api.Notes.Add(new NotesAddParams());

			result.Should().Be(11825220);
		}

		[Test]
		public void CreateComment()
		{
			Url = "https://api.vk.com/method/notes.createComment";
			ReadCategoryJsonPath(nameof(CreateComment));

			var result = Api.Notes.CreateComment(new NotesCreateCommentParams());

			result.Should().Be(11825220);
		}

		[Test]
		public void Delete()
		{
			Url = "https://api.vk.com/method/notes.delete";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.Delete(11825220);

			result.Should().BeTrue();
		}

		[Test]
		public void DeleteComment()
		{
			Url = "https://api.vk.com/method/notes.deleteComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.DeleteComment(new NotesDeleteCommentParams());

			result.Should().BeTrue();
		}

		[Test]
		public void Edit()
		{
			Url = "https://api.vk.com/method/notes.edit";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.Edit(new NotesEditParams());

			result.Should().BeTrue();
		}

		[Test]
		public void EditComment()
		{
			Url = "https://api.vk.com/method/notes.editComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.EditComment(new NotesEditCommentParams());

			result.Should().BeTrue();
		}

		[Test]
		public void Get()
		{
			Url = "https://api.vk.com/method/notes.get";
			ReadCategoryJsonPath(nameof(Get));

			var result = Api.Notes.Get(new NotesGetParams());

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void GetById()
		{
			Url = "https://api.vk.com/method/notes.getById";
			ReadCategoryJsonPath(nameof(GetById));

			var result = Api.Notes.GetById(new NotesGetByIdParams());

			result.Should().NotBeNull();
		}

		[Test]
		public void GetComments()
		{
			Url = "https://api.vk.com/method/notes.getComments";
			ReadCategoryJsonPath(nameof(GetComments));

			var result = Api.Notes.GetComments(new NotesGetCommentParams());

			Assert.IsNotEmpty(result);
		}

		[Test]
		public void RestoreComment()
		{
			Url = "https://api.vk.com/method/notes.restoreComment";
			ReadJsonFile(JsonPaths.True);

			var result = Api.Notes.RestoreComment(new NotesRestoreCommentParams());

			result.Should().BeTrue();
		}
	}
}