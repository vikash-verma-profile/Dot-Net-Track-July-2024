using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace DemoOnWin32
{
    internal class Class1
    {
        public static void Main()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "node",
                Arguments = "index.js",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            var process = Process.Start(psi);
            string output = process.StandardOutput.ReadToEnd();
            string errors=process.StandardError.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine("Output :"+output);
            Console.WriteLine("Errors :" + errors);

            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print('Hello I am from python')");

        }
    }
}
