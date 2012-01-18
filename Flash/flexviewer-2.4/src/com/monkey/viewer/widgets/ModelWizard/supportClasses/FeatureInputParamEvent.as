////////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2011 Esri
//
// All rights reserved under the copyright laws of the United States.
// You may freely redistribute and use this software, with or
// without modification, provided you include the original copyright
// and use restrictions.  See use restrictions in the file:
// <install location>/License.txt
//
////////////////////////////////////////////////////////////////////////////////
package widgets.ModelWizard.supportClasses
{

import flash.events.Event;

import widgets.ModelWizard.parameters.IFeatureParameter;

public class FeatureInputParamEvent extends Event
{
    public static const DRAW:String = "drawFeature";
    public static const CLEAR:String = "clearFeature";

    public var featureParam:IFeatureParameter;
    public var drawType:String;

    public function FeatureInputParamEvent(type:String, featureParam:IFeatureParameter, drawType:String = null, bubbles:Boolean = false, cancelable:Boolean = false)
    {
        this.featureParam = featureParam;
        this.drawType = drawType;
        super(type, bubbles, cancelable);
    }

    override public function clone():Event
    {
        return new FeatureInputParamEvent(type, featureParam, drawType, bubbles, cancelable);
    }
}

}
