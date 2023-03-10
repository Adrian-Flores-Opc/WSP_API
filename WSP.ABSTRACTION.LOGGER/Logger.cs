using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSP.ABSTRACTION.LOGGER
{
    public class Logger : ILoggerInfo
    {
        private static string? _pathLogFile;
        public const string header = "INFO: {0} DETALLE: {1}";
        private readonly string? _user;

        public Logger(string pathLogFile, string level, string user, int limit)
        {
            Create(pathLogFile, level, limit);
            this._user = user;
        }
        private static void Create(string pathLogFile, string level, int limit)
        {
            switch (level)
            {
                case "INFORMATION":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Information()
                        .CreateLogger();
                    break;
                case "FATAL":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Fatal()
                        .CreateLogger();
                    break;
                case "WARNING":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Warning()
                        .CreateLogger();
                    break;
                case "ERROR":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Error()
                        .CreateLogger();
                    break;
                case "DEBUG":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Debug()
                        .CreateLogger();
                    break;
                default:
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .WriteTo.Console()
                        .MinimumLevel.Verbose()
                        .CreateLogger();
                    break;
            }
        }
        private static string GetStackTraceInfo()
        {
            var stackFrame = new StackTrace().GetFrame(2);
            string methodName = stackFrame.GetMethod().Name;
            string className = stackFrame.GetMethod().ReflectedType.FullName;
            return string.Format("Class: \"{0}\" Method: \"{1}\"", className, methodName);
        }

        public void Information(string format, params object[] objects)
        {
            string location = GetStackTraceInfo();
            string message = string.Format(format, objects);
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Information(string.Format(_header, location, message));
        }
        public void Information(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Information(string.Format(_header, location, message));
        }

        public void Fatal(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Fatal(string.Format(_header, location, message));
        }
        public void Fatal(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Fatal(string.Format(_header, location, message));
        }

        public void Warning(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Warning(string.Format(_header, location, message));
        }
        public void Warning(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Warning(string.Format(_header, location, message));
        }

        public void Error(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Error(string.Format(_header, location, message));
        }
        public void Error(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Error(string.Format(_header, location, message));
        }

        public void Debug(string format, params object[] objects)
        {
            string location = GetStackTraceInfo();
            string message = string.Format(format, objects);
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Debug(string.Format(_header, location, message));
        }
        public void Debug(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Debug(string.Format(_header, location, message));
        }

        public void Verbose(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Verbose(string.Format(_header, location, message));
        }
        public void Verbose(string message)
        {
            string location = GetStackTraceInfo();
            string _header = header;
            if (!string.IsNullOrEmpty(_user))
                _header = $"USER: {_user} " + header;
            Log.Verbose(string.Format(_header, location, message));
        }
    }
}
