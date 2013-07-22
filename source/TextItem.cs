
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaperJS
{
    /// <summary>
    /// The TextItem type allows you to create typography. Its functionality 
    /// is inherited by different text item types such as PointText, and 
    /// AreaText (coming soon). They each add a layer of functionality that is 
    /// unique to their type, but share the underlying properties and 
    /// functions that they inherit from TextItem.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/textitem/
    /// </remarks>
    public class TextItem : Item
    {
        protected TextItem(JSObject jsTextItem)
            : base(jsTextItem)
        {
        }

        /// <summary>
        /// The text contents of the text item.
        /// </summary>
        public string Content
        {
            get
            {
                JSValue jsContent = _jsObject["content"];
                return (string)jsContent;
            }
            set
            {
                _jsObject["content"] = value;
            }
        }
    }
}
