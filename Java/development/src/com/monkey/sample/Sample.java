package com.monkey.sample;

import com.monkey.core.IApplication;
import com.monkey.processing.IPMDispatcher;
import com.monkey.processing.IPMParser;
import com.monkey.processing.IProcessingManager;
import com.monkey.processing.IProcess;
import com.monkey.processing.ProcessChainImpl;
import com.monkey.processing.IContext;
import com.monkey.runner.Runner;
import com.monkey.core.InstanceManager;

import org.w3c.dom.Element;


public class Sample {

	public static void main(String[] args) {
		Runner runner = Runner.getInstance();
		if (null == runner){
			System.out.println("Runner is null");
		}
		
		//如果未在配置文件中配置FactorySample，则通过下面方法注册，否则略去此段代码
		IApplication app = InstanceManager.getInstance().getApplication();
		if (null == app){
			return;
		}
		IProcessingManager manager = app.processingManager();
		if (null == manager){
			return;
		}
		manager.register("com.monkey.sample.FactorySample");
		
		int i = 3;
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

	public static void sample1() {
		ProcessChainImpl chain = new ProcessChainImpl();
		IProcess algebraic = chain.addProcess("monkey.ProcessAlgebraic");				
		algebraic.setInputValue("first", 6);
		algebraic.setInputValue("second", 2);
	
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));
		
		IProcess combineString = chain.addProcess("monkey.ProcessCombineString");
		combineString.setInputValue("s1", baseDir + "/development/");
		combineString.setInputValue("s2", "cmeu");
		combineString.setInputValue("s3", "test.xml");

		IProcess createElement = chain.addProcess("monkey.ProcessCreateElement");
	
		chain.connectProcesses(algebraic,createElement,"plus","value");
		chain.connectProcesses(combineString,createElement,"s12","key");
		chain.connectProcesses(combineString,createElement,"s13", "file");
		if (!chain.execute()){
			System.out.println("fail!");
		}
	
		Element e = (Element)createElement.getOutputValue("file");
		if (null == e){
			System.out.println("result is null");
		}
	}
	
	public static void sample2() {
		IProcessingManager manager = InstanceManager.getInstance().processingManager();		
		IPMParser parser = manager.newParser();
		if (null == parser){
			return;
		}
		
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));		
		parser.setFile(baseDir + "/development/devsample.xml");
		IPMDispatcher dispatcher = manager.newDispatcher();
		dispatcher.setModelParser(parser);
		
		String[] args = new String[5];
		args[0] = "6";
		args[1] = "2";		
		args[2] = baseDir + "/development/";
		args[3] = "cmeu";
		args[4] = "test.xml";		     
		Element e = (Element)dispatcher.dispatch(context,args);
		if (null == e){
			System.out.println("result is null");
		}
	}
	
	public static void sample3() {
		IContext context = InstanceManager.getInstance().getContext();
		String baseDir = (String)(context.getVariable("BaseDirectory"));
		String path = baseDir + "/development/devsample.xml";
		
		String[] args = new String[5];
		args[0] = "6";
		args[1] = "2";		
		args[2] = baseDir + "/development/";
		args[3] = "cmeu";
		args[4] = "test.xml";
		Runner.getInstance().runModelFile(path, args);
	}
}
