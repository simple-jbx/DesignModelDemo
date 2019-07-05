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

namespace DesignPatternDemo
{

    /// <summary>
    /// 歌曲信息类，用于封装歌曲信息与相关的操作
    /// </summary>
    public class SongInfo
    {
        private string id;
        private string filePath;
        private string lyricPath;
        private int isDelete;
        private string fileName;
        private string fileSize;
        private string artist;
        private string album;
        private Image albumImage;
        private string year;
        private string originName;
        private string duration;
        private string byteRate;
        private Image smallAblum;

        public string FileName { get => fileName; }
        public string FilePath { get => filePath; }
        public string Filesize { get => fileSize; }
        public string Artist { get => artist; }
        public string Album { get => album; }
        public Image AlbumImage { get => albumImage; }
        public string Year { get => year; }
        public string OriginName { get => originName; }
        public string Duration { get => duration; }
        public string ByteRate { get => byteRate; }
        public Image SmallAblum { get => smallAblum; }
        public string Id { get => id; set => id = value; }
        public int IsDelete { get => isDelete; set => isDelete = value; }
        public string LyricPath { get => lyricPath; set => lyricPath = value; }

        public SongInfo(string filePath)
        {
            setSongInfo(filePath);
            setAlbumArt(filePath);
            setId(null);
        }

        public SongInfo(string id, string filePath, string lyricPath, int isDelete = 0)
        {
            setId(id);
            setSongInfo(filePath);
            setAlbumArt(filePath);
            setIsdelete(isDelete);
            setLyric(lyricPath);
        }

        /// <summary>
        /// 设置歌曲信息
        /// </summary>
        /// <param name="filePath"></param>
        private void setSongInfo(string fPath)
        {
            try
            {
                ShellClass sh = new ShellClass();
                Folder dir = sh.NameSpace(Path.GetDirectoryName(fPath));
                FolderItem item = dir.ParseName(Path.GetFileName(fPath));

                filePath = fPath;

                fileName = dir.GetDetailsOf(item, 0).Split('.')[0];
                if (fileName == string.Empty)
                    fileName = "未知";

                fileSize = dir.GetDetailsOf(item, 1);
                if (fileSize == string.Empty)
                    fileSize = "未知";

                artist = dir.GetDetailsOf(item, 13);
                if (artist == string.Empty)
                    artist = "未知";

                album = dir.GetDetailsOf(item, 14);
                if (album == string.Empty)
                    album = "未知";

                year = dir.GetDetailsOf(item, 15);
                if (year == string.Empty)
                    year = "未知";

                originName = dir.GetDetailsOf(item, 21);
                if (originName == string.Empty)
                    originName = "未知";

                duration = dir.GetDetailsOf(item, 27);
                if (duration == string.Empty)
                    duration = "未知";

                byteRate = dir.GetDetailsOf(item, 28);
                if (byteRate == string.Empty)
                    byteRate = "未知";

                lyricPath = "";
                isDelete = 0;
            }
            catch (Exception)
            {
            }
        }

        private void setAlbumArt(string strPath)
        {
            if (strPath != null && !(strPath == string.Empty))
            {
                TagLib.File file = TagLib.File.Create(strPath);
                if (file.Tag.Pictures.Length > 0)
                {
                    var bin = (byte[])(file.Tag.Pictures[0].Data.Data);
                    smallAblum = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(64, 64, null, IntPtr.Zero);
                    albumImage = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(250, 250, null, IntPtr.Zero);
                    return;
                }
            }
        }

        private void setId(string id)
        {
            if (id == null)
            {
                this.id = Guid.NewGuid().ToString("N");
            }
            else
            {
                this.id = id;
            }
        }

        private void setIsdelete(int isDelete)
        {
            this.isDelete = isDelete;
        }

        private void setLyric(string lyricPath)
        {
            if (!string.IsNullOrEmpty(lyricPath))
            {
                this.lyricPath = lyricPath;
            }
        }
    }
}
