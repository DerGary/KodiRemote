using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KodiRemote.Code.Utils {
    /// <summary>
    /// Used to Serialize an objec to a string
    /// </summary>
    public static class JsonSerializer {
        /// <summary>
        /// Serializes the given object and returns the representing json string
        /// Only works with Classes that define a DataContract
        /// </summary>
        /// <param name="obj">the object that shall be serialized</param>
        /// <param name="settings">Settings the Json Serializer can use to serialize for example type definitions for non default types that are provided as object</param>
        /// <returns>a json string representing the given object</returns>
        public static string ToJson(object obj, DataContractJsonSerializerSettings settings = null) {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer serializer = null;
            if (settings != null) {
                serializer = new DataContractJsonSerializer(obj.GetType(), settings);
            } else {
                serializer = new DataContractJsonSerializer(obj.GetType());
            }
            serializer.WriteObject(stream, obj);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream)) {
                return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// Deserializes the given json string to an object of the given type T
        /// The Type has to have a Data Contract
        /// </summary>
        /// <typeparam name="T">the return type</typeparam>
        /// <param name="json">the json string representing the object</param>
        /// <param name="settings">Settings the Json Serializer can use to deserialize for example type definitions for non default types that are provided as object</param>
        /// <returns>the deserialized object</returns>
        public static T FromJson<T>(string json, DataContractJsonSerializerSettings settings = null) where T : new() {
            if (string.IsNullOrEmpty(json))
                return new T();

            var bytes = Encoding.Unicode.GetBytes(json);
            using (MemoryStream stream = new MemoryStream(bytes)) {
                DataContractJsonSerializer serializer = null;
                if (settings != null) {
                    serializer = new DataContractJsonSerializer(typeof(T), settings);
                } else {
                    serializer = new DataContractJsonSerializer(typeof(T));
                }
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
