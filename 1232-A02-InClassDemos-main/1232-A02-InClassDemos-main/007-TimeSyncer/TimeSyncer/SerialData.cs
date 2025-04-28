using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TimeSyncer
{
    internal static class SerialData
    {
        public static byte[] Serialize<T>(T value)
        {
            var size = Marshal.SizeOf(value);
            var byteArray = new byte[size];

            var ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(value, ptr, false);
                Marshal.Copy(ptr, byteArray, 0, size);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(ptr);
                }
            }

            return byteArray;
        }


        public static T Deserialize<T>(byte[] data)
        {
            var packet = new GCHandle();
            T result;

            try
            {
                packet = GCHandle.Alloc(data, GCHandleType.Pinned);
                result = (T)Marshal.PtrToStructure(packet.AddrOfPinnedObject(), typeof(T));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                packet.Free();
            }

            return result;
        }
    }
}
