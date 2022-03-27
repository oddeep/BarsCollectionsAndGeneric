using System;
using System.IO;
using System.Collections.Generic;

namespace BarsGeneric
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }

    class LocalFileLogger<T> : ILogger
    {
        private string _filePath;
        public LocalFileLogger(string filePath)
        {
            _filePath = filePath;
        }

        public void LogError(string message, Exception ex)
        {
            File.AppendAllText(_filePath, $"[Error] : [{typeof(T).Name}] : {message}.{ex.Message}\n");
        }

        public void LogInfo(string message)
        {
            File.AppendAllText(_filePath, $"[Info] : [{typeof(T).Name}] : {message}\n");
        }

        public void LogWarning(string message)
        {
            File.AppendAllText(_filePath, $"[Warning]  : [{typeof(T).Name}] : {message}\n");
        }
    }

    class EngineMaker
    {
        public int Power { get; set; }
    }

    class Compukter
    {
        public int Model { get; set; }
    }

    class Person
    {
        public string Name
        {
            get; set;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var personLogger = new LocalFileLogger<Person>(@"C:\app\log.txt");
            var compLogger = new LocalFileLogger<Compukter>(@"C:\app\log.txt");
            var engineLogger = new LocalFileLogger<EngineMaker>(@"C:\app\log.txt");

            personLogger.LogInfo("Информационное сообщение");
            personLogger.LogWarning("Предупреждение!");
            personLogger.LogError("Произошла ошибка", new SystemException());

            compLogger.LogInfo("Информационное сообщение");
            compLogger.LogWarning("Предупреждение!");
            compLogger.LogError("Произошла ошибка", new SystemException());

            engineLogger.LogInfo("Информационное сообщение");
            engineLogger.LogWarning("Предупреждение!");
            engineLogger.LogError("Произошла ошибка", new SystemException());
        }
    }
}