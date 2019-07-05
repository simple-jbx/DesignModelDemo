using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DesignPatternDemo
{
    abstract class PlayModel
    {
        protected int[] randomList;
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
                { return currPlaySong.Id.Equals(song.Id); });

            }
            catch (Exception)
            {
                currIndex = 0;
            }
            return currIndex;
        }

        public abstract int getPreIndex(int currIndex, int listCount);
        public abstract int getNextIndex(int currIndex, int listCount);
    }

    class SingleCycle : PlayModel
    {
        public SingleCycle(int listCount = 0)
        { }

        public override int getNextIndex(int currIndex, int listCount)
        {
            return currIndex;
        }

        public override int getPreIndex(int currIndex, int listCount)
        {
            return currIndex;
        }
    }

    class ListCycle : PlayModel
    {
        public ListCycle(int listCount = 0)
        { }

        public override int getNextIndex(int currIndex, int listCount)
        {
            return (currIndex + 1) % listCount;
        }

        public override int getPreIndex(int currIndex, int listCount)
        {
            return (currIndex - 1 + listCount) % listCount;
        }
    }

    class RandomCycle : PlayModel
    {
        public RandomCycle(int listCount)
        {
            buildRandomList(listCount);
        }

        public override int getNextIndex(int currIndex, int listCount)
        {
            int rCount = randomList.Count();
            int nextIndex = 0;
            if(rCount != listCount)
            {
                buildRandomList(listCount);
                return randomList[0];
            }
            else
            {
                for (int i = 0; i < rCount; i++)
                {
                    if (randomList[i] == currIndex)
                    {
                        if (i == rCount - 1)
                        {
                            startNewRound(rCount);
                            nextIndex = randomList[0];
                        }
                        else
                        {
                            nextIndex = randomList[i + 1];
                        }
                        break;
                    }
                }
            }        
            return nextIndex;
        }

        public override int getPreIndex(int currIndex, int listCount)
        {
            int rCount = randomList.Count();
            int preIndex = 0;
            if (rCount != listCount)
            {
                buildRandomList(listCount);
                return randomList[0];
            }
            else
            {
                for (int i = 0; i < rCount; i++)
                {
                    if (randomList[i] == currIndex)
                    {
                        if (i == 0)
                        {
                            startNewRound(listCount);
                            preIndex = randomList[listCount - 1];
                        }
                        else
                        {
                            preIndex = randomList[i - 1];
                        }
                        break;
                    }
                }
            } 
            return preIndex;
        }

        private void buildRandomList(int listCount)
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

        private void startNewRound(int listCount)
        {
            buildRandomList(listCount);
        }
    }

    class ContextPlayModel
    {
        private PlayModel currPlayModel;
        public ContextPlayModel(PlayModel currPlayModel)
        {
            this.currPlayModel = currPlayModel;
        }

        public int getCurrIndex(SongInfo currPlaySong, List<SongInfo> currPlaySongList)
        {
            return currPlayModel.getCurrIndex(currPlaySong, currPlaySongList);
        }

        public int getPreIndex(int currIndex, int listCount)
        {
            return currPlayModel.getPreIndex(currIndex, listCount);

        }

        public int getNextIndex(int currIndex, int listCount)
        {
            return currPlayModel.getNextIndex(currIndex, listCount);
        }
    }
}