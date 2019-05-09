using System.Collections.Generic;

namespace DojoSecrets.Models
{
    public class SecretDashboard
    {
        public Secret NewSecret {get;set;}
        public List<Secret> RecentSecrets {get;set;}
        public User CurrentUser {get;set;}
    }
}