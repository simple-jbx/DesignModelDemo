using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatternDemo
{
    public partial class StrategyPatternV2 : Form
    {
        List<SongInfo> currPlaySongList = new List<SongInfo>();
        ContextPlayModel contextPlayModel;
        SongInfo currPlaySong;

        public StrategyPatternV2()
        {
            InitializeComponent();
            SongInfo song0 = new SongInfo(Application.StartupPath + "\\music\\虎二 - 一个人决定.mp3");
            SongInfo song1 = new SongInfo(Application.StartupPath + "\\music\\娜美 - 一梦半生.mp3");
            SongInfo song2 = new SongInfo(Application.StartupPath + "\\music\\海来阿木 _ 阿呷拉古 _ 曲比阿且 - 别知己.mp3");
            SongInfo song3 = new SongInfo(Application.StartupPath + "\\music\\陆虎 - 雪落下的声音.mp3");
            currPlaySongList.Add(song0);
            currPlaySongList.Add(song1);
            currPlaySongList.Add(song2);
            currPlaySongList.Add(song3);
            currPlaySong = song0;
            contextPlayModel = new ContextPlayModel(new ListCycle());
            label1.Text = "当前播放歌曲为 "  + contextPlayModel.getCurrIndex(currPlaySong,currPlaySongList) + " " + currPlaySong.OriginName;
            label2.Text = "当前播放模式为列表循环";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            UCPanel uCPanel = (UCPanel)sender;
            Type classType = Type.GetType(uCPanel.Tag.ToString());
            object[] constructParms = new object[] { currPlaySongList.Count };
            contextPlayModel = new ContextPlayModel((PlayModel)Activator.CreateInstance(classType, constructParms));
            switch (uCPanel.Name) 
            {
                case "panel4" :
                    panel2.BackgroundImage = panel4.BackgroundImage;
                    label2.Text = "当前播放模式为随机播放";
                    break;
                case "panel5" :
                    panel2.BackgroundImage = panel5.BackgroundImage;
                    label2.Text = "当前播放模式为列表循环";
                    break;
                case "panel6" :
                    panel2.BackgroundImage = panel6.BackgroundImage;
                    label2.Text = "当前播放模式为单曲播放";
                    break;             
            }
            panel3.Visible = false;
        }

        private void ucPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            int preIndex = contextPlayModel.getPreIndex(contextPlayModel.getCurrIndex(currPlaySong, currPlaySongList), currPlaySongList.Count);
            currPlaySong = currPlaySongList[preIndex];
            label1.Text = "当前播放歌曲为 " + " " + preIndex + " " + currPlaySong.OriginName;
        }

        private void ucPanel3_MouseClick(object sender, MouseEventArgs e)
        {
            int nextIndex = contextPlayModel.getNextIndex(contextPlayModel.getCurrIndex(currPlaySong, currPlaySongList), currPlaySongList.Count);
            currPlaySong = currPlaySongList[nextIndex];
            label1.Text = "当前播放歌曲为 " + " " + nextIndex + " " + currPlaySong.OriginName;
        }
    }
}
