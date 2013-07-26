
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PaperJS
{
    public class BaseWrapper
    {
        protected JSObject _jsObject;
        private static IWebView _webView;
        private static readonly string WrappingPaperObjectNameJS = "wrappingpaper";

        protected static PaperScope Get(IWebView webView)
        {
            if (webView == null)
            {
                throw new ArgumentNullException();
            }

            _webView = webView;

            JSObject jsPaper = webView.ExecuteJavascriptWithResult("paper");
            if (jsPaper == null)
            {
                throw new InvalidOperationException("paper.js does not appear to have been loaded.");
            }
            PaperScope paper = new PaperScope(jsPaper);
            return paper;
        }

        protected void Property(string name, JSValue value)
        {
            JSObject target = this;
            JSObject jsClassFactory = _webView.ExecuteJavascriptWithResult(WrappingPaperObjectNameJS);
            JSValue message = jsClassFactory.Invoke("property", target, name, value);

            if (message.IsBoolean)
            {
                bool success = message;
                if (success)
                {
                    return;
                }
                else
                {
                    throw new Exception("Unknown error creating object.");
                }
            }
            else if (message.IsString)
            {
                string error = message;
                throw new Exception(error);
            }
            else
            {
                throw new Exception("Unknown error creating object.");
            }
        }

        protected JSValue Property(string name)
        {
            JSObject target = this;
            JSObject jsClassFactory = _webView.ExecuteJavascriptWithResult(WrappingPaperObjectNameJS);
            JSValue message = jsClassFactory.Invoke("property", target, name);

            if (message.IsBoolean)
            {
                bool success = message;
                if (success)
                {
                    return jsClassFactory["outbox"];
                }
                else
                {
                    throw new Exception("Unknown error creating object.");
                }
            }
            else if (message.IsString)
            {
                string error = message;
                throw new Exception(error);
            }
            else
            {
                throw new Exception("Unknown error creating object.");
            }
        }

        public static JSObject CreateObjectByTypeName(string typeName, object[] arguments)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException();
            }

            JSObject jsClassFactory = _webView.ExecuteJavascriptWithResult(WrappingPaperObjectNameJS);
            if (jsClassFactory == null)
            {
                throw new InvalidOperationException("wrapping-paper.js does not appear to have loaded.");
            }

            JSValue[] args2 = new JSValue[] { typeName, ConvertArguments(arguments) };

            JSValue message = jsClassFactory.Invoke("createObjectByName", args2);

            if (message.IsBoolean)
            {
                bool success = message;
                if (success)
                {
                    return (JSObject)jsClassFactory["outbox"];
                }
                else
                {
                    throw new Exception("Unknown error creating object.");
                }
            }
            else if (message.IsString)
            {
                string error = message;
                throw new Exception(error);
            }
            else
            {
                throw new Exception("Unknown error creating object.");
            }

        }

        public static JSObject CreateObjectByMethod(string methodName, object[] arguments)
        {
            if (_webView == null)
            {
                throw new InvalidOperationException();
            }

            JSObject jsClassFactory = _webView.ExecuteJavascriptWithResult(WrappingPaperObjectNameJS);
            if (jsClassFactory == null)
            {
                throw new InvalidOperationException("wrapping-paper.js does not appear to have loaded.");
            }

            JSValue[] args2 = new JSValue[] { methodName, ConvertArguments(arguments) };

            JSValue message = jsClassFactory.Invoke("createObjectByMethod", args2);

            if (message.IsBoolean)
            {
                bool success = message;
                if (success)
                {
                    return (JSObject)jsClassFactory["outbox"];
                }
                else
                {
                    throw new Exception("Unknown error creating object.");
                }
            }
            else if (message.IsString)
            {
                var error0 = jsClassFactory.GetLastError();
                string error = message;
                throw new Exception(error);
            }
            else
            {
                throw new Exception("Unknown error creating object.");
            }
        }

        private static JSValue[] ConvertArguments(IEnumerable<Object> arguments)
        {
            if (arguments == null)
            {
                return null;
            }

            List<JSValue> converted = new List<JSValue>(arguments.Count());
            foreach (object a in arguments)
            {
                Type type = a.GetType();
                if (typeof(JSValue).IsAssignableFrom(type))
                {
                    converted.Add((JSValue)a);
                }
                else if (typeof(PaperJS.BaseWrapper).IsAssignableFrom(type))
                {
                    converted.Add((PaperJS.BaseWrapper)a);
                }
                else if (type == typeof(double))
                {
                    converted.Add(new JSValue((double)a));
                }
                else if (type == typeof(string))
                {
                    converted.Add(new JSValue((string)a));
                }
                else if (type.IsArray)
                {
                    IEnumerable aAsEnumerable = (IEnumerable)a;
                    JSValue[] convertedArray = ConvertArguments(aAsEnumerable.Cast<Object>());
                }
                else
                {
                    throw new ArgumentException(
                        string.Format("Argument of type {0} not supported.", type.FullName));
                }
            }
            return converted.ToArray();
        }


        public BaseWrapper(JSObject jsObject)
        {
            if (jsObject == null)
            {
                throw new ArgumentNullException("JavaScript object missing.");
            }
            _jsObject = jsObject;
        }

        public static implicit operator JSValue(BaseWrapper item)
        {
            if (item == null)
            {
                return JSValue.Null;
            }
            else
            {
                return item._jsObject;
            }
        }

        public static implicit operator JSObject(BaseWrapper item)
        {
            return item._jsObject;
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            View otherView = (View)other;
            return this._jsObject.Equals(otherView._jsObject);
        }

        public override int GetHashCode()
        {
            return _jsObject.GetHashCode();
        }

        public static bool operator ==(BaseWrapper view1, BaseWrapper view2)
        {
            if ((object)view1 == (object)view2)
            {
                return true;
            }
            else
            {
                return view1.Equals(view2);
            }
        }

        public static bool operator !=(BaseWrapper view1, BaseWrapper view2)
        {
            if ((object)view1 == (object)view2)
            {
                return false;
            }
            else
            {
                return !view1.Equals(view2);
            }
        }

    }
}
