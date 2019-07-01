using System.Windows.Forms;

namespace SingletonPattern
{
    public sealed partial class Tool3 : Form
    {
        /*
            在实际应用中，C#与公共语言运行库也提供了一种‘静态初始化’方法，
        这种方法不需要开发人员显式地编写线程安全代码，即可解决多线程环境下
        它是不安全的问题。
        */ 
        private static readonly Tool3 instance = new Tool3();

        private Tool3()
        {
            InitializeComponent();
        }

        public static Tool3 GetInstance()
        {          
            return instance;
        }
    }
}
