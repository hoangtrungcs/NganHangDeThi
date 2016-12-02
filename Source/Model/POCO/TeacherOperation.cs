//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.POCO
{
    using System.Runtime.Serialization;
    using System;
    using System.Collections.Generic;
    
    [DataContract]
    public partial class TeacherOperation : BaseEntity
    {
    	private int m_Id;
    	private int m_TeacherId;
    	private string m_OperationName;
    	private bool m_Enable;
        public int Id {
    		get{ 
    			return m_Id;
    		} 
    		set{ 
    			if(m_Id != value){
    				m_Id = value; 
    				NotifyPropertyChanged("Id"); 
                }
    		} 
    	}
    	[DataMember]
        public int TeacherId {
    		get{ 
    			return m_TeacherId;
    		} 
    		set{ 
    			if(m_TeacherId != value){
    				m_TeacherId = value; 
    				NotifyPropertyChanged("TeacherId"); 
                }
    		} 
    	}
    	[DataMember]
        public string OperationName {
    		get{ 
    			return m_OperationName;
    		} 
    		set{ 
    			if(m_OperationName != value){
    				m_OperationName = value; 
    				NotifyPropertyChanged("OperationName"); 
                }
    		} 
    	}
    	[DataMember]
        public bool Enable {
    		get{ 
    			return m_Enable;
    		} 
    		set{ 
    			if(m_Enable != value){
    				m_Enable = value; 
    				NotifyPropertyChanged("Enable"); 
                }
    		} 
    	}
    
    	protected override void CopyFromEntity(BaseEntity source, BaseEntity dest){
    		((TeacherOperation)dest).Id = ((TeacherOperation)source).Id;
    		((TeacherOperation)dest).TeacherId = ((TeacherOperation)source).TeacherId;
    		((TeacherOperation)dest).OperationName = ((TeacherOperation)source).OperationName;
    		((TeacherOperation)dest).Enable = ((TeacherOperation)source).Enable;
    	}
    
    }
}
