using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace galdino.humanResource.domain.Enumeration.Base
{
    public class BaseEnumeration : IComparable
    {
        #region .::Cosntructor
        private readonly int _valor;
        private readonly string _nome;

        protected BaseEnumeration()
        {
        } 
        #endregion

        #region .::Methods
        protected BaseEnumeration(int valor, string nome)
        {
            _valor = valor;
            _nome = nome;
        }

        public int Value
        {
            get { return _valor; }
        }

        public string DisplayName
        {
            get { return _nome; }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : BaseEnumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();

                if (info.GetValue(instance) is T locatedValue)
                {
                    yield return locatedValue;
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseEnumeration otherValue))
                return false;

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = _valor.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return _valor.GetHashCode();
        }

        public static int AbsoluteDifference(BaseEnumeration firstValue, BaseEnumeration secondValue)
        {
            var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
            return absoluteDifference;
        }

        public static T FromValue<T>(int value) where T : BaseEnumeration, new()
        {
            var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
            return matchingItem;
        }

        public static T FromDisplayName<T>(string displayName) where T : BaseEnumeration, new()
        {
            var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
            return matchingItem;
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : BaseEnumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = $"'{value}' nao é valido {description} em {typeof(T)}";
                throw new ApplicationException(message);
            }

            return matchingItem;
        }

        public int CompareTo(object other)
        {
            return Value.CompareTo(((BaseEnumeration)other).Value);
        } 
        #endregion
    }
}

