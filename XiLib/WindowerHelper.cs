using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kunihiro.FFXi
{
    public static class WindowerHelper
    {
        [DllImport("WindowerHelper.dll")]
        public static extern void CCHGetArg(int helper, short index, byte[] buffer);
        [DllImport("WindowerHelper.dll")]
        public static extern short CCHGetArgCount(int helper);
        [DllImport("WindowerHelper.dll")]
        public static extern bool CCHIsNewCommand(int helper);
        [DllImport("WindowerHelper.dll")]
        public static extern void CKHBlockInput(int helper, bool block);
        [DllImport("WindowerHelper.dll")]
        public static extern void CKHSendString(int helper, string data);
        [DllImport("WindowerHelper.dll")]
        public static extern void CKHSetKey(int helper, byte key, bool down);
        [DllImport("WindowerHelper.dll")]
        public static extern int CreateConsoleHelper(string name);
        [DllImport("WindowerHelper.dll")]
        public static extern int CreateKeyboardHelper(string name);
        [DllImport("WindowerHelper.dll")]
        public static extern int CreateTextHelper(string name);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHCreateTextObject(int helper, string name);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHDeleteTextObject(int helper, string name);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHFlushCommands(int helper);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetBGBorderSize(int helper, string name, float pixels);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetBGColor(int helper, string name, byte a, byte r, byte g, byte b);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetBGVisibility(int helper, string name, bool visible);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetBold(int helper, string name, bool bold);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetColor(int helper, string name, byte a, byte r, byte g, byte b);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetFont(int helper, string name, string font, short height);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetItalic(int helper, string name, bool italic);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetLocation(int helper, string name, float x, float y);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetRightJustified(int helper, string name, bool justified);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetText(int helper, string name, string text);
        [DllImport("WindowerHelper.dll")]
        public static extern void CTHSetVisibility(int helper, string name, bool visible);
        [DllImport("WindowerHelper.dll")]
        public static extern void DeleteConsoleHelper(int helper);
        [DllImport("WindowerHelper.dll")]
        public static extern void DeleteKeyboardHelper(int helper);
        [DllImport("WindowerHelper.dll")]
        public static extern void DeleteTextHelper(int helper);
    }
}
