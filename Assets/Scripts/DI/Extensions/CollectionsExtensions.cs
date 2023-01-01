using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

namespace DI.Extensions {
    internal static class CollectionsExtensions {
        /// <summary>
        /// Создает массив указанной величины <paramref name="count"/> по средством конструктора <see cref="constructor"/>
        /// </summary>
        internal static T[] CreateArray<T>(Func<T> constructor, int count) {
            var array = new T[count];
            for (int i = 0; i < count; i++) {
                array[i] = constructor();
            }

            return array;
        }

        /// <summary>
        /// Создает словарь указанной величины <paramref name="count"/> по средством конструктора <see cref="constructor"/>
        /// </summary>
        internal static Dictionary<int, TValue> CreateMap<TValue>(Func<TValue> constructor, int count) {
            var map = new Dictionary<int, TValue>(count);
            for (int i = 0; i < count; i++) {
                map.Add(i, constructor());
            }

            return map;
        }

        /// <summary>
        /// Перемножает все элементы перечисления
        /// </summary>
        internal static float Multi(this IEnumerable<float> array) {
            if (!array.Any()) {
                return 0;
            }

            return array.Aggregate(1.0f, (result, next) => result * next);
        }

        /// <summary>
        /// Добавляет коллекцию в конец 
        /// </summary>
        internal static void AddRange(this IList list, IEnumerable enumerable) {
            foreach (var instance in enumerable) {
                list.Add(instance);
            }
        }

        /// <summary>
        /// "Выдавливает" элемент из начала очереди путем добавления нового в ее конец
        /// </summary>
        internal static T PushWithPop<T>(this T[] collection, T value) {
            int uBound = collection.Length;
            T bufferValue = default;
            for (int i = 0; i < uBound; i++) {
                bufferValue = collection[i];
                collection[i] = value;
                value = bufferValue;
            }

            return bufferValue;
        }

        /// <summary>
        /// Краткая запись цикла `foreach` для массива 
        /// </summary>
        internal static void ForEach<T>(this T[] collection, Action<T> action) {
            for (int i = 0; i < collection.Length; i++) {
                action?.Invoke(collection[i]);
            }
        }

        /// <summary>
        /// Краткая запись цикла `foreach` для массива, передающая в действие индекс элемента 
        /// </summary>
        internal static void ForEach<T>(this T[] collection, Action<T, int> action) {
            for (int i = 0; i < collection.Length; i++) {
                action?.Invoke(collection[i], i);
            }
        }

        /// <summary>
        /// Краткая запись цикла `foreach` для списка, передающая в действие индекс элемента 
        /// </summary>
        internal static void ForEach<T>(this IReadOnlyList<T> collection, Action<T, int> action) {
            for (int i = 0; i < collection.Count; i++) {
                action?.Invoke(collection[i], i);
            }
        }

        /// <summary>
        /// Краткая запись цикла `foreach` 
        /// </summary>
        internal static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action) {
            foreach (var instance in enumeration) {
                action?.Invoke(instance);
            }
        }

        /// <summary>
        /// Добавляет в конец двунаправленного связного списка перечисление элементов
        /// </summary>
        internal static void AddRange<T>(this LinkedList<T> list, IEnumerable<T> entities) {
            foreach (var e in entities) {
                list.AddLast(e);
            }
        }

        /// <summary>
        /// Возвращает индекс первого элемента, по которому выполняется предикат.
        /// <para>Если ни один элемент не подходит, то возвращается индекс '-1'</para>>
        /// </summary>
        /// <typeparam name="TItem">Должен быть отсортирован!</typeparam>
        internal static int FirstIndex<TItem>(this IEnumerable<TItem> items, Func<TItem, bool> predicate) {
            using (var enumerator = items.GetEnumerator()) {
                if (!enumerator.MoveNext()) {
                    throw new InvalidOperationException("Collection is empty.");
                }

                int index = 0;
                do {
                    if (predicate(enumerator.Current)) {
                        return index;
                    }
                    index++;
                } while (enumerator.MoveNext());

                return -1;
            }
        }

        /// <summary>
        /// Возвращает элемент по минимальному значению пердиката
        /// </summary>
        internal static TItem MinByKey<TItem, TKey>(this IEnumerable<TItem> items, Func<TItem, TKey> keySelector) {
            using (var enumerator = items.GetEnumerator()) {
                var comparer = Comparer<TKey>.Default;

                if (!enumerator.MoveNext())
                    throw new InvalidOperationException("Collection is empty.");

                TItem minItem = enumerator.Current;
                TKey minKey = keySelector(minItem);


                while (enumerator.MoveNext()) {
                    TKey key = keySelector(enumerator.Current);

                    if (comparer.Compare(key, minKey) >= 0) {
                        continue;
                    }

                    minItem = enumerator.Current;
                    minKey = key;
                }

                return minItem;
            }
        }

        /// <summary>
        /// Возвращает элемент по максимальному значению пердиката
        /// </summary>
        internal static TItem MaxByKey<TItem, TKey>(this IEnumerable<TItem> items, Func<TItem, TKey> keySelector) {
            using (var enumerator = items.GetEnumerator()) {
                var comparer = Comparer<TKey>.Default;

                if (!enumerator.MoveNext())
                    throw new InvalidOperationException("Collection is empty.");

                TItem minItem = enumerator.Current;
                TKey minKey = keySelector(minItem);


                while (enumerator.MoveNext()) {
                    TKey key = keySelector(enumerator.Current);

                    if (comparer.Compare(key, minKey) <= 0) {
                        continue;
                    }

                    minItem = enumerator.Current;
                    minKey = key;
                }

                return minItem;
            }
        }

        /// <summary>
        /// Выбирает пару Минимальный-Максимальный элемент из коллекции
        /// </summary>
        /// <param name="collection">Коллекция элементов</param>
        /// <param name="selector">Предикат, выбирающий значение для сравнения</param>
        /// <param name="minValue">Минимальное значение. На Старте задается макисмально возможным, чтобы для него последовательность сходилась в сторону уменьшения</param>
        /// <param name="maxValue">Максимальное значение. На Старте задается минимально возможным, чтобы для него последовательность сходилась в сторону увеличения</param>
        /// <typeparam name="T">Тип элемента коллекции</typeparam>
        /// <typeparam name="TCompare">Тип занчения сравнения</typeparam>
        /// <returns></returns>
        internal static (T MinElemen, T MaxElement) GetMinMax<T, TCompare>(this IEnumerable<T> collection, Func<T, TCompare> selector, TCompare minValue, TCompare maxValue) where TCompare : IComparable {
            T minElement = default;
            T maxElement = default;
            foreach (var element in collection) {
                var value = selector(element);
                if (minValue.CompareTo(value) >= 0) {
                    minElement = element;
                    minValue = value;
                }

                if (maxValue.CompareTo(value) <= 0) {
                    maxElement = element;
                    maxValue = value;
                }
            }

            return (minElement, maxElement);
        }


        /// <summary>
        /// Возвращает случайные елемент из последовательности 
        /// </summary>
        internal static T GetRandom<T>(this IEnumerable<T> enumeration) {
            var collection = (enumeration as IList<T>) ?? enumeration.ToList();
            var index = UnityEngine.Random.Range(0, collection.Count);
            return collection[index];
        }

        /// <summary>
        /// Возвращает, включен ли элемент в последовательсность 
        /// </summary>
        internal static bool IsOneOf<T>(this T value, IEnumerable<T> enumeration) {
            return enumeration.Any(e => e.Equals(value));
        }

        /// <summary>
        /// Возвращает, включен ли элемент в последовательсность 
        /// </summary>
        internal static bool IsOneOf<T>(this T value, params T[] elements) {
            return elements.Any(e => e.Equals(value));
        }

        /// <summary>
        /// Возвращает первый попавшийся элемент из пары "Ключ-Значение" 
        /// </summary>
        internal static TValue Get<TKey, TValue>(this IEnumerable<SerializableKeyValuePair<TKey, TValue>> enumeration, TKey key) {
            return enumeration.First(e => e.Key.Equals(key)).Value;
        }

        /// <summary>
        /// Рефлексивный способ преобразовать `IEnumerable` в `Array` определенного типа
        /// </summary>
        internal static Array ToArray(this IEnumerable source, Type type) {
            //var param = Expression.Parameter(typeof(IEnumerable), nameof(source));
            //var cast = Expression.Call(typeof(Enumerable), nameof(Enumerable.Cast), new[] {type}, param);
            //var toArray = Expression.Call(typeof(Enumerable), nameof(Enumerable.ToArray), new[] {type}, cast);
            //var lambda = Expression.Lambda<Func<IEnumerable, Array>>(toArray, param).Compile();

            var src = ((IEnumerable<object>)source);
            var srcArray = src.ToArray();

            Array filledArray = Array.CreateInstance(type, srcArray.Length);
            Array.Copy(srcArray, filledArray, srcArray.Length);

            return filledArray;
        }

        /// <summary>
        /// Собирает все перечисления в один массив определенного типа 
        /// </summary>
        internal static Array JoinToArray(Type type, params IEnumerable[] sources) {
            if (sources.Length == 0) {
                throw new ArgumentOutOfRangeException(nameof(sources));
            }

            IList list = new ArrayList();
            foreach (var source in sources) {
                list.AddRange(source);
            }

            return list.ToArray(type);
        }

        internal static Dictionary<TNewKey, TValue> ToDictionary<TNewKey, TKey, TValue>(this IDictionary<TKey, TValue> source, Func<TKey, TNewKey> keySelector) {
            return source.ToDictionary(kvp => keySelector(kvp.Key), kvp => kvp.Value);
        }

        internal static Dictionary<TKey, TNewValue> ToDictionary<TNewValue, TKey, TValue>(this IDictionary<TKey, TValue> source, Func<TValue, TNewValue> valueSelector) {
            return source.ToDictionary(kvp => kvp.Key, kvp => valueSelector(kvp.Value));
        }

        internal static Dictionary<TSource, TValue> ToDictionary<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> valueSelector) {
            return source.ToDictionary(e => e, valueSelector);
        }

        internal static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) {
            return source.ToDictionary(e => e.Key, e => e.Value);
        }

        /// <summary>
        /// Перемешивает массив/лист.
        /// </summary>
        internal static void Shuffle<T>(this IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                n--;
                int k = UnityEngine.Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Возвращает максимальный элемент последовательности.
        /// Если последовательность пустая, возвращает дефолтное значение.
        /// </summary>
        internal static V MaxOrDefault<T, V>(this IEnumerable<T> enumerable, Func<T, V> selector) {
            V max = default;
            foreach (var x in enumerable) {
                V item = selector(x);
                if (Comparer.Default.Compare(item, max) > 0) {
                    max = item;
                }
            }
            return max;
        }

        /// <summary>
        /// Удаляет первый элемент из списка и возвращает его, если таковой есть
        /// </summary>
        internal static bool TryDequeue<T>(this LinkedList<T> source, out T value) {
            if (source.Count == 0) {
                value = default;
                return false;
            }

            value = source.First.Value;
            source.RemoveFirst();
            return true;
        }

        /// <summary>
        /// Удаляет элемент по предикату
        /// </summary>
        internal static bool RemoveElement<T>(this LinkedList<T> source, Func<T, bool> predicate) {
            if (source.Count == 0) {
                return false;
            }

            var foundNode = source.FirstOrDefault(predicate);
            if (foundNode == null) {
                return false;
            }

            return source.Remove(foundNode);
        }

        internal static bool TryAdd<T>(this ICollection<T> collection, T value) {
            if (collection.Contains(value)) {
                return false;
            }
            collection.Add(value);
            return true;
        }

        internal static bool TryRemove<T>(this ICollection<T> collection, T value) {
            if (!collection.Contains(value)) {
                return false;
            }
            collection.Remove(value);
            return true;
        }

        internal static bool TryRemoveByKey<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key) {
            if (!collection.ContainsKey(key)) {
                return false;
            }
            collection.Remove(key);
            return true;
        }
    }
}