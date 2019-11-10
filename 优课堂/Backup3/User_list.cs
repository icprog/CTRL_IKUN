using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// User_list:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class User_list
	{
		public User_list()
		{}
		#region Model
		private string _username;
		private string _userpassword;
		/// <summary>
		/// 
		/// </summary>
		public string userName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		#endregion Model

	}
}

