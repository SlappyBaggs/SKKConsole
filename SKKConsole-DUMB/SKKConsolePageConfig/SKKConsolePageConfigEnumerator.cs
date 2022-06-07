#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Collections;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    public class ConsolePageConfigEnumerator : IEnumerator<ConsolePageConfig>
    {
        private ConsolePageConfigCollection _collection;
        private int _index;
        private ConsolePageConfig? _current;

        public ConsolePageConfigEnumerator(List<ConsolePageConfig> collection) : this(new ConsolePageConfigCollection(collection))
        {
        }

        public ConsolePageConfigEnumerator(ConsolePageConfigCollection collection)
        {
            _collection = collection;
            _index = -1;
            _current = default(ConsolePageConfig);
        }

        public ConsolePageConfig Current => _current ?? throw new InvalidOperationException("You cannot access 'Current' until a successful call to 'MoveNext' is made");

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++_index >= _collection.Count)
            {
                _current = default(ConsolePageConfig);
                return false;
            }
            _current = _collection[_index];
            return true;
        }

        public void Reset()
        {
            _index = -1;
            _current = default(ConsolePageConfig);
        }
    }
}
