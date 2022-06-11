using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    public static class SKKConsolePageConfigStorage
    {
        private static int colIndex_ = 0;
        private static List<string> nameList_ = new List<string>();
        private static int nameIndex_ = 0;

        private static Random myRand_ = new Random();

        public static string ValidateName(string name) => $"{name}{myRand_.Next(100)}";
    }
}
