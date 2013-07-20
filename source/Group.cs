
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//


using Awesomium.Core;

namespace PaperJS
{
    /// <summary>
    /// A Group is a collection of items. When you transform a Group, its children 
    /// are treated as a single unit without changing their relative positions.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/group/
    /// </remarks>
    public class Group : Item
    {
        public Group(Item[] children)
            : base(CreateObjectByTypeName("paper.Group", new object[] { children }))
        {
        }

        public Group(JSObject jsGroup)
            : base(jsGroup)
        {
        }

        /// <summary>
        /// Specifies whether the group applies transformations directly to its children, 
        /// or wether they are to be stored in its item.matrix
        /// </summary>
        public bool TransformContent
        {
            get
            {
                JSValue jsTransformContent = _jsObject["transformContent"];
                return (bool)jsTransformContent;
            }
            set
            {
                _jsObject["transformContent"] = value;
            }
        }

        /// <summary>
        /// Specifies whether the group item is to be clipped.
        /// When setting to true, the first child in the group is automatically 
        /// defined as the clipping mask.
        /// </summary>
        public bool Clipped
        {
            get
            {
                JSValue jsClipped = _jsObject["clipped"];
                return (bool)jsClipped;
            }
            set
            {
                _jsObject["clipped"] = value;
            }
        }
    }
}
