using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.XIV
{
    public class XIVProcess
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

        public ProcessModule MainModule { get { return _module; } }

        public XIVProcess(Process proc)
        {
            _process = proc;
            _module = proc.MainModule;
           
        }

        public XIVProcess(int pid)
        {
            _process = Process.GetProcessById(pid);
            _module = _process.MainModule;
        }

        public override bool Equals(object obj)
        {
            if (obj is XIVProcess)
            {
                return ((obj as XIVProcess).Pid == this.Pid);
            }

            if(obj is Process)
            {
                return ((obj as Process).Id == this._process.Id);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static XIVProcess[] GetProcesses()
        {
            List<XIVProcess> procs = new List<XIVProcess>();
         
            foreach(Process p in Process.GetProcessesByName("ffxiv_dx11"))
            {
                procs.Add(new XIV.XIVProcess(p));
            }

            return procs.ToArray();
        }


        public static XIVProcess GetProcessById(int id)
        {
            return new XIVProcess(id);
        }

        public static implicit operator XIVProcess(int id)
        {
            return new XIVProcess(id);
        }

        public static implicit operator XIVProcess(Process p)
        {
            return new XIVProcess(p);
        }

        public static implicit operator Process(XIVProcess p)
        {
            return p._process;
        }

        public static bool operator ==(XIVProcess p1, Process p2)
        {
            return p1.Pid == p2.Id;
        }

        public static bool operator !=(XIVProcess p1, Process p2)
        {
            return p1.Pid != p2.Id;
        }

        public static bool operator ==(Process p2, XIVProcess p1 )
        {
            return p1.Pid == p2.Id;
        }

        public static bool operator !=(Process p2, XIVProcess p1)
        {
            return p1.Pid == p2.Id;
        }

    }

}
