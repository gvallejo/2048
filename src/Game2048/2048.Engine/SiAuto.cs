using Gurock.SmartInspect;
using System;

namespace _2048.Engine
{
  
    public sealed class SiAuto
    {
        private const string APPNAME = "Auto";
        private const string CONNECTIONS =
            "pipe(reconnect=true, reconnect.interval=1s)";
        private const string SESSION = "2048.Engine";

        private static Session fMain;
        private static SmartInspect fSi;

        private SiAuto() { }

        static SiAuto()
        {
            fSi = new SmartInspect(APPNAME);
            fSi.Connections = CONNECTIONS;
            fMain = fSi.AddSession(SESSION, true);
            if (!fSi.Enabled)
                fSi.Enabled = true;
        }

    
        public static SmartInspect Si
        {
            get { return fSi; }
        }


        public static Session Main
        {
            get { return fMain; }
        }
    }
}



