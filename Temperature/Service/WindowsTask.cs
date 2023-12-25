using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Temperature.Service.TaskWindows
{
    internal class WindowsTask
    {
        private const string taskName = "TemperatureAppTask";
        private static readonly string applicationPath = Application.ExecutablePath;
        private static readonly TaskService taskService = new TaskService();

        public static bool TaskExists()
        {
            try
            {
                using (Task task = taskService.FindTask(taskName))
                {
                    return task != null;
                }
            }
            catch (Exception) { }
            return false;
        }

        public static void TaskCreate()
        {
            try
            {
                if (!TaskExists())
                {
                    using (TaskDefinition taskDefinition = taskService.NewTask())
                    {
                        using (LogonTrigger logon = new LogonTrigger())
                        {
                            taskDefinition.RegistrationInfo.Description = taskName;
                            taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
                            taskDefinition.Triggers.Add(logon);
                            taskDefinition.Actions.Add(applicationPath);
                            taskService.RootFolder.RegisterTaskDefinition(taskName, taskDefinition);
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        public static void TaskDelete()
        {
            try
            {
                if (TaskExists())
                {
                    taskService.RootFolder.DeleteTask(taskName);
                }
            }
            catch (Exception) { }
        }
    }
}