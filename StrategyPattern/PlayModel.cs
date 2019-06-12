using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignModelDemo
{
    abstract class PlayModel
    {
        public virtual int getCurrIndex(SongInfo currPlaySong, List<SongInfo> currPlaySongList)
        {
            if (currPlaySong == null || currPlaySongList == null || currPlaySongList.Count == 0)
            {
                throw new ArgumentNullException();
            }

            int currIndex;
            try
            {
                currIndex = currPlaySongList.FindIndex((SongInfo song) =>
                { return currPlaySong.FilePath.Equals(song.FilePath); });

            }
            catch (Exception)
            {
                currIndex = 0;
            }
            return currIndex;
        }

        public abstract int getPreIndex(int currIndex, int listCount, int[] randomList);
        public abstract int getNextIndex(int currIndex, int listCount, int[] randomList);
    }

    class SingleCycle : PlayModel
    {
        public override int getNextIndex(int currIndex, int listCount, int[] randomList)
        {
            return currIndex;
        }

        public override int getPreIndex(int currIndex, int listCount, int[] randomList)
        {
            return currIndex;
        }
    }

    class listCycle : PlayModel
    {
        public override int getNextIndex(int currIndex, int listCount, int[] randomList)
        {
            return (currIndex + 1) % listCount;
        }

        public override int getPreIndex(int currIndex, int listCount, int[] randomList)
        {
            return (currIndex - 1 + listCount) % listCount;
        }
    }

    class randomCycle : PlayModel
    {
        public randomCycle(int[] randomList, int listCount)
        {
            buildRandomList(randomList, listCount);
        }

        public override int getNextIndex(int currIndex, int listCount, int[] randomList)
        {
            int rCount = randomList.Count();
            int nextIndex = 0;
            for (int i = 0; i < rCount; i++)
            {
                if (randomList[i] == currIndex)
                {
                    if (i == rCount - 1)
                    {
                        buildRandomList(randomList, listCount);
                        nextIndex = 0;
                    }
                    else
                    {
                        nextIndex = randomList[i + 1];
                    }
                    break;
                }
            }
            return nextIndex;
        }

        public override int getPreIndex(int currIndex, int listCount, int[] randomList)
        {
            int rCount = randomList.Count();
            int preIndex = 0;
            for (int i = 0; i < rCount; i++)
            {
                if (randomList[i] == currIndex)
                {
                    if (i == rCount - 1)
                    {
                        //startNewRound();
                        preIndex = randomList[0];
                    }
                    else
                    {
                        preIndex = randomList[i + 1];
                    }
                    break;
                }
            }
            return preIndex;
        }

        private void buildRandomList(int[] randomList, int listCount)
        {
            randomList = new int[listCount];

            //初始化序列
            for (int i = 0; i < listCount; i++)
            {
                randomList[i] = i;
            }

            //随机序列
            for (int i = listCount - 1; i >= 0; i--)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int j = r.Next(0, listCount - 1);
                swap(randomList, i, j);
            }
        }

        private void swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }

    class ContextPlayModel
    {
        PlayModel currPlayModel;
        public ContextPlayModel(PlayModel currPlayModel)
        {
            this.currPlayModel = currPlayModel;
        }

        public int getCurrIndex(SongInfo currPlaySong, List<SongInfo> currPlaySongList)
        {
            return currPlayModel.getCurrIndex(currPlaySong, currPlaySongList);
        }

        public int getPreIndex(int currIndex, int listCount, int[] randomList)
        {
            return currPlayModel.getPreIndex(currIndex, listCount, randomList);

        }

        public int getNextIndex(int currIndex, int listCount, int[] randomList)
        {
            return currPlayModel.getNextIndex(currIndex, listCount, randomList);
        }
    }
}