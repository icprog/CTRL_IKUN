using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// Teacher_Flist:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Teacher_Flist
	{
		public Teacher_Flist()
		{}
		#region Model
		private string _stuno;
		private string _stuname;
		private string _teacher_f;
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
		public string Teacher_F
		{
			set{ _teacher_f=value;}
			get{return _teacher_f;}
		}
		#endregion Model

	}
}

