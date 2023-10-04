using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxIssue
{
    public class User
    {
        [Reactive]
        public string Name { get; set; }
        [Reactive]
        public int Age { get; set; }
    }
}
