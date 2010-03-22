using System.Collections.Generic;
using System.Linq;

namespace NSubstitute
{
    public class AllCallMatcher : ICallMatcher
    {
        readonly IEnumerable<ICallMatcher> _callMatchers;

        public AllCallMatcher(IEnumerable<ICallMatcher> callMatchers)
        {
            _callMatchers = callMatchers;
        }

        public bool IsMatch(ICall first, ICall second)
        {
            return _callMatchers.All(x => x.IsMatch(first, second));
        }

        public bool IsMatch(ICall call, ICallSpecification callSpecification)
        {
            return _callMatchers.All(x => x.IsMatch(call, callSpecification));
        }
    }
}