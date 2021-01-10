﻿using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Зацикливание видео.
	/// </summary>
	public enum RepeatVideo
	{
		/// <summary>
		/// Не зацикливать.
		/// </summary>
		[DefaultValue]
		NotRepeat = 0,

		/// <summary>
		/// Зацикливать
		/// </summary>
		Repeat = 1
	}
}