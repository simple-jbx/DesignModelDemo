using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingletonPattern
{
    public partial class Tool2 : Form
    {
        private static Tool2 instance;
        private static readonly object syncRoot = new object();

        private Tool2()
        {
            InitializeComponent();
        }

        //实例未被创建时加锁（双重锁定，多线程安全）
        public static Tool2 GetInstance()
        {
            if(instance == null)
            {
                lock(syncRoot)
                {
                    if(instance == null)
                    {
                        instance = new Tool2();
                    }
                }
            }
            return instance;
        }
    }
}
