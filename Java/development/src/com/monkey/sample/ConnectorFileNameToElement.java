package com.monkey.sample;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import java.io.File;
import javax.xml.parsers.DocumentBuilder;    
import javax.xml.parsers.DocumentBuilderFactory;  
import org.w3c.dom.NodeList; 

import com.monkey.designpattern.IConnectableObject;
import com.monkey.processing.IConnector;

public class ConnectorFileNameToElement implements IConnector {

	private int _id = 0;
	private String _file = null;
	private Element _xml = null;

	@Override
	public Object pop() {
		// TODO Auto-generated method stub
		return _xml;
	}

	@Override
	public void push(Object value) {
		// TODO Auto-generated method stub
		try {
			_file = (String)value;
			
			File f = new File(_file);    
			DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();    
			DocumentBuilder builder = factory.newDocumentBuilder();    
			Document doc = builder.parse(f);
			_xml = (Element)(doc.getElementsByTagName("contents").item(0));  			
			
		} catch (Exception e) {    
			e.printStackTrace();    
		}    
	}

	public void setGuid(String value){
		
	}
    public String getGuid(){
    	return "";
    }

	@Override
	public void setid(int value) {
		// TODO Auto-generated method stub
		_id = value;
	}

	@Override
	public int getid() {
		// TODO Auto-generated method stub
		return _id;
	}

	@Override
	public String inputParaType() {
		// TODO Auto-generated method stub
		return "String";
	}

	@Override
	public String outputParaType() {
		// TODO Auto-generated method stub
		return "Element";
	}

	public IConnector clone(){
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
