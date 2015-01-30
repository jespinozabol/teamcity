using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;

using Microsoft.Build.Tasks;

namespace AsyncExec
{
  public class AsyncExec : Exec
  {
    #region Task Members
    protected override int ExecuteTool(string pathToTool, string responseFileCommands, string commandLineCommands)
    {
      Process process = new Process();
      process.StartInfo = GetProcessStartInfo(pathToTool, commandLineCommands);
      process.Start();
      return 0;
    }
    #endregion

    #region Methods
    protected virtual ProcessStartInfo GetProcessStartInfo(string executable, string arguments)
    {
      if (arguments.Length > 0x7d00)
      {
        this.Log.LogWarningWithCodeFromResources("ToolTask.CommandTooLong", new object[] { base.GetType().Name });
      }
      ProcessStartInfo startInfo = new ProcessStartInfo(executable, arguments);
      startInfo.WindowStyle = ProcessWindowStyle.Hidden;
      startInfo.CreateNoWindow = true;
      startInfo.UseShellExecute = true;
      string workingDirectory = this.GetWorkingDirectory();
      if (workingDirectory != null)
      {
        startInfo.WorkingDirectory = workingDirectory;
      }
      StringDictionary environmentOverride = this.EnvironmentOverride;
      if (environmentOverride != null)
      {
        foreach (DictionaryEntry entry in environmentOverride)
        {
          startInfo.EnvironmentVariables.Remove(entry.Key.ToString());
          startInfo.EnvironmentVariables.Add(entry.Key.ToString(), entry.Value.ToString());
        }
      }
      return startInfo;
    }
    #endregion
  }
}
