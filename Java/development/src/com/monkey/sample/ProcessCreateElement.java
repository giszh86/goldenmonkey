package com.monkey.sample;

import java.util.ArrayList;
import java.util.EventListener;
import java.util.HashMap;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

import com.monkey.designpattern.IConnectableObject;
import com.monkey.processing.EventItem;
import com.monkey.processing.ExecutedListener;
import com.monkey.processing.ExecutingListener;
import com.monkey.processing.IConnector;
import com.monkey.processing.IProcess;
import com.monkey.processing.ParaItem;
import com.monkey.processing.PausingListener;
import com.monkey.processing.SteppedListener;

public class ProcessCreateElement implements IProcess {

	private int _id = 0;
	private ArrayList<ParaItem> _inputSet = null;
	private ArrayList<ParaItem> _outputSet = null;
	private HashMap<String, IConnector> _inputConnectors = new HashMap<String, IConnector>();
	private HashMap<String, Object> _inputObjs = new HashMap<String, Object>();
	private HashMap<String, IConnector> _outputConnectors = new HashMap<String, IConnector>();
	private HashMap<String, Object> _outputObjs = new HashMap<String, Object>();
	
	public void setGuid(String value){
		
	}
    public String getGuid(){
    	return "";
    }
    
	@Override
	public void setid(int value) {
		this._id = value;
	}

	@Override
	public int getid() {
		return this._id;
	}

	//为避免和其他人开发的功能名称重复，前面加上标识，以作区分
	@Override
	public String name() {
		// TODO Auto-generated method stub
		return "monkey.ProcessCreateElement";
	}

	@Override
	public String getTitle() {
		// TODO Auto-generated method stub
		return "monkey.ProcessCreateElement";
	}
	
	public void setTitle(String value) {		
	}

	@Override
	public String getAbstracts() {
		return "monkey.ProcessCreateElement";
	}
	
	public void setAbstracts(String value) {		
	}

	@Override
	public ParaItem[] inputSet() {
		try{
			if (null == _inputSet){
				_inputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("key");
				p1.setDataType("String");
				_inputSet.add(p1);
				
				ParaItem p2 = new ParaItem();
				p2.setName("value");
				p2.setDataType("number");
				_inputSet.add(p2);	
				
				ParaItem p3 = new ParaItem();
				p3.setName("file");
				p3.setDataType("Element");
				_inputSet.add(p3);
			}
	
			ParaItem[] ps = new ParaItem[3];
			this._inputSet.toArray(ps);
			return ps;
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public ParaItem[] outputSet() {
		try{
			if (null == _outputSet){
				_outputSet = new ArrayList<ParaItem>();
				ParaItem p1 = new ParaItem();
				p1.setName("file");
				p1.setDataType("Element");
				_outputSet.add(p1);							
			}
			
			ParaItem[] ps = new ParaItem[2];
			this._outputSet.toArray(ps);
			return ps;
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return null;
	}

	@Override
	public EventItem[] events() {
		return null;
	}

	@Override
	public boolean isReady() {
		try{
			IConnector c = _inputConnectors.get("key");
			Object o = null;
			if (null == c){
				o = _inputObjs.get("key");
				if (null == o){
					return false;
				}
			}
			c = _inputConnectors.get("value");
			if (null == c){
				o = _inputObjs.get("value");
				if (null == o){
					return false;
				}
			}
			c = _inputConnectors.get("file");
			if (null == c){
				o = _inputObjs.get("file");
				if (null == o){
					return false;
				}
			}
			
			return true;
		}
		catch(Exception e){
			e.printStackTrace();
		}
		
		return false;
	}

	@Override
	public boolean setInputConnector(String parameter, IConnector connector) {
		if (parameter.equalsIgnoreCase("key") || parameter.equalsIgnoreCase("value") || parameter.equalsIgnoreCase("file")){
			_inputConnectors.put(parameter,connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setOutputConnector(String parameter, IConnector connector) {
		if (parameter.equalsIgnoreCase("file")){
			_outputConnectors.put(parameter,connector);
			return true;
		}
		return false;
	}

	@Override
	public boolean setInputValue(String parameter, Object value) {
		if (parameter.equalsIgnoreCase("key") || parameter.equalsIgnoreCase("value") || parameter.equalsIgnoreCase("file")){
			_inputObjs.put(parameter,value);
			return true;
		}
		return false;
	}

	@Override
	public Object getOutputValue(String parameter) {
		if (parameter.equalsIgnoreCase("file")){
			return _outputObjs.get(parameter);				
		}
		return null;
	}

	@Override
	public boolean bindingListener(String eventKey, EventListener l) {
		return false;
	}

	@Override
	public boolean execute() {
		try{
			String key = "";
			Number value = 0;
			Element file = null;
			
			IConnector c = _inputConnectors.get("key");
			Object o = null;
			if (null != c){
				key = (String)c.pop();
			}
			else{
				o = _inputObjs.get("key");
				if (null == o){
					return false;
				}			
				key = (String)o;
			}
			
			c = _inputConnectors.get("value");
			if (null != c){
				value = (Number)c.pop();
			}
			else{
				o = _inputObjs.get("value");
				if (null == o){
					return false;
				}			
				value = (Number)o;
			}
			
			c = _inputConnectors.get("file");
			if (null != c){
				file = (Element)c.pop();
			}
			else{
				o = _inputObjs.get("file");
				if (null == o){
					return false;
				}			
				file = (Element)o;
			}			
			
			Document doc = file.getOwnerDocument();			
			Element node = doc.createElement("item");// <item key="" value="" ></item>
			node.setAttribute("key", key);
			node.setAttribute("value",value.toString());				
			file.appendChild(node);
			
			c = _outputConnectors.get("file");
			if (null != c){
				c.push(file);
			}
			_outputObjs.put("file",file);
			
			return true;
		}
		catch(Exception ex){
			ex.printStackTrace();
		}
		catch(Error e){
			
		}
		
		return false;
	}

	@Override
	public boolean cancel() {
		return false;
	}

	@Override
	public boolean pause() {
		return false;
	}

	@Override
	public boolean resume(Element state) {
		return false;
	}

	@Override
	public void addSteppedListener(SteppedListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removeSteppedListener(SteppedListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addPausingListener(PausingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removePausingListener(PausingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addExecutingListener(ExecutingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void removeExecutingListener(ExecutingListener l) {
		// TODO Auto-generated method stub

	}

	@Override
	public void addExecutedListener(ExecutedListener l) {
	}

	@Override
	public void removeExecutedListener(ExecutedListener l) {
	}
	public IProcess clone(){
		return null;
	}
	
	/**
     * 关联的输入连接对象
     */
	public IConnectableObject getInputConnectableObject(){
		return null;
	}
	public void setInputConnectableObject(IConnectableObject value){
		
	}

    /**
     * 关联的输出连接对象
     */
    public IConnectableObject getOutputConnectableObject(){
        return null;
    }
    public void setOutputConnectableObject(IConnectableObject value){
    }
}
