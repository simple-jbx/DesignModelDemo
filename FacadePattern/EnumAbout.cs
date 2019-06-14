using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class EnumAbout
    {
        //播放列表 本地0 历史1 收藏2 搜索3
        public enum ListName { local = 0, history, collection, search };

        //播放模式 随机0，单曲循环1，列表循环2
        public enum PlayModel { randomPlay = 0, singleCycle, listCycle };

        //列表名称 本地0 历史1 收藏2
        public enum tableName { local_list = 0, history_list, collect_list,  user};
    }
}
