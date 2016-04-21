using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CS_Component
{
	public class StringUtil
	{
        public StringUtil()
		{
		}

		private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider();
				provider1.ImportParameters(RSAKeyInfo);
				return provider1.Decrypt(DataToDecrypt, DoOAEPPadding);
			}
			catch (Exception exception1)
			{
				string text1 = exception1.ToString();
				return null;
			}
		}

		private byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
		{
			try
			{
				RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider();
				provider1.ImportParameters(RSAKeyInfo);
				return provider1.Encrypt(DataToEncrypt, DoOAEPPadding);
			}
			catch
			{
				return null;
			}
		}

		public string GetConnection(string path)
		{
			if (!File.Exists(path))
			{
				return null;
			}

			try
			{
				RSAParameters parameters1;
				RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider();
				UnicodeEncoding encoding1 = new UnicodeEncoding();
				FileStream stream1 = new FileStream(path, FileMode.Open, FileAccess.Read);
				StreamReader reader1 = new StreamReader(stream1);
				reader1.BaseStream.Seek((long) 0, SeekOrigin.Begin);
				byte[] buffer1 = new byte[0x80];
				int num1 = 0;
				byte[] buffer2 = new byte[0x80];
				num1 = 0;
				while (num1 < 0x80)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.D = buffer2;
				buffer2 = new byte[0x40];
				num1 = 0;
				while (num1 < 0x40)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.DP = buffer2;
				buffer2 = new byte[0x40];
				num1 = 0;
				while (num1 < 0x40)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.DQ = buffer2;
				buffer2 = new byte[3];
				num1 = 0;
				while (num1 < 3)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.Exponent = buffer2;
				buffer2 = new byte[0x40];
				num1 = 0;
				while (num1 < 0x40)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.InverseQ = buffer2;
				buffer2 = new byte[0x80];
				num1 = 0;
				while (num1 < 0x80)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.Modulus = buffer2;
				buffer2 = new byte[0x40];
				num1 = 0;
				while (num1 < 0x40)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.P = buffer2;
				buffer2 = new byte[0x40];
				num1 = 0;
				while (num1 < 0x40)
				{
					buffer2[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				parameters1.Q = buffer2;
				num1 = 0;
				while (num1 < 0x80)
				{
					buffer1[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
					num1++;
				}
				byte[] buffer3 = this.RSADecrypt(buffer1, parameters1, false);
				string text1 = encoding1.GetString(buffer3);
				for (num1 = 0; num1 < 0x80; num1++)
				{
					buffer1[num1] = byte.Parse(reader1.BaseStream.ReadByte().ToString());
				}
				buffer3 = this.RSADecrypt(buffer1, parameters1, false);
				stream1.Close();
				reader1.Close();
				return (text1 + encoding1.GetString(buffer3));
			}
			catch
			{
				return null;
			}
		}

		public bool MakeConnection(string ConEncrypt, string Path)
		{
		
			if (File.Exists(Path))
			{
				File.Delete(Path);
			}
			try
			{
				UnicodeEncoding encoding1 = new UnicodeEncoding();
				int num1 = ConEncrypt.Length / 2;
				string text1 = ConEncrypt.Substring(0, num1);
				string text2 = ConEncrypt.Substring(num1, ConEncrypt.Length - num1);
				byte[] buffer1 = encoding1.GetBytes(text1);
				RSACryptoServiceProvider provider1 = new RSACryptoServiceProvider();
				byte[] buffer2 = this.RSAEncrypt(buffer1, provider1.ExportParameters(false), false);
				if (buffer2 == null)
				{
					return false;
				}
				FileStream stream1 = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write);
				StreamWriter writer1 = new StreamWriter(stream1);
				writer1.BaseStream.Seek((long) 0, SeekOrigin.End);
				RSAParameters parameters1 = provider1.ExportParameters(true);
				byte[] buffer3 = parameters1.D;
				for (int num2 = 0; num2 < buffer3.Length; num2++)
				{
					writer1.BaseStream.WriteByte(buffer3[num2]);
				}
				RSAParameters parameters2 = provider1.ExportParameters(true);
				buffer3 = parameters2.DP;
				for (int num3 = 0; num3 < buffer3.Length; num3++)
				{
					writer1.BaseStream.WriteByte(buffer3[num3]);
				}
				RSAParameters parameters3 = provider1.ExportParameters(true);
				buffer3 = parameters3.DQ;
				for (int num4 = 0; num4 < buffer3.Length; num4++)
				{
					writer1.BaseStream.WriteByte(buffer3[num4]);
				}
				RSAParameters parameters4 = provider1.ExportParameters(true);
				buffer3 = parameters4.Exponent;
				for (int num5 = 0; num5 < buffer3.Length; num5++)
				{
					writer1.BaseStream.WriteByte(buffer3[num5]);
				}
				RSAParameters parameters5 = provider1.ExportParameters(true);
				buffer3 = parameters5.InverseQ;
				for (int num6 = 0; num6 < buffer3.Length; num6++)
				{
					writer1.BaseStream.WriteByte(buffer3[num6]);
				}
				RSAParameters parameters6 = provider1.ExportParameters(true);
				buffer3 = parameters6.Modulus;
				for (int num7 = 0; num7 < buffer3.Length; num7++)
				{
					writer1.BaseStream.WriteByte(buffer3[num7]);
				}
				RSAParameters parameters7 = provider1.ExportParameters(true);
				buffer3 = parameters7.P;
				for (int num8 = 0; num8 < buffer3.Length; num8++)
				{
					writer1.BaseStream.WriteByte(buffer3[num8]);
				}
				RSAParameters parameters8 = provider1.ExportParameters(true);
				buffer3 = parameters8.Q;
				for (int num9 = 0; num9 < buffer3.Length; num9++)
				{
					writer1.BaseStream.WriteByte(buffer3[num9]);
				}
				for (int num10 = 0; num10 < buffer2.Length; num10++)
				{
					writer1.BaseStream.WriteByte(buffer2[num10]);
				}
				buffer1 = encoding1.GetBytes(text2);
				buffer2 = this.RSAEncrypt(buffer1, provider1.ExportParameters(false), false);
				if (buffer2 == null)
				{
					return false;
				}
				ConEncrypt = encoding1.GetString(buffer2);
				for (int num11 = 0; num11 < buffer2.Length; num11++)
				{
					writer1.BaseStream.WriteByte(buffer2[num11]);
				}
				writer1.Flush();
				writer1.Close();
				stream1.Close();
				return true;
			}
			catch(Exception po)
			{
				MessageBox.Show(po.Message);
				return false;
			}
		}
	}
}
