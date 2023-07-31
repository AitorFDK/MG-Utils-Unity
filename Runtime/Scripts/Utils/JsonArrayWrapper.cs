using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MengiGames.Utils
{
    [Serializable]
    public class JsonArrayWrapper<T>
    {
        public T[] array;

        public JsonArrayWrapper(T[] array)
        {
            this.array = array;
        }

        public static T[] FromJson(string json)
        {
            string aux = "{ \"array\": " + json + "}";
            return JsonUtility.FromJson<JsonArrayWrapper<T>>(aux).array;
        }

        public static string ToJson(T[] array)
        {
            var obj = new JsonArrayWrapper<T>(array);
            return JsonUtility.ToJson(obj);
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
}