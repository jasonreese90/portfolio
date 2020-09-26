// -----------------------------------------------------------------------
// <copyright file="LuaScript.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Fischer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LuaInterface;
    using System.Reflection;
    using System.Threading;
    using Kunihiro.FFXi;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class LuaScript : FFXiScript
    {
        private XiLib ffxi;
        private Fischer fischer;

        public LuaScript(XiLib ffxi, Fischer fischer) : base(ffxi)
        {
            this.ffxi = ffxi;
            this.fischer = fischer;

            //try
            //{
            //    RegisterFunctions();
            //}
            //catch (Exception ex)
            //{
            //    ErrorLog.OnError(ex);
            //}
        }

        public delegate void OnStartDelegate();
        public delegate void OnStopDelegate();
        public delegate void OnFullInvDelegate();
        public delegate void OnNewChatLineDelegate(string text);
        public delegate void OnZoneChangeDelegate(int id);
        public delegate void OnNoRodDelegate();
        public delegate void OnNoBaitDelegate();

       
        public virtual void OnStart()
        {
            OnStartDelegate del = (OnStartDelegate)Lua.GetFunction(typeof(OnStartDelegate), "OnStart");
            if (del != null)
                del();
        }

        public virtual void OnStop()
        {
            OnStopDelegate del = (OnStopDelegate)Lua.GetFunction(typeof(OnStopDelegate), "OnStop");
            if (del != null)
                del();
        }

        public void OnFullInventory()
        {
            OnFullInvDelegate del = (OnFullInvDelegate)Lua.GetFunction(typeof(OnFullInvDelegate), "OnFullInventory");
            if(del != null)
                del();
        }

        public void OnNewChatLine(string text)
        {
            OnNewChatLineDelegate del = (OnNewChatLineDelegate)Lua.GetFunction(typeof(OnNewChatLineDelegate), "OnNewChatLine");

            if (del != null)
                del(text);
        }

        public void OnZoneChange(int id)
        {
            OnZoneChangeDelegate del = (OnZoneChangeDelegate)Lua.GetFunction(typeof(OnZoneChangeDelegate), "OnZoneChange");
            if (del != null)
                del(id);
        }

        public void OnNoRod()
        {
            OnNoRodDelegate del = (OnNoRodDelegate)Lua.GetFunction(typeof(OnNoRodDelegate), "OnNoRod");
            if (del != null)
                del();
        }

        public void OnNoBait()
        {
            OnNoBaitDelegate del = (OnNoBaitDelegate)Lua.GetFunction(typeof(OnNoBaitDelegate), "OnNoBait");
            if (del != null)
                del();
        }

        [LuaMethod]
        private void start()
        {
            try
            {
                fischer.Start();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        [LuaMethod]
        private void pause()
        {
            try
            {
                fischer.Pause = true;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        [LuaMethod]
        private void resume()
        {
            try
            {
                fischer.Pause = false;
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        [LuaMethod]
        private void stop()
        {
            try
            {
                fischer.Stop();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }

        //[LuaMethod]
        //private void stop(string message)
        //{
        //    try
        //    {
        //        fischer.Stop(message);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLog.OnError(ex);
        //    }
        //}

        [LuaMethod]
        private void sleep(int ms)
        {
            try
            {
                Thread.Sleep(ms);
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }
    }
}
