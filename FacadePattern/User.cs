using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class User
    {
        private string id;
        private string account;
        private string nickname;
        private string password;
        private Image img;
        private string registerTime;
        private int isDelete;

        public string Id { get => id;}
        public string Account { get => account; }
        public string Nickname { get => Nickname; set => nickname = value; }
        public string Password { get => password; }
        public Image Img { get => img; set => img = value; }
        public string RegisterTime { get => registerTime; }
        public int IsDelete { get => isDelete; set => isDelete = value; }

        public User(string id, string account, string nickname, string password, Image img, String registerTime,
            int isDelete)
        {
            this.id = id;
            this.account = account;
            this.nickname = nickname;
            this.password = password;
            this.img = img;
            this.registerTime = registerTime;
        }

        public User(string account, string nickname, string password, Image img, String registerTime,
            int isDelete)
        {
            setId();
            setPassword(password, registerTime);
            this.account = account;
            this.nickname = nickname;
            this.password = password;
            this.img = img;
            this.registerTime = registerTime;
        }

        public bool passwordIsCorrect(string password)
        {
            HashAlgorithm hash = HashAlgorithm.Create();
            byte[] hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password + registerTime));
            password = Encoding.UTF8.GetString(hashBytes);
            if(this.password.Equals(password))
            {
                return true;
            }
            return false;
        }

        private void setId()
        {
            this.id = "U" + Guid.NewGuid().ToString("N");
        }

        private void setPassword(string password, string registerTime)
        {
            HashAlgorithm hash = HashAlgorithm.Create();
            byte[] hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password + registerTime));
            this.password = Encoding.UTF8.GetString(hashBytes);
        }
    }
}
