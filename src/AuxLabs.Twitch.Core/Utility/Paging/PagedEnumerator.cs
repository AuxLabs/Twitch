// https://github.com/discord-net/Discord.Net/blob/75ae48830e256086be58e25e1534358572d9dd7a/src/Discord.Net.Core/Utils/Paging/PagedEnumerator.cs

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AuxLabs.Twitch
{
    internal class PagedAsyncEnumerable<T> : IAsyncEnumerable<IReadOnlyCollection<T>>
    {
        public int PageSize { get; }

        private readonly int? _count;
        private readonly Func<PageInfo, CancellationToken, Task<(IReadOnlyCollection<T> Data, string Cursor)>> _getPage;

        public PagedAsyncEnumerable(int pageSize, Func<PageInfo, CancellationToken, Task<(IReadOnlyCollection<T> Data, string Cursor)>> getPage,
            int? count = null)
        {
            PageSize = pageSize;
            _count = count;

            _getPage = getPage;
        }

        public IAsyncEnumerator<IReadOnlyCollection<T>> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken()) => new Enumerator(this, cancellationToken);
        internal class Enumerator : IAsyncEnumerator<IReadOnlyCollection<T>>
        {
            private readonly PagedAsyncEnumerable<T> _source;
            private readonly CancellationToken _token;
            private readonly PageInfo _info;

            public IReadOnlyCollection<T> Current { get; private set; }

            public Enumerator(PagedAsyncEnumerable<T> source, CancellationToken token)
            {
                _source = source;
                _token = token;
                _info = new PageInfo(source._count, source.PageSize);
            }

            public async ValueTask<bool> MoveNextAsync()
            {
                if (_info.Remaining == 0)
                    return false;

                var (Data, Cursor) = await _source._getPage(_info, _token).ConfigureAwait(false);
                Current = new Page<T>(_info, Data);

                _info.Page++;
                if (_info.Remaining != null)
                {
                    if (Current.Count >= _info.Remaining)
                        _info.Remaining = 0;
                    else
                        _info.Remaining -= Current.Count;
                }
                else
                {
                    if (Current.Count == 0)
                        _info.Remaining = 0;
                }
                _info.PageSize = _info.Remaining != null ? Math.Min(_info.Remaining.Value, _source.PageSize) : _source.PageSize;

                if (_info.Remaining != 0)
                {
                    if (Data.Count != _info.PageSize) 
                        _info.Remaining = 0;
                    _info.Cursor = Cursor;
                }

                return true;
            }

            public ValueTask DisposeAsync()
            {
                Current = null;
                return default;
            }
        }
    }
}
