using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Suima.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// 右にスライド(ループする)したものを返す
        /// </summary>
        public static IEnumerable<T> RightSlide<T>(this IEnumerable<T> self){
            var list = self.ToList();
            var temp = list[list.Count - 1];
            foreach (var i in Enumerable.Range(0,list.Count - 1).Reverse()) {
                list[i + 1] = list[i];
            }
            list[0] = temp;
            return list;
        }
        /// <summary>
        /// 左にスライド(ループする)したものを返す
        /// </summary>
        public static IEnumerable<T> LeftSlide<T>(this IEnumerable<T> self){
            var list = self.ToList();
            var temp = list[0];
            foreach (var i in Enumerable.Range(1,list.Count - 1)) {
                list[i - 1] = list[i];
            }
            list[list.Count - 1] = temp;
            return list;
        }
        /// <summary>
        /// vecが正の値なら右に、負の値なら左にスライドする
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> Slide<T>(this IEnumerable<T> self,int vec){
            if(vec > -1) {
                return self.RightSlide();
            } else {
                return self.LeftSlide();
            }
        }

        /// <summary>
        /// 先頭に要素を追加する
        /// </summary>
        public static IEnumerable<T> Push<T>(this IEnumerable<T> self,T item){
            var list = self.ToList();
            list.Insert(0,item);
            return list;
        }

        /// <summary>
        /// 削除せず先頭の要素を返す
        /// </summary>
        public static T Peek<T>(this IEnumerable<T> self){
            return self.ElementAt(0);
        }

        /// <summary>
        /// ランダムな要素を返す
        /// </summary>
        public static T Random<T>(this IEnumerable<T> self) {
            var random = new Random();
            var idx = random.Next(0, self.Count());
            return self.ElementAt(idx);
        }
        
        public static T Random<T>(this IEnumerable<T> self, Func<T,bool> source){
            return self.Where(source)
                       .Random();
        }

        /// <summary>
        /// シャッフルする
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> self){
            var list = self.ToList();
            var random = new Random();
            foreach (var i in Enumerable.Range(0, list.Count)) {
                var idx = random.Next(0, list.Count);
                var temp = list[i];
                list[i] = list[idx];
                list[idx] = temp;
            }
            return list;
        }
        /// <summary>
        /// アイテムをすべてString型にする
        /// </summary>
        /// <returns>すべてSrting型にして返す</returns>
        public static IEnumerable<String> AllToString<T>(this IEnumerable<T> self)
            => self.Select(x => x.ToString());

        public static void Print<T>(this IEnumerable<T> self){
            foreach(var item in self){
                Debug.Log(item.ToString());
                Console.WriteLine(item.ToString());
            }
        }
        
        public static IEnumerable<T> Loop<T>(this IEnumerable<T> source,int count){
            var arr = source.ToArray();
            for (var i = 0; i < count; i++)
            {
                foreach (var item in arr)
                {
                    yield return item;
                }
            }
        }
        
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source,int count){
            var arr = source.ToArray();
            var arrCount = arr.Length;
            for (var i = 0; i < count; i++)
            {
                yield return arr[i % arrCount];
            }
        }
    }
}
