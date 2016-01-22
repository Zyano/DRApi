using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRApi.SystemStatus {
    public class SystemStatus {
        public string Key { get; set; }
        public SysValue Value { get; set; }
    }

    public class SysValue {
        public bool Passed { get; set; }
        public TimeSpan Duration { get; set; }
        public string Message { get; set; }
    }
}
