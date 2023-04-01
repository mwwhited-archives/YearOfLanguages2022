using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace RigolDevices
{
    public  unsafe class Program
    {
        public static void Main(string[] args)
        {
            NativeMethods.EnumerateDeviceInterfaces(NativeMethods.GuidForTestAndMeasurement,
                (deviceInfoSet, deviceInfoData, deviceInterfaceData, deviceID, devicePath) =>
                {
                    Console.WriteLine($"{deviceID}: {devicePath}");

                    NativeMethods.TryOpenToGetInfo(devicePath, _ptr =>
                    {
                        byte* memBytePtr = (byte*)_ptr.ToPointer();

                        //var ums = new UnmanagedMemoryStream(memBytePtr,0,);

                        NativeMethods.HIDD_ATTRIBUTES attributes = new NativeMethods.HIDD_ATTRIBUTES();
                        attributes.Size = Marshal.SizeOf(attributes);
                        if (NativeMethods.HidD_GetAttributes(_ptr, ref attributes))
                        {
                            Console.WriteLine($"==> { attributes.VendorID}:>{ attributes.ProductID} ({ attributes.VersionNumber})");
                        }
                        else
                        {

                        }
                        return true;
                    });

                });


            //return d.TryOpenToGetInfo(handle =>
            //{
            //    NativeMethods.HIDD_ATTRIBUTES attributes = new NativeMethods.HIDD_ATTRIBUTES();
            //    attributes.Size = Marshal.SizeOf(attributes);
            //    if (!NativeMethods.HidD_GetAttributes(handle, ref attributes)) { return false; }

            //    // Get VID, PID, version.
            //    d._pid = attributes.ProductID;
            //    d._vid = attributes.VendorID;
            //    d._version = attributes.VersionNumber;
            //    return true;
            //}) ? d : null;



            Console.WriteLine("Hello Classic Template!");
        }


        //private static object[] GetHidDeviceKeys()
        //{
        //    object notifyObject;
        //    lock (_notifyThread)
        //    {
        //        notifyObject = _hidNotifyObject;
        //        if (notifyObject == _hidDeviceKeysCacheNotifyObject) { return _hidDeviceKeysCache; }
        //    }

        //    var paths = new List<object>();

        //    NativeMethods.EnumerateDeviceInterfaces(NativeMethods.GuidForTestAndMeasurement, (_, __, ___, deviceID, devicePath) =>
        //    {
        //        paths.Add(new HidDevicePath()
        //        {
        //            DeviceID = deviceID,
        //            DevicePath = devicePath
        //        });
        //    });

        //    var keys = paths.ToArray();
        //    lock (_notifyThread)
        //    {
        //        _hidDeviceKeysCacheNotifyObject = notifyObject;
        //        _hidDeviceKeysCache = keys;
        //    }
        //    return keys;
        //}
    }
}
