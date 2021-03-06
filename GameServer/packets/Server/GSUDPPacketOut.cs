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
	/// Outgoing game server UDP packet
	/// </summary>
	public class GSUDPPacketOut : PacketOut
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
		public GSUDPPacketOut(byte packetCode) : base()
		{
			m_packetCode = packetCode;
			base.WriteShort(0x00); //reserved for size
			base.WriteShort(0x00); //reserved for UDP counter
			base.WriteByte(packetCode);
		}

		/// <summary>
		/// Calculates the packet size and prepends it
		/// </summary>
		/// <returns>The packet size</returns>
		public override ushort WritePacketLength()
		{
			Position = 0;
			WriteShort((ushort)(Length-5));

			//IMPORTANT!!!
			//Set the capacity of the internal buffer or
			//the byte-array of GetBuffer will be TOO big!
			Capacity = (int)Length;

			return (ushort)(Length-5);
		}

		/// <summary>
		/// Info about the packet
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			//return
			//	string.Format("GSUDPPacketOut: Size={0} ID=0x{1:X2}",
			//				  this.Length, m_packetCode);
			return string.Format("[{0}] <<< UDP 0x{1:X2} {2} ({3} bytes)", DateTime.Now.ToString("HH:mm:ss.fff"), m_packetCode, Enum.GetName(typeof(eServerPackets), m_packetCode), this.Length);
		}
	}
}