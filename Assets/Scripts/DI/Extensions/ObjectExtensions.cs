using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities.Extensions {
    internal static class ObjectExtensions {

        /// <summary>
        /// Возвращает все объекты типа T на сцене.
        /// Может искать не только UnityEngine.Object, но и интерфейсы
        /// </summary>
        internal static IEnumerable<T> FindInScene<T>(bool includeInactive = false) {
            var activeScenes = SceneManager.sceneCount;
            for (int index = 0; index < activeScenes; index++) {
                var componentEnumeration = SceneManager
                                           .GetSceneAt(index)
                                           .GetRootGameObjects()
                                           .SelectMany(go => go.GetComponentsInChildren<T>(includeInactive));

                foreach (var component in componentEnumeration) {
                    yield return component;
                }
            }
        }

        /// <summary>
        /// Возвращает первый попавшийся объект типа T
        /// Может искать не только UnityEngine.Object, но и интерфейсы
        /// </summary>
        internal static T FindSingleInScene<T>(bool includeInactive = false) where T : Component {
            return (T)FindSingleInSceneReflection(typeof(T), includeInactive);
        }

        /// <summary>
        /// Возвращает первый попавшийся объект типа T
        /// Может искать не только UnityEngine.Object, но и интерфейсы
        /// </summary>
        internal static Component FindSingleInSceneReflection(Type type, bool includeInactive = false) {
            var activeScenes = SceneManager.sceneCount;

            for (int index = 0; index < activeScenes; index++) {
                var rootObjects = SceneManager.GetSceneAt(index).GetRootGameObjects();
                foreach (var rootObject in rootObjects) {
                    var components = rootObject.GetComponentsInChildren(type, includeInactive);
                    if (components.Length > 0) {
                        return components[0];
                    }
                }
            }
            return default;
        }

        internal static string GetFullName(this Component component) {
            var stack = new Stack<string>();
            var parent = component.transform;
            do {
                stack.Push(parent.name);
                parent = parent.parent;
            } while (parent != null);

            return string.Join(".", stack);
        }
    }
}