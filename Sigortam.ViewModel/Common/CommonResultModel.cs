using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.ViewModel.Common
{
    public class CommonResultModel<T>
    {
        public bool State { get; set; }
        public string Description { get; set; }
        public T DataResult { get; set; }
    }
    public class CommonResultModel
    {
        public bool State { get; set; }
        public string Description { get; set; }
        public object DataResult { get; set; }
    }
}
