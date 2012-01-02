package com.monkey.sample;
/**
 * @author monkey team
 * @version 0.1
 * @created 12-3-2011
 */

import com.monkey.core.InstanceManager;
import com.monkey.processing.IContext;
import com.monkey.runner.Runner;;

public class Sample {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int i = 2;
		switch(i){
		case 1:{
			sample1();
			}
			break;
		case 2:{
			sample2();
			}
			break;
		case 3:{
			sample3();
			}
			break;
		}
	}

	public static void sample1(){
		Runner runner = Runner.getInstance();
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));
	    String filePath = baseDir + "/config/models/" + "arcsample.xml";
	    String dataBase = baseDir.substring(0, baseDir.lastIndexOf("/")) + "/data";
	    String[] args = new String[6];
	    args[0] = dataBase + "\\shp\\Road_L.shp";
	    args[1] = dataBase + "\\Default.gdb\\RoadLBuffer";
	    args[2] = "5 Kilometers";
	    args[3] = "NAME";
	    args[4] = dataBase + "\\shp\\Lake_R.shp";
	    args[5] = dataBase + "\\Default.gdb\\RoadLakeClip";
		runner.runModelFile(filePath, args);
	}
	
	public static void sample2(){
		Runner runner = Runner.getInstance();
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));	    
		String dataBase = baseDir.substring(0, baseDir.lastIndexOf("/")) + "/data";
		
		String name = "Buffer_analysis";
		String[] args = new String[7];
		args[0] = dataBase + "\\shp\\Road_L.shp";
	    args[1] = dataBase + "\\Default.gdb\\RoadLBuffer";
	    args[2] = "5 Kilometers";
	    args[3] = "FULL";
	    args[4] = "ROUND";
	    args[5] = "LIST";
	    args[6] = "NAME";	    
	    if (!runner.runProcess(name, args)){
	    	System.out.println(name + " run failed");
	    }
	}
	
	public static void sample3(){
		String content = "<process type='FFD' stepByStep='false'>" + 
			"<head>" + 
				"<Identifier>arcsample</Identifier>" + 
				"<Title>ArcToolbox示例</Title>" + 
				"<Abstract>ArcToolbox示例</Abstract>" + 
				"<DataInputs>" +
					"<Input>" + 
						"<Identifier>in_features</Identifier>" +
						"<Title>Input Features</Title>" + 
						"<Abstract>The input point, line, or polygon features to be buffered.</Abstract>" +
						"<DataType>string</DataType>" + 
						"<Option>false</Option>" +
						"<Reference id='2' name='in_features'/>" +
					"</Input>" +
					"<Input>" +
						"<Identifier>temp_feature_class</Identifier>" +
						"<Title>Temp Feature Class</Title>" +
						"<Abstract>The feature class containing the output feature buffers.</Abstract>" +
						"<DataType>string</DataType>" +
						"<Option>false</Option>" +
						"<Reference id='2' name='out_feature_class' />" +
					"</Input>" +
					"<Input>" +
						"<Identifier>buffer_distance_or_field</Identifier>" +
						"<Title>Distance [value or field]</Title>" +
						"<Abstract>The distance around the input features in which buffer zones are created. Distances can be provided as either a value representing a linear distance or as a numeric field from the input features that contains the linear distances to buffer each feature.If the Distance linear units are not specified or are entered as Unknown, the linear unit of the input features' spatial reference is used.</Abstract>" +
						"<DataType>string</DataType>" +
						"<Option>false</Option>" +
						"<Reference id='2' name='buffer_distance_or_field' />" +
					"</Input>" +
					"<Input>" +
						"<Identifier>dissolve_field</Identifier>" +
						"<Title>Dissolve Field(s)</Title>" +
						"<Abstract>The list of field(s) from the input features on which to dissolve the output buffers. Any buffers sharing attribute values in the listed fields (carried over from the input features) are dissolved.</Abstract>" +
						"<DataType>string</DataType>" +
						"<Option>false</Option>" +
						"<Reference id='2' name='dissolve_field' />" +
					"</Input>" +
					"<Input>" +
						"<Identifier>clip_features</Identifier>" +
						"<Title>Input Features</Title>" +
						"<Abstract>The features to be clipped.</Abstract>" +
						"<DataType>string</DataType>" +
						"<Option>false</Option>" +
						"<Reference id='3' name='clip_features' />" +
					"</Input>" +
					"<Input>" +
						"<Identifier>out_feature_class</Identifier>" +
						"<Title>Output Featureclass</Title>" +
						"<Abstract>The feature class to be created.</Abstract>" +
						"<DataType>string</DataType>" +
						"<Option>false</Option>" +
						"<Reference id='3' name='out_feature_class'/>" +
					"</Input>" +		
				"</DataInputs>" +
				"<ProcessOutputs/>" +
			"</head>" +
			"<flow>" +    
				"<start id='1' name='start' siz='16' title='开始'/>" +
				"<operation id='2' abstract='道路缓冲区' name='Buffer_analysis' title='道路缓冲区'>" +
					"<inputs>" +
						"<input abstract='The input point, line, or polygon features to be buffered.' name='in_features' option='false' title='Input Features' type='String' variable=''/>" +
						"<input abstract='The feature class containing the output feature buffers.' name='out_feature_class' option='false' title='Output Feature Class' type='String' variable=''/>" +
						"<input abstract='The distance around the input features in which buffer zones are created. Distances can be provided as either a value representing a linear distance or as a numeric field from the input features that contains the linear distances to buffer each feature.If the Distance linear units are not specified or are entered as Unknown, the linear unit of the input features spatial reference is used.' name='buffer_distance_or_field' option='false' title='Distance [value or field]' type='String' variable=''/>" +
						"<input abstract='The side(s) of the input features that will be buffered.FULL—For line input features, buffers will be generated on both sides of the line. For polygon input features, buffers will be generated around the polygon and will contain and overlap the area of the input features. For point input features, buffers will be generated around the point. This is the default. LEFT—For line input features, buffers will be generated on the topological left of the line. This option is not valid for polygon input features.RIGHT—For line input features, buffers will be generated on the topological right of the line. This option is not valid for polygon input features.OUTSIDE_ONLY—For polygon input features, buffers will be generated only outside the input polygon (the area inside the input polygon will be erased from the output buffer). This option is not valid for line input features.' name='ine_side' option='false' title='Side Type' type='String' variable='FULL'/>" +
						"<input abstract='The shape of the buffer at the end of line input features. This parameter is not valid for polygon input features.' name='line_end_type' option='false' title='End Type' type='String' variable='ROUND'/>" +
						"<input abstract='Specifies the dissolve to be performed to remove output buffer overlap.' name='dissolve_option' option='false' title='Dissolve Type' type='String' variable='LIST'/>" +
						"<input abstract='The list of field(s) from the input features on which to dissolve the output buffers. Any buffers sharing attribute values in the listed fields (carried over from the input features) are dissolved.' name='dissolve_field' option='false' title='Dissolve Field(s)' type='String' variable=''/>" +
					"</inputs>" +
					"<outputs>" +
						"<output abstract='The feature class containing the output feature buffers.' name='out_feature_class' title='Output Feature Class' type='String' variable=''/>" +
					"</outputs>" +
				"</operation>" +
				"<operation abstract='道路湖泊叠加 ' id='3' name='Clip_analysis' title='道路湖泊叠加'>" +
					"<inputs>" +
						"<input abstract='The features to be clipped.' name='in_features' option='false' title='Input Features' type='String' variable=''/>" +
						"<input abstract='The features used to clip the input features.' name='clip_features' option='false' title='Clip Features' type='String' variable=''/>" +
						"<input abstract='The feature class to be created.' name='out_feature_class' option='false' title='Output Featureclass' type='String' variable=''/>" +
						"<input abstract='The minimum distance separating all feature coordinates (nodes and vertices) as well as the distance a coordinate can move in X or Y (or both). Set the value to be higher for data with less coordinate accuracy and lower for data with extremely high accuracy.' name='cluster_tolerance' option='false' title='XY Tolerance' type='String' variable='1 Kilometers'/>" +
					"</inputs>" +
					"<outputs>" +
						"<output abstract='The feature class to be created.' name='out_feature_class' title='Output Feature Class' type='String' variable=''/>" +
					"</outputs>" +
				"</operation>" +    
				"<end id='4' name='end' title='结束'/>" +
				"<links>" +
					"<link from='1' to='2'/>" +      
					"<link from='2' to='3'>" +
						"<assign>" +
							"<from>out_feature_class</from>" +
							"<to>in_features</to>" +
						"</assign>" +
					"</link>" +
					"<link from='3' to='4'/>" +
				"</links>" +
			"</flow>" +
		"</process>";
				
		Runner runner = Runner.getInstance();
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));	    
	    String dataBase = baseDir.substring(0, baseDir.lastIndexOf("/")) + "/data";
		String[] args = new String[6];
		args[0] = dataBase + "\\shp\\Road_L.shp";
	    args[1] = dataBase + "\\Default.gdb\\RoadLBuffer";
	    args[2] = "5 Kilometers";
	    args[3] = "NAME";
	    args[4] = dataBase + "\\shp\\Lake_R.shp";
	    args[5] = dataBase + "\\Default.gdb\\RoadLakeClip";
	    runner.runModel(content, args);
	}
}
