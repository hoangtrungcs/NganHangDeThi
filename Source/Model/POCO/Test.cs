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
    public partial class Test : BaseEntity
    {
        public Test()
        {
            this.StudentTestDetails = new HashSet<StudentTestDetail>();
            this.StudentTests = new HashSet<StudentTest>();
            this.TestCopies = new HashSet<TestCopy>();
            this.TestQuestions = new HashSet<TestQuestion>();
        }
    
    	private long m_TestId;
    	private string m_TestNo;
    	private string m_Name;
    	private int m_FK_SubjectId;
    	private System.DateTime m_TestDate;
    	private int m_Time;
    	private string m_CreatedBy;
    	private string m_UpdatedBy;
    	private System.DateTime m_CreatedDate;
    	private System.DateTime m_UpdatedDate;
    	private int m_Purpose;
    	private int m_CopyNo;
    	private int m_EasyNo;
    	private int m_NormalNo;
    	private int m_HardNo;
    	private Nullable<bool> m_IsLimited;
    	private bool m_IsDeleted;
    	private Nullable<int> m_FK_ClassId;
        public long TestId {
    		get{ 
    			return m_TestId;
    		} 
    		set{ 
    			if(m_TestId != value){
    				m_TestId = value; 
    				NotifyPropertyChanged("TestId"); 
                }
    		} 
    	}
    	[DataMember]
        public string TestNo {
    		get{ 
    			return m_TestNo;
    		} 
    		set{ 
    			if(m_TestNo != value){
    				m_TestNo = value; 
    				NotifyPropertyChanged("TestNo"); 
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
        public int FK_SubjectId {
    		get{ 
    			return m_FK_SubjectId;
    		} 
    		set{ 
    			if(m_FK_SubjectId != value){
    				m_FK_SubjectId = value; 
    				NotifyPropertyChanged("FK_SubjectId"); 
                }
    		} 
    	}
    	[DataMember]
        public System.DateTime TestDate {
    		get{ 
    			return m_TestDate;
    		} 
    		set{ 
    			if(m_TestDate != value){
    				m_TestDate = value; 
    				NotifyPropertyChanged("TestDate"); 
                }
    		} 
    	}
    	[DataMember]
        public int Time {
    		get{ 
    			return m_Time;
    		} 
    		set{ 
    			if(m_Time != value){
    				m_Time = value; 
    				NotifyPropertyChanged("Time"); 
                }
    		} 
    	}
    	[DataMember]
        public string CreatedBy {
    		get{ 
    			return m_CreatedBy;
    		} 
    		set{ 
    			if(m_CreatedBy != value){
    				m_CreatedBy = value; 
    				NotifyPropertyChanged("CreatedBy"); 
                }
    		} 
    	}
    	[DataMember]
        public string UpdatedBy {
    		get{ 
    			return m_UpdatedBy;
    		} 
    		set{ 
    			if(m_UpdatedBy != value){
    				m_UpdatedBy = value; 
    				NotifyPropertyChanged("UpdatedBy"); 
                }
    		} 
    	}
    	[DataMember]
        public System.DateTime CreatedDate {
    		get{ 
    			return m_CreatedDate;
    		} 
    		set{ 
    			if(m_CreatedDate != value){
    				m_CreatedDate = value; 
    				NotifyPropertyChanged("CreatedDate"); 
                }
    		} 
    	}
    	[DataMember]
        public System.DateTime UpdatedDate {
    		get{ 
    			return m_UpdatedDate;
    		} 
    		set{ 
    			if(m_UpdatedDate != value){
    				m_UpdatedDate = value; 
    				NotifyPropertyChanged("UpdatedDate"); 
                }
    		} 
    	}
    	[DataMember]
        public int Purpose {
    		get{ 
    			return m_Purpose;
    		} 
    		set{ 
    			if(m_Purpose != value){
    				m_Purpose = value; 
    				NotifyPropertyChanged("Purpose"); 
                }
    		} 
    	}
    	[DataMember]
        public int CopyNo {
    		get{ 
    			return m_CopyNo;
    		} 
    		set{ 
    			if(m_CopyNo != value){
    				m_CopyNo = value; 
    				NotifyPropertyChanged("CopyNo"); 
                }
    		} 
    	}
    	[DataMember]
        public int EasyNo {
    		get{ 
    			return m_EasyNo;
    		} 
    		set{ 
    			if(m_EasyNo != value){
    				m_EasyNo = value; 
    				NotifyPropertyChanged("EasyNo"); 
                }
    		} 
    	}
    	[DataMember]
        public int NormalNo {
    		get{ 
    			return m_NormalNo;
    		} 
    		set{ 
    			if(m_NormalNo != value){
    				m_NormalNo = value; 
    				NotifyPropertyChanged("NormalNo"); 
                }
    		} 
    	}
    	[DataMember]
        public int HardNo {
    		get{ 
    			return m_HardNo;
    		} 
    		set{ 
    			if(m_HardNo != value){
    				m_HardNo = value; 
    				NotifyPropertyChanged("HardNo"); 
                }
    		} 
    	}
    	[DataMember]
        public Nullable<bool> IsLimited {
    		get{ 
    			return m_IsLimited;
    		} 
    		set{ 
    			if(m_IsLimited != value){
    				m_IsLimited = value; 
    				NotifyPropertyChanged("IsLimited"); 
                }
    		} 
    	}
    	[DataMember]
        public bool IsDeleted {
    		get{ 
    			return m_IsDeleted;
    		} 
    		set{ 
    			if(m_IsDeleted != value){
    				m_IsDeleted = value; 
    				NotifyPropertyChanged("IsDeleted"); 
                }
    		} 
    	}
    	[DataMember]
        public Nullable<int> FK_ClassId {
    		get{ 
    			return m_FK_ClassId;
    		} 
    		set{ 
    			if(m_FK_ClassId != value){
    				m_FK_ClassId = value; 
    				NotifyPropertyChanged("FK_ClassId"); 
                }
    		} 
    	}
    
    	protected override void CopyFromEntity(BaseEntity source, BaseEntity dest){
    		((Test)dest).TestId = ((Test)source).TestId;
    		((Test)dest).TestNo = ((Test)source).TestNo;
    		((Test)dest).Name = ((Test)source).Name;
    		((Test)dest).FK_SubjectId = ((Test)source).FK_SubjectId;
    		((Test)dest).TestDate = ((Test)source).TestDate;
    		((Test)dest).Time = ((Test)source).Time;
    		((Test)dest).CreatedBy = ((Test)source).CreatedBy;
    		((Test)dest).UpdatedBy = ((Test)source).UpdatedBy;
    		((Test)dest).CreatedDate = ((Test)source).CreatedDate;
    		((Test)dest).UpdatedDate = ((Test)source).UpdatedDate;
    		((Test)dest).Purpose = ((Test)source).Purpose;
    		((Test)dest).CopyNo = ((Test)source).CopyNo;
    		((Test)dest).EasyNo = ((Test)source).EasyNo;
    		((Test)dest).NormalNo = ((Test)source).NormalNo;
    		((Test)dest).HardNo = ((Test)source).HardNo;
    		((Test)dest).IsLimited = ((Test)source).IsLimited;
    		((Test)dest).IsDeleted = ((Test)source).IsDeleted;
    		((Test)dest).FK_ClassId = ((Test)source).FK_ClassId;
    	}
    
    
        public virtual LopHoc LopHoc { get; set; }
        public virtual ICollection<StudentTestDetail> StudentTestDetails { get; set; }
        public virtual ICollection<StudentTest> StudentTests { get; set; }
        public virtual ICollection<TestCopy> TestCopies { get; set; }
        public virtual ICollection<TestQuestion> TestQuestions { get; set; }
    }
}
