// -----------------------------------------------------------------------
// <copyright file="FFXiScript.cs" company="Microsoft">
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

    using System.IO;
    using System.Windows.Forms;
    using Kunihiro.FFXi;
    using Windower;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FFXiScript
    {
        private Lua lua;
        private XiLib ffxi;
        private bool loaded = false;

        public FFXiScript(XiLib ffxi)
        {
            try
            {
                lua = new Lua();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }

            this.ffxi = ffxi;

            try
            {
                RegisterFunctions();
            }
            catch (Exception ex)
            {
                ErrorLog.OnError(ex);
            }
        }
        
        protected Lua Lua
        {
            get { return lua; }
        }

        public bool Loaded
        {
            get { return loaded; }
        }

        protected void RegisterFunction(string name)
        {
            Type This = this.GetType();
            MethodInfo mi = This.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance);
            lua.RegisterFunction(name, this, mi);
        }

        public void Load(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    lua.DoFile(file);
                    loaded = true;
                }
                catch(LuaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       
        private void RegisterFunctions()
        {
            Type t = this.GetType();

            foreach (MethodInfo mi in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (Attribute.IsDefined(mi, typeof(LuaMethodAttribute)))
                {
                    RegisterFunction(mi.Name);
                }
            }
           
        }

        [LuaMethod]
        protected void test()
        {
            MessageBox.Show("test");
        }

        [LuaMethod]
        protected int getCurrentInv()
        {
            return ffxi.Inventory.GetBagCount(Bag.Inventory);
        }

        [LuaMethod]
        protected int getCurrentSatchel()
        {
            return ffxi.Inventory.GetBagCount(Bag.Satchel);
        }

        [LuaMethod]
        protected int getCurrentSack()
        {
            return ffxi.Inventory.GetBagCount(Bag.Sack);
        }

        [LuaMethod]
        protected int getCurrentSafe()
        {
            return ffxi.Inventory.GetBagCount(Bag.Safe);
        }

        [LuaMethod]
        protected int getCurrentLocker()
        {
            return ffxi.Inventory.GetBagCount(Bag.Locker);
        }

        [LuaMethod]
        protected int getCurrentStorage()
        {
            return ffxi.Inventory.GetBagCount(Bag.Storage);
        }

        [LuaMethod]
        protected int getCurrentTemp()
        {
            return ffxi.Inventory.GetBagCount(Bag.Temporary);
        }

        [LuaMethod]
        protected int getMaxInv()
        {
            return ffxi.Inventory.GetBagSize(Bag.Inventory);
        }

        [LuaMethod]
        protected int getMaxSatchel()
        {
            return ffxi.Inventory.GetBagSize(Bag.Satchel);
        }

        [LuaMethod]
        protected int getMaxSack()
        {
            return ffxi.Inventory.GetBagSize(Bag.Sack);
        }

        [LuaMethod]
        protected int getMaxLocker()
        {
            return ffxi.Inventory.GetBagSize(Bag.Locker);
        }

        [LuaMethod]
        protected int getMaxSafe()
        {
            return ffxi.Inventory.GetBagSize(Bag.Safe);
        }

        [LuaMethod]
        protected int getMaxStorage()
        {
            return ffxi.Inventory.GetBagSize(Bag.Storage);
        }

        [LuaMethod]
        protected int getMaxTemp()
        {
            return ffxi.Inventory.GetBagSize(Bag.Temporary);
        }

        //[LuaMethod]
        //protected bool hasSatchel()
        //{
        //    return ffxi.Inventory.HasSatchel;
        //}

        //[LuaMethod]
        //protected bool hasSack()
        //{
        //    return ffxi.Inventory.HasSack;
        //}

        //[LuaMethod]
        //protected short getSelectedItemId()
        //{
        //    return ffxi.Player.SelectedItemIndex;
        //}

        [LuaMethod]
        protected void SendString(string text)
        {
            ffxi.Chat.SendString(text);
        }

        [LuaMethod]
        protected void SetKey(byte key, bool down)
        {
            ffxi.Keyboard.SetKey((Kunihiro.FFXi.Key)key, down);
        }

        [LuaMethod]
        protected void SendKey(byte key)
        {
            ffxi.Keyboard.SendKey((Kunihiro.FFXi.Key)key);
        }

        //[LuaMethod]
        //protected void blockInput(bool block)
        //{
        //    ffxi.
        //}

        //[LuaMethod]
        //protected void setSelectedIndex(byte index)
        //{
        //    ffxi.Player.TopMenu.SelectedIndex = index;
        //}

        //[LuaMethod]
        //protected byte getSelectedIndex()
        //{
        //    return ffxi.Player.TopMenu.SelectedIndex;
        //}

        //[LuaMethod]
        //protected int[] getInvItemIndices(int id)
        //{
        //    List<int> indices = new List<int>();

        //    InventoryItem[] items = ffxi.Inventory.InventoryItems;

        //    for(int i = 0; i < items.Length; i++)
        //    {
        //        if (items[i].itemID == id)
        //        {
        //            indices.Add(i);
        //        }
        //    }

        //    return indices.ToArray();
        //}

        //[LuaMethod]
        //protected int nextInvItemIndex(int id)
        //{
        //    InventoryItem[] items = ffxi.Inventory.InventoryItems;

        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        if (items[i].itemID == id)
        //        {
        //            return i;
        //        }
        //    }
        
        //    return -1;
        //}

        //[LuaMethod]
        //protected int getInvItemCount(int id)
        //{
        //   return ffxi.Inventory.GetItems(id).Length;
        //}
    }
}
