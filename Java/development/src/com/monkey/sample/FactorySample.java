package com.monkey.sample;

import java.util.Date;
import java.util.EventListener;
import java.util.ArrayList;

import com.monkey.job.IJob;
import com.monkey.processing.EventItem;
import com.monkey.processing.IConnector;
import com.monkey.processing.IPMFactory;
import com.monkey.processing.IProcess;

public class FactorySample implements IPMFactory {

	private ArrayList<String> _proceses = null;
	private ArrayList<String> _objes = null;
	
	@Override
	public String guid() {
		// TODO Auto-generated method stub
		return "1666EFD1-820C-B686-CD95-F6BFD776B045";
	}

	@Override
	public String author() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String abstracts() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String version() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Date date() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String[] processes() {
		if (null == _proceses){
			_proceses = new ArrayList<String>();
			_proceses.add("monkey.ProcessAlgebraic");
			_proceses.add("monkey.ProcessCombineString");
			_proceses.add("monkey.ProcessCreateElement");
		}
		
		if (null != _proceses){
			String[] arrString = new String[_proceses.size()];   
			for( int i = 0 ; i < _proceses.size() ; i ++ ){   
				arrString[i] = (String)(_proceses.get(i));   
			}
			return arrString;
		}  

		return null;
	}

	@Override
	public String[] objectTypes() {
		if (null == _objes){
			_objes = new ArrayList<String>();
			_objes.add("number");
			_objes.add("String");
		}
		
		if (null != _objes){  
			String[] arrString = new String[_objes.size()];   
			for( int i = 0 ; i < _objes.size() ; i ++ ){   
				arrString[i] = (String)(_objes.get(i));   
			}
			return arrString;
		}  
				
		return null;
	}

	@Override
	public EventItem[] events() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public String[] jobTypes() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public IProcess createProcess(String name) {
		if (name.equalsIgnoreCase("monkey.ProcessAlgebraic")){		
			return new ProcessAlgebraic();
		}
		if (name.equalsIgnoreCase("monkey.ProcessCombineString")){
				return new ProcessCombineString();
		}
		if (name.equalsIgnoreCase("monkey.ProcessCreateElement")){
				return new ProcessCreateElement();			
		}
		return null;
	}

	@Override
	public IConnector createConnector(String inParaType, String outParaType) {
		// TODO Auto-generated method stub
		if (inParaType.equalsIgnoreCase("String") && outParaType.equalsIgnoreCase("Element")){
			return new ConnectorFileNameToElement();
		}
		return null;
	}

	@Override
	public Object createObject(String type, String value) {
		// TODO Auto-generated method stub
		if (type.equalsIgnoreCase("String")){		
			return value;
		}
		if (type.equalsIgnoreCase("number")){
			return (Number)(Integer.parseInt(value));			
		}		
		
		return null;
	}
	
	public String objectToString(Object obj){
		try{
		}
		catch (Exception e) {
			e.printStackTrace();
		}
		return "";
	}

	@Override
	public EventListener createEvent(String key) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public IJob createJob(String type) {
		// TODO Auto-generated method stub
		return null;
	}

	public void release(){
	}
}
