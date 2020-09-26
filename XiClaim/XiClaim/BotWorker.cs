using Kunihiro.FFXi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XiClaim
{
    public enum Mode
    {
        ID,
        Name,
    }
    public class BotWorker
    {
        private volatile XiLib ffxi;
        private volatile uint id;
        private volatile string command;

        private Thread thread;
        private volatile bool run = false;
        private bool alarm = true;
        private SoundPlayer player = new SoundPlayer("alarm.wav");
        private Mode mode;
        private string name;
        private float delay;
        public event EventHandler Alarm;

        public BotWorker(XiLib xi, bool alarm, Mode mode, float delay, uint id, string name, string command)
        {
            this.ffxi = xi;
            this.id = id;
            this.alarm = alarm;
            this.mode = mode;
            this.name = name;
            this.delay = delay;

            this.command = command;
        }

        public void Start()
        {
            thread = new Thread(new ThreadStart(ThreadWorker));
            thread.IsBackground = true;
            run = true;
            thread.Start();
        }

        public void Stop()
        {
            run = false;
        }

        public void StopAlarm()
        {
            player.Stop();
        }

        private bool CompareFlags(uint val, uint op)
        {
            return (val & op) == op;
        }
        private bool MobSpawnedAndUnclaimed(EntityInfo entity)
        {
            if (entity.Pointer != IntPtr.Zero)
            {
                return entity.HPP > 0 && CompareFlags((uint)entity.Flags1, (uint)RenderFlagsType1.Spawned)
                    && CompareFlags((uint)entity.Flags2, (uint)RenderFlagsType2.Loaded)
                    && entity.Status != EntityStatus.Engaged;
            }

            return false;
        }

        private void OutputMessage(string msg)
        {
            ffxi.Chat.AddToChat(ChatIcons.AutoTranslateStart + Chat.WrapInColor("XiClaim", ColorMode.Two, 83) + 
                ChatIcons.AutoTranslateEnd + " " + msg ,177, false);
        }

        private void ThreadWorker()
        {
            while (run)
            {
                if (mode == Mode.Name)
                {
                    while (id == 0)
                    {
                        for (uint i = 0; i < 2000; i++)
                        {
                            EntityInfo ei = ffxi.Entity.GetEntity(i);
                            if (ei.Pointer != IntPtr.Zero)
                            {
                                if (name.ToLower() == ei.Name.ToLower())
                                {
                                    id = ei.ID;
                                    break;
                                }
                            }
                        }
                    }
                }

                EntityInfo entity = ffxi.Entity.GetEntity(id);

                if (MobSpawnedAndUnclaimed(entity) && run)
                {
                    if (alarm && run)
                    {
                        player.PlayLooping();
                        if (Alarm != null)
                        {
                            Alarm(this, new EventArgs());
                        }
                    }

                    OutputMessage(Chat.WrapInColor(entity.Name, ColorMode.Two, 110) + " has spawned.");

                    Thread.Sleep((int)(delay * 1000.0f));

                    while (entity.Status != EntityStatus.Engaged && run)
                    {
                        if (!string.IsNullOrEmpty(command))
                        {
                            if (entity.Distance < 20.0f)
                            {
                                ffxi.Target.SetTarget(entity.ID);
                                ffxi.Chat.SendString(command);
                                Thread.Sleep(1000);
                            }
                        }
            
                    }

                    if (entity.ClaimedBy != 0)
                    {
                        OutputMessage(Chat.WrapInColor(entity.Name, ColorMode.Two, 110) + " claimed by " + Chat.WrapInColor(ffxi.Entity.FindByServerID(entity.ClaimedBy).Value.Name + ".", ColorMode.Two, 76));
                    }
                }

                Thread.Sleep(10);
            }
        }
    }
}
