﻿namespace Task_Manager.Model
{
    public static class SettingPath
    {
        public static string DefaultFilePath { get { return $@"C:\Users\lenovo\Desktop\{Users.Name + Users.id.ToString()}"; } set { DefaultFilePath = value; } }


    }
}
