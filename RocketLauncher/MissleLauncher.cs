using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Storage;
using Windows.UI.Core;

namespace RocketLauncher
{
    public class MissleLauncher
    {
        private static readonly byte[] CMD = {0, 0, 0, 0, 0, 0, 0, 0, 2};

        private static readonly byte[] Up = {0, 2, 2, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] DOWN = {0, 2, 1, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] LEFT = {0, 2, 4, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] RIGHT = {0, 2, 8, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] FIRE = {0, 2, 16, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] Stop = {0, 2, 32, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] GetStatus = {0, 1, 0, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] LedOn = {0, 3, 1, 0, 0, 0, 0, 0, 0};

        private static readonly byte[] LedOff = {0, 3, 0, 0, 0, 0, 0, 0, 0};

        private const int delay = 1000;

        private const ushort vid = 8483;
        private const ushort pid = 4112;
        private const ushort uid = 16;
        private const ushort uPage = 1;

        private MissleLauncher(HidDevice hidDevice)
        {
            _hidDevice = hidDevice;
        }

        public async Task Fire()
        {
            await SendOutputMessage(FIRE);
        }

        public async Task TurnLedOn()
        {
            await SendOutputMessage(LedOn);
        }

        public async Task TurnLedOff()
        {
            await SendOutputMessage(LedOff);
        }

        public async Task MoveUp()
        {
            await SendOutputMessage(Up);
            await Task.Delay(delay);
            await SendOutputMessage(Stop);
        }

        public async Task MoveDown()
        {
            await SendOutputMessage(DOWN);
            await Task.Delay(delay);
            await SendOutputMessage(Stop);
        }

        public async Task MoveLeft()
        {
            await SendOutputMessage(LEFT);
            await Task.Delay(delay);
            await SendOutputMessage(Stop);
        }

        public async Task MoveRight()
        {
            await SendOutputMessage(RIGHT);
            await Task.Delay(delay);
            await SendOutputMessage(Stop);
        }

        private async Task SendOutputMessage(byte[] message)
        {
            if (_hidDevice != null)
            {
                HidOutputReport report = _hidDevice.CreateOutputReport();
                report.Data = message.AsBuffer();

                await _hidDevice.SendOutputReportAsync(report);
            }
        }


        public static EventHandler<MissleLauncherEventArgs> MissleLauncherFound;
        private readonly HidDevice _hidDevice;

        public static void SearchForMissleLauncher(CoreDispatcher dispatcher)
        {
            DeviceWatcher deviceWatcher =
                DeviceInformation.CreateWatcher(HidDevice.GetDeviceSelector(uPage, uid, vid, pid));
            deviceWatcher.Added += (s, a) => dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                HidDevice hidDevice = await HidDevice.FromIdAsync(a.Id, FileAccessMode.ReadWrite);
                var launcher = new MissleLauncher(hidDevice);
                if (MissleLauncherFound != null)
                    MissleLauncherFound(null, new MissleLauncherEventArgs(launcher));

                deviceWatcher.Stop();
            });
            deviceWatcher.Start();
        }

        public void Dispose()
        {
            _hidDevice.Dispose();
        }

        ~MissleLauncher()
        {
            Dispose();
        }
    }
}
