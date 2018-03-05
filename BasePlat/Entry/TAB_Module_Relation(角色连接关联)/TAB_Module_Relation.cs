using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace TF.WebPlatForm.Entry
{
	 	//类名:WebPlatForm_Module_Relation
	//说明:WebPlatForm_Module_Relation
		public class WebPlatForm_Module_Relation
	{
   		     
      	/// <summary>
		/// nID
        /// </summary>
                
        
		private int _nid;
        public int nID
        {
            get{ return _nid; }
            set{ _nid = value; }
        }   
        		/// <summary>
		/// nModuleID
        /// </summary>
                
        
		private int _nmoduleid;
        public int nModuleID
        {
            get{ return _nmoduleid; }
            set{ _nmoduleid = value; }
        }   
        		/// <summary>
		/// nRoleID
        /// </summary>
                
        
		private int _nroleid;
        public int nRoleID
        {
            get{ return _nroleid; }
            set{ _nroleid = value; }
        }   
        		/// <summary>
		/// charRoleMark
        /// </summary>
                
        
		private string _charrolemark;
        public string charRoleMark
        {
            get{ return _charrolemark; }
            set{ _charrolemark = value; }
        }   
        		/// <summary>
		/// nTabIndex
        /// </summary>
                
        
		private int _ntabindex;
        public int nTabIndex
        {
            get{ return _ntabindex; }
            set{ _ntabindex = value; }
        }   
        		   
	}
}