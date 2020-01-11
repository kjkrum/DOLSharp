using System;

namespace DOL.Network
{
	public static class PacketExtensions
	{
		private static string Format(DateTime timestamp, byte code, int size)
		{
			return string.Format("[{0}] code={1}, size={2}", timestamp, code, size);
		}
	}
}
