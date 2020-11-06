using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionEditorSamples
{
    public static class PageCache
    {
        // Expression Cache
        static string _expressionCache = "";
        static string _fieldCache = "";

        static public string GetCacheExpression()
        {
            return _expressionCache;
        }

        static public void SetCacheExpression(string expression)
        {
            _expressionCache = expression;
        }

        static public string GetCacheField()
        {
            return _fieldCache;
        }

        static public void SetCacheField(string field)
        {
            _fieldCache = field;
        }

    }
}
