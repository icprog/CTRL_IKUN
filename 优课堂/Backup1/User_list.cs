using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:User_list
	/// </summary>
	public partial class User_list
	{
		public User_list()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userName)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from User_list");
			strSql.Append(" where userName=@userName ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,20)			};
			parameters[0].Value = userName;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.User_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into User_list(");
			strSql.Append("userName,userPassword)");
			strSql.Append(" values (");
			strSql.Append("@userName,@userPassword)");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,20),
					new SqlParameter("@userPassword", SqlDbType.VarChar,20)};
			parameters[0].Value = model.userName;
			parameters[1].Value = model.userPassword;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.User_list model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update User_list set ");
			strSql.Append("userPassword=@userPassword");
			strSql.Append(" where userName=@userName ");
			SqlParameter[] parameters = {
					new SqlParameter("@userPassword", SqlDbType.VarChar,20),
					new SqlParameter("@userName", SqlDbType.VarChar,20)};
			parameters[0].Value = model.userPassword;
			parameters[1].Value = model.userName;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string userName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_list ");
			strSql.Append(" where userName=@userName ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,20)			};
			parameters[0].Value = userName;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string userNamelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from User_list ");
			strSql.Append(" where userName in ("+userNamelist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.User_list GetModel(string userName)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 userName,userPassword from User_list ");
			strSql.Append(" where userName=@userName ");
			SqlParameter[] parameters = {
					new SqlParameter("@userName", SqlDbType.VarChar,20)			};
			parameters[0].Value = userName;

			Maticsoft.Model.User_list model=new Maticsoft.Model.User_list();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.User_list DataRowToModel(DataRow row)
		{
			Maticsoft.Model.User_list model=new Maticsoft.Model.User_list();
			if (row != null)
			{
				if(row["userName"]!=null)
				{
					model.userName=row["userName"].ToString();
				}
				if(row["userPassword"]!=null)
				{
					model.userPassword=row["userPassword"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userName,userPassword ");
			strSql.Append(" FROM User_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" userName,userPassword ");
			strSql.Append(" FROM User_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM User_list ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.userName desc");
			}
			strSql.Append(")AS Row, T.*  from User_list T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "User_list";
			parameters[1].Value = "userName";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

