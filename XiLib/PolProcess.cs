using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FFXi
{
    public class PolProcess
    {
        private Process _process;
        private IntPtr _baseAddress;
        private int _moduleSize;
        private ProcessModule _module;

        public IntPtr Handle { get { return _process.Handle; } }
        public int ModuleSize { get { return _moduleSize; } }
        public IntPtr hWnd { get { return _process.MainWindowHandle; } }
        public IntPtr BaseAddress { get { return _baseAddress; } }
        public string Title { get { return _process.MainWindowTitle; } }
        public Process Process { get { return _process; } }
        public int Pid { get { return _process.Id; } }

        public ProcessModule FFXiMain { get { return _module; } }

        public PolProcess(Process proc)
        {
            _process = proc;
            foreach (ProcessModule m in proc.Modules)
            {
                if (m.ModuleName.ToLower() == "ffximain.dll")
                {
                    _baseAddress = m.BaseAddress;
                    _moduleSize = m.ModuleMemorySize;
                    _module = m;
                    break;
                }
            }
        }

        public PolProcess(int pid)
        {
            _process = Process.GetProcessById(pid);

            foreach (ProcessModule m in _process.Modules)
            {
                if (m.ModuleName.ToLower() == "ffximain.dll")
                {
                    _baseAddress = m.BaseAddress;
                    _moduleSize = m.ModuleMemorySize;
                    _module = m;
                    break;
                }
            }
        }
    }
}
