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
                Arguments = "index.js 1 2",
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

            var psi2 = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = "index.py 'vikash' 'verma'",
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            var process1 = Process.Start(psi2);
            string output1 = process1.StandardOutput.ReadToEnd();
            string errors2 = process1.StandardError.ReadToEnd();
            process.WaitForExit();
            Console.WriteLine("Output :" + output1);
            Console.WriteLine("Errors :" + errors2);


            ScriptEngine engine = Python.CreateEngine();
            engine.Execute("print('Hello I am from python')");

        }
    }
}
