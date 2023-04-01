using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Usb.Net.Windows;

namespace RigolUsb
{
    public class Program
    {
        // https://github.com/MelbourneDeveloper/Device.Net/blob/c0ab331b78b156cf3af91722661c35dae993e31e/src/Hid.Net/Windows/WindowsHidHandler.cs
        public static async Task Main(string[] args)
        {
            var factory = WindowsUsbDeviceFactoryExtensions.CreateWindowsUsbDeviceFactory(classGuid:new Guid("{a9fdbb24-128a-11d5-9961-00108335e361}"));
            var devices = await factory.GetConnectedDeviceDefinitionsAsync();
            var dev1 = await factory.GetDeviceAsync(devices.First());
            await dev1.InitializeAsync();
            var request = Encoding.ASCII.GetBytes("*IDN?\n");
            var result = await dev1.WriteAndReadAsync(request);
            var message = Encoding.ASCII.GetString(result.Data);
            Console.WriteLine(message);

            //dev1.WriteAndReadAsync()
        }
    }
}
