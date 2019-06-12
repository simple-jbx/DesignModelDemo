using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignModelDemo
{
    public partial class StrategyPattern : Form
    {
        ContextPlayModel contextPlayModel;
        int[] randomList;

        public StrategyPattern()
        {
            InitializeComponent();
            SongInfo song0 = new SongInfo(@"D:\QQMusic\虎二 - 一个人决定.mp3");
            SongInfo song1 = new SongInfo(@"D:\QQMusic\陆虎 - 雪落下的声音.flac");
            SongInfo song2 = new SongInfo(@"D:\QQMusic\娜美 - 一梦半生.mp3");
            List<SongInfo> currPlaySongList = new List<SongInfo>();
            currPlaySongList.Add(song0);
            currPlaySongList.Add(song1);
            currPlaySongList.Add(song2);

            contextPlayModel = new ContextPlayModel(new RandomCycle(currPlaySongList.Count));
            Console.WriteLine(contextPlayModel.getCurrIndex(song1, currPlaySongList));
            Console.WriteLine(contextPlayModel.getNextIndex(contextPlayModel.getCurrIndex(song1, currPlaySongList), currPlaySongList.Count ));
            Console.WriteLine(contextPlayModel.getPreIndex(contextPlayModel.getCurrIndex(song1, currPlaySongList), currPlaySongList.Count ));

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
        }
    }
}
