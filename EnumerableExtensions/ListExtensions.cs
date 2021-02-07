using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Suima.Extensions {
    public static class ListExtensions {
        /// <summary>
        /// 指定したインデックスのアイテムを返し削除する
        /// </summary>
        public static T IndexPop<T>(this IList<T> self, int index) {
            var temp = self[index];
            self.RemoveAt(index);
            return temp;
        }
        /// <summary>
        /// 先頭のアイテムを削除しつつ返す
        /// </summary>
        public static T Pop<T>(this IList<T> self) 
            => IndexPop(self, 0);
        

        /// <summary>
        /// ランダムなアイテムを返してリストから消す
        /// </summary>
        public static T RandomPop<T>(this IList<T> self) {
            Random random = new Random();
            var idx = random.Next(0, self.Count);
            var temp = self[idx];
            self.RemoveAt(idx);
            return temp;
        }
    }
    
}
