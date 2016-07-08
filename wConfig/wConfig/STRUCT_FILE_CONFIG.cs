using System;
using System.Runtime.InteropServices;

namespace wConfig
{
    /// <summary>
    /// Estrutura de configuração do arquivo
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class STRUCT_FILE_CONFIG
    {
        public Int16 VERSION;

        public Int16 RES;

        public Int16 ANIMATION;

        public Int16 SOUND;
        public Int16 MUSIC;

        public Int16 SERVER;

        public Int16 BRIGHT;
        public Int16 CURSOR;

        public Int16 DEMO;
        public Int16 WINDOW;

        public Int16 CLASSIC;

        public Int16 CAMERAROTATE;

        public Int16 DXT;

        public Int16 KEYTYPE;
        public Int16 CAMERAVIEW;
    }
}
