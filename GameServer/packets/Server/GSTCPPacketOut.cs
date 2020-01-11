/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */
using DOL.Network;
using System;

namespace DOL.GS.PacketHandler
{
	/// <summary>
	/// An outgoing TCP packet
	/// </summary>
	public class GSTCPPacketOut : PacketOut
	{
		private byte m_packetCode;
		
		/// <summary>
		/// This Packet Byte Handling Code
		/// </summary>
		public byte PacketCode {
			get { return m_packetCode; }
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="packetCode">ID of the packet</param>
		public GSTCPPacketOut(byte packetCode)
		{
			m_packetCode = packetCode;
			base.WriteShort(0x00); //reserved for size
			base.WriteByte(packetCode);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="packetCode">ID of the packet</param>
		public GSTCPPacketOut(byte packetCode, int startingSize) : base(startingSize + 3)
		{
			m_packetCode = packetCode;
			base.WriteShort(0x00); //reserved for size
			base.WriteByte(packetCode);
		}

		/// <summary>
		/// Info about the packet
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			//return
			//	string.Format("GSTCPPacketOut: Size={0} ID=0x{1:X2}",
			//				  this.Length, m_packetCode);
			return string.Format("[{0}] <<< TCP 0x{1:X2} {2} ({3} bytes)", DateTime.Now.ToString("HH:mm:ss.fff"), m_packetCode, Enum.GetName(typeof(eServerPackets), m_packetCode), this.Length);
		}
	}
}