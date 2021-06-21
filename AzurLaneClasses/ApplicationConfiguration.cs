using System;

namespace AzurLaneClasses
{
    public class ApplicationConfiguration
    {
        public String DatabaseHost { get; set; } = "";
        public String Database { get; set; } = "";
        public String User { get; set; } = "";
        public String Password { get; set; } = "";

        public String GetConnString()
        {
            return $"server={DatabaseHost};database={Database};user={User};password={Password}";
        }
    }
}