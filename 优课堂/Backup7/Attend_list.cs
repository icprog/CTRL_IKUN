using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Attend_list:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Attend_list
	{
		public Attend_list()
		{}
		#region Model
		private string _stuno;
		private string _stuname;
		private string _teacher_name;
		private string _cousename;
		private string _attend;
		/// <summary>
		/// 
		/// </summary>
		public string StuNo
		{
			set{ _stuno=value;}
			get{return _stuno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StuName
		{
			set{ _stuname=value;}
			get{return _stuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Teacher_name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CouseName
		{
			set{ _cousename=value;}
			get{return _cousename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Attend
		{
			set{ _attend=value;}
			get{return _attend;}
		}
		#endregion Model

	}
}

