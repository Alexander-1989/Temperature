using System;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Temperature.Service.TaskWindows
{
    internal class WindowsTask
    {
        private const string taskName = "TemperatureAppTask";
        private const string taskDescription = "Start Arduino Temperature Application";
        private static readonly string applicationPath = Application.ExecutablePath;

        public static bool TaskExists()
        {
            try
            {
                using (TaskService taskService = new TaskService())
                {
                    using (Task task = taskService.FindTask(taskName))
                    {
                        return task != null;
                    }
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
                    using (TaskService taskService = new TaskService())
                    {
                        using (TaskDefinition taskDefinition = taskService.NewTask())
                        {
                            using (LogonTrigger logon = new LogonTrigger())
                            {
                                taskDefinition.RegistrationInfo.Description = taskDescription;
                                taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
                                taskDefinition.Triggers.Add(logon);
                                taskDefinition.Actions.Add(applicationPath);
                                taskService.RootFolder.RegisterTaskDefinition(taskName, taskDefinition);
                            }
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
                    using (TaskService taskService = new TaskService())
                    {
                        taskService.RootFolder.DeleteTask(taskName);
                    }
                }
            }
            catch (Exception) { }
        }
    }
}