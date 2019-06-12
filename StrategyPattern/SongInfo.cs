using AxShell32;
using Shell32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.IO;

namespace DesignModelDemo
{

    /// <summary>
    /// 歌曲信息类，用于封装歌曲信息与相关的操作
    /// </summary>
    public class SongInfo
    {
        private string filePath;
        public string FilePath { get => filePath; set => filePath = value; }
    }
}
