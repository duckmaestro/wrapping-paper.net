
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
    /// The Segment object represents the points of a path through which its 
    /// Curve objects pass. The segments of a path can be accessed through 
    /// its path.segments array.
    /// 
    /// Each segment consists of an anchor point (segment.point) and 
    /// optionaly an incoming and an outgoing handle (segment.handleIn and 
    /// segment.handleOut), describing the tangents of the two Curve objects 
    /// that are connected by this segment.
    /// </summary>
    /// <remarks>
    /// Documentation taken from: http://paperjs.org/reference/segment/
    /// </remarks>
    public class Segment : BaseWrapper
    {
        public Segment(JSObject jsSegment)
            : base(jsSegment)
        {
        }

        /// <summary>
        /// The anchor point of the segment.
        /// </summary>
        public Point Point
        {
            get
            {
                return Property<Point>("point");
            }
            set
            {
                Property("point", value);
            }
        }

        /// <summary>
        /// The handle point relative to the anchor point of the segment that 
        /// describes the in tangent of the segment.
        /// </summary>
        public Point HandleIn
        {
            get
            {
                return Property<Point>("handleIn");
            }
            set
            {
                Property("handleIn", value);
            }
        }

        /// <summary>
        /// The handle point relative to the anchor point of the segment that 
        /// describes the out tangent of the segment.
        /// </summary>
        public Point HandleOut
        {
            get
            {
                return Property<Point>("handleOut");
            }
            set
            {
                Property("handleOut", value);
            }
        }
    }
}
