using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Utilities.Extensions {
    internal static class ReflectionExtensions {
        private const BindingFlags BINDING_FILTER = BindingFlags.NonPublic | BindingFlags.Instance;

        private static readonly Type ListType = typeof(List<>);
        private static readonly Type DictionaryType = typeof(Dictionary<,>);
        private static readonly Type IEnumerableType = typeof(IEnumerable<>);
        private static readonly Type ICollectionType = typeof(ICollection);
        private static readonly Type IListType = typeof(IList);

        /// <summary>
        /// �������� �� ��� ����������� 
        /// </summary>
        internal static bool IsMultiple(this Type type) => type.IsArray || IsGenericEnumerable(type);

        /// <summary>
        /// �������� �� ��� IEnumerable 
        /// </summary>
        internal static bool IsGenericEnumerable(this Type type) {
            const string name = "IEnumerable";
            return type.IsGenericType && type.GetInterfaces().Any(ti => ti == IEnumerableType || ti.Name == name);
        }

        /// <summary>
        /// �������� �� ��� ICollection. 
        /// </summary>
        internal static bool IsICollection(this Type type) {
            return ICollectionType.IsAssignableFrom(type);
        }

        /// <summary>
        /// �������� �� ��� IList. 
        /// </summary>
        internal static bool IsIList(this Type type) {
            return IListType.IsAssignableFrom(type);
        }

        /// <summary>
        /// �������� �� ��� List 
        /// </summary>
        internal static bool IsList(this Type type) {
            return type.IsGenericType && type.GetGenericTypeDefinition() == ListType;
        }

        /// <summary>
        /// �������� �� ��� Dictionary. 
        /// </summary>
        internal static bool IsDictionary(this Type type) {
            return type.IsGenericType && type.GetGenericTypeDefinition() == DictionaryType;
        }

        /// <summary>
        /// ���� ��� ����, ����������� ���������
        /// </summary>
        /// <returns></returns>
        internal static IEnumerable<Type> FindAssignableTypes(this Type type) {
            var assembly = type.Assembly;

            var observables = assembly.GetTypes()
                .Where(x => type.IsAssignableFrom(x));

            return observables;
        }

        /// <summary>
        /// ���� ��� ����, ���������� ���������.
        /// </summary>
        internal static IEnumerable<Type> FindTypesWithAttribute(this Type type, Type attributeType) {
            return type.Assembly
                .GetTypes()
                .Where(x => Attribute.IsDefined(x, attributeType));
        }

        /// <summary>
        /// ������� ��� ���� ����, ���������� ��������� ���������� ����
        /// </summary>
        internal static IEnumerable<FieldInfo> GetFieldsWithAttribute(this Type type, Type attributeType) {
            var fields = type.GetFields(BINDING_FILTER)
                .Where(x => Attribute.IsDefined(x, attributeType));

            return fields;
        }

        /// <summary>
        /// ������� ��� ��������, ���������� ��������� ���������� ����.
        /// </summary>
        internal static IEnumerable<PropertyInfo> GetPropertiesWithAttribute(this Type type, Type attributeType) {
            var properties = type.GetProperties(BINDING_FILTER)
                .Where(x => Attribute.IsDefined(x, attributeType));

            return properties;
        }

        /// <summary>
        /// ���������� ��� ��������� ���������. ������������ �������.
        /// </summary>
        internal static Type GetCollectionGenericType(this Type type) {
            return type.IsGenericType
              ? type.GenericTypeArguments[0]
              : type.GetElementType();
        }

        /// <summary>
        /// ���������� �������.
        /// </summary>
        internal static T GetAttribute<T>(this Type type) where T : Attribute {
            return (T)Attribute.GetCustomAttribute(type, typeof(T));
        }

        /// <summary>
        /// ���������� ��� ������, �������������� �� ����������.
        /// </summary>
        internal static IEnumerable<Type> GetInheritedTypes(this Type type) {
            return type.Assembly.GetTypes()
                .Where(x => x.IsSubclassOf(type) && x.IsClass && !x.IsAbstract);
        }
    }
}