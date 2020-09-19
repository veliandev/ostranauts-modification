using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace ostranauts_modding
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("./mods"))
            {
                Console.WriteLine("Failed to start mod tool; ./mods folder is missing!");
                Console.ReadKey();
                return;
            }

            if (!File.Exists("../../Ostranauts.exe"))
            {
                Console.WriteLine("Can't find Ostranauts.exe. Are you sure we're in Streaming_Assets/ ?");
                Console.ReadKey();
                return;
            }

            Schema baseSchema = new Schema();
            baseSchema.Initialize("./data/");

            Schema schema = new Schema();
            schema.Initialize("./data/");

            foreach(var directory in Directory.GetDirectories("./mods"))
            {
                Schema mod = new Schema();
                mod.Initialize(directory);

                schema.ReplaceValues(mod);
                schema.AppendValues(mod);
            }

            schema.WriteJson();

            Process ostranautsProcess = new Process();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ostranautsProcess = Process.Start("../../Ostranauts.exe");
            }
            else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                ostranautsProcess = Process.Start("wine", "../../Ostranauts.exe");
            }

            ostranautsProcess.WaitForExit();

            baseSchema.WriteJson();
        }
    }
}
