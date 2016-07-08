using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace wConfig
{
    public class ENCDEC
    {
        private static Stream FileStream;

        private static BinaryReader ENC;
        private static BinaryWriter DEC;

        public static bool Encrypt(String Path, Object Obj)
        {
            try
            {
                FileStream = File.Create(Path);

                Byte[] pBuffer = GetObjectPtr(Obj);

                DEC = new BinaryWriter(FileStream);

                DEC.Write(pBuffer);

                DEC.Close();

                DEC = null;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Decrypt<T>(String Path, ref T Obj)
        {
            try
            {
                Int32 SIZE_OF = Marshal.SizeOf(typeof(T));

                if (SIZE_OF > 0)
                {
                    FileStream = File.Open(Path, FileMode.Open);

                    Byte[] pBuffer = new Byte[SIZE_OF];

                    ENC = new BinaryReader(FileStream);

                    pBuffer = ENC.ReadBytes(SIZE_OF);

                    GCHandle Handler = GCHandle.Alloc(pBuffer, GCHandleType.Pinned);

                    Obj = (T)Marshal.PtrToStructure(Handler.AddrOfPinnedObject(), typeof(T));

                    Handler.Free();

                    FileStream.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        private static byte[] GetObjectPtr(Object Obj)
        {
            try
            {
                Byte[] pBuffer = new Byte[Marshal.SizeOf(Obj)];

                GCHandle Handler = GCHandle.Alloc(pBuffer, GCHandleType.Pinned);

                Marshal.StructureToPtr(Obj, Handler.AddrOfPinnedObject(), true);

                Handler.Free();

                return pBuffer;
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);

                return null;
            }
        }
    }
}
