using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Utils {
    public class DatabaseLoggerProvider : ILoggerProvider {
        DatabaseLogger logger;
        public ILogger CreateLogger(string categoryName) {
            logger = new DatabaseLogger();
            return logger;
        }

        public void Dispose() {
            logger = null;
        }
    }
    public class DatabaseLogger : ILogger {
        public IDisposable BeginScopeImpl(object state) {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return true;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter) {
            Debug.WriteLine(formatter(state, exception), "DB");
        }
    }
}
