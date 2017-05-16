using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Novell.Directory.Ldap;

namespace WebApplication.Models
{
    public class Ldap
    {
        public string ldapHost { get; set; }
        public int ldapPort { get; set; }
        public int ldapVersion { get; set; }
        public string loginDN { get; set; }
        public string LoginDNPassword { get; set; }
        public string objectDN { get; set; }
        public string objectDNPassword { get; set; }
        
        public LdapConnection connection { get; set; }
        public LdapAttribute attribute { get; set; }



        public Ldap(string login, string password)
        {
            this.ldapPort = LdapConnection.DEFAULT_PORT;
            this.ldapVersion = LdapConnection.Ldap_V3;

            this.ldapHost = "185.81.157.150";
            this.loginDN = "CN=walidd,CN=Users,DC=hunterviews,DC=com";
            this.LoginDNPassword = "Aze12345";
            this.objectDN = "CN="+login+",CN=Users,DC=hunterviews,DC=com";
            this.objectDNPassword = password;

            this.connection = new LdapConnection();
            this.attribute = new LdapAttribute("userpassword", this.objectDNPassword);

        }

        public bool connect()
        {
            //Connexion au serveur Ldap
            this.connection.Connect(this.ldapHost, this.ldapPort);
            this.connection.SecureSocketLayer = true;

            //L'authentification au serveur Ldap
            this.connection.Bind(this.ldapVersion, this.loginDN, this.LoginDNPassword);

            bool compare = this.connection.Compare(this.objectDN, this.attribute);
            //this.connection.Disconnect();
            return compare;
          }





    }
}
