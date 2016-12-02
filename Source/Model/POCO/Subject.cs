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
    public partial class Subject : BaseEntity
    {
        public Subject()
        {
            this.Questions = new HashSet<Question>();
            this.SubjectsClasses = new HashSet<SubjectsClass>();
            this.SubjectsMultiTests = new HashSet<SubjectsMultiTest>();
            this.UserSubjectRights = new HashSet<UserSubjectRight>();
        }
    
    	private int m_SubjectId;
    	private string m_SubjectNo;
    	private string m_Name;
    	private Nullable<bool> m_IsDel;
    	private System.Guid m_SubjectGuid;
        public int SubjectId {
    		get{ 
    			return m_SubjectId;
    		} 
    		set{ 
    			if(m_SubjectId != value){
    				m_SubjectId = value; 
    				NotifyPropertyChanged("SubjectId"); 
                }
    		} 
    	}
    	[DataMember]
        public string SubjectNo {
    		get{ 
    			return m_SubjectNo;
    		} 
    		set{ 
    			if(m_SubjectNo != value){
    				m_SubjectNo = value; 
    				NotifyPropertyChanged("SubjectNo"); 
                }
    		} 
    	}
    	[DataMember]
        public string Name {
    		get{ 
    			return m_Name;
    		} 
    		set{ 
    			if(m_Name != value){
    				m_Name = value; 
    				NotifyPropertyChanged("Name"); 
                }
    		} 
    	}
    	[DataMember]
        public Nullable<bool> IsDel {
    		get{ 
    			return m_IsDel;
    		} 
    		set{ 
    			if(m_IsDel != value){
    				m_IsDel = value; 
    				NotifyPropertyChanged("IsDel"); 
                }
    		} 
    	}
    	[DataMember]
        public System.Guid SubjectGuid {
    		get{ 
    			return m_SubjectGuid;
    		} 
    		set{ 
    			if(m_SubjectGuid != value){
    				m_SubjectGuid = value; 
    				NotifyPropertyChanged("SubjectGuid"); 
                }
    		} 
    	}
    
    	protected override void CopyFromEntity(BaseEntity source, BaseEntity dest){
    		((Subject)dest).SubjectId = ((Subject)source).SubjectId;
    		((Subject)dest).SubjectNo = ((Subject)source).SubjectNo;
    		((Subject)dest).Name = ((Subject)source).Name;
    		((Subject)dest).IsDel = ((Subject)source).IsDel;
    		((Subject)dest).SubjectGuid = ((Subject)source).SubjectGuid;
    	}
    
    
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<SubjectsClass> SubjectsClasses { get; set; }
        public virtual ICollection<SubjectsMultiTest> SubjectsMultiTests { get; set; }
        public virtual ICollection<UserSubjectRight> UserSubjectRights { get; set; }
    }
}
