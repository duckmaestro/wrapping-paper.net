
//    This file is part of Wrapping-Paper.NET.
//    Copyright (c) 2013 Clifford Champion
//
//    Distributed for use only under the MIT license. 
//    See LICENSE file for details.
//

using Awesomium.Core;
using System.Collections.Generic;
using System.Linq;

namespace PaperJS
{
    /// <summary>
    /// The Path item represents a path in a Paper.js project.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/path/
    /// </remarks>
    public class Path : PathItem
    {
        public Path() :
            base(CreateObjectByTypeName("paper.Path", null))
        {

        }

        public Path(JSObject jsPath)
            : base(jsPath)
        {
        }

        /// <summary>
        /// Creates a circle shaped Path item.
        /// </summary>
        public static Path Circle(Point center, double radius)
        {
            JSObject jsCircle = CreateObjectByMethod(
                "paper.Path.Circle",
                new object[] { center, radius });
            return new Path(jsCircle);
        }

        /// <summary>
        /// Creates a Path item with two anchor points forming a line.
        /// </summary>
        public static Path Line(Point from, Point to)
        {
            JSObject jsLine = CreateObjectByMethod(
                "paper.Path.Line",
                new object[] { from, to });
            return new Path(jsLine);
        }

        /// <summary>
        /// Creates a regular polygon shaped Path item.
        /// </summary>
        public static Path RegularPolygon(Point center, int sides, double radius)
        {
            JSObject jsPolygon = CreateObjectByMethod(
                "paper.Path.RegularPolygon",
                new object[] { center, sides, radius });
            return new Path(jsPolygon);
        }

        /// <summary>
        /// The segments contained within the path.
        /// </summary>
        public IEnumerable<Segment> Segments
        {
            get
            {
                JSValue[] jsChildren = (JSValue[])Property("segments");
                return jsChildren.Select(c => (JSObject)c).Select(c => new Segment(c));
            }
        }

        /// <summary>
        /// The first Segment contained within the path.
        /// Read only.
        /// </summary>
        public Segment FirstSegment
        {
            get
            {
                return Property<Segment>("firstSegment");
            }
            set
            {
                Property("firstSegment", value);
            }
        }
    }
}
