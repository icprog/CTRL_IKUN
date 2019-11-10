using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:Teacher_Flist
	/// </summary>
	public partial class Teacher_Flist
	{
		public Teacher_Flist()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string StuNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Teacher_Flist");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.Teacher_Flist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Teacher_Flist(");
			strSql.Append("StuNo,StuName,Teacher_F)");
			strSql.Append(" values (");
			strSql.Append("@StuNo,@StuName,@Teacher_F)");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20),
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@Teacher_F", SqlDbType.VarChar,20)};
			parameters[0].Value = model.StuNo;
			parameters[1].Value = model.StuName;
			parameters[2].Value = model.Teacher_F;

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
		public bool Update(Maticsoft.Model.Teacher_Flist model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Teacher_Flist set ");
			strSql.Append("StuName=@StuName,");
			strSql.Append("Teacher_F=@Teacher_F");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuName", SqlDbType.VarChar,20),
					new SqlParameter("@Teacher_F", SqlDbType.VarChar,20),
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)};
			parameters[0].Value = model.StuName;
			parameters[1].Value = model.Teacher_F;
			parameters[2].Value = model.StuNo;

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
		public bool Delete(string StuNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teacher_Flist ");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

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
		public bool DeleteList(string StuNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Teacher_Flist ");
			strSql.Append(" where StuNo in ("+StuNolist + ")  ");
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
		public Maticsoft.Model.Teacher_Flist GetModel(string StuNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StuNo,StuName,Teacher_F from Teacher_Flist ");
			strSql.Append(" where StuNo=@StuNo ");
			SqlParameter[] parameters = {
					new SqlParameter("@StuNo", SqlDbType.VarChar,20)			};
			parameters[0].Value = StuNo;

			Maticsoft.Model.Teacher_Flist model=new Maticsoft.Model.Teacher_Flist();
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
		public Maticsoft.Model.Teacher_Flist DataRowToModel(DataRow row)
		{
			Maticsoft.Model.Teacher_Flist model=new Maticsoft.Model.Teacher_Flist();
			if (row != null)
			{
				if(row["StuNo"]!=null)
				{
					model.StuNo=row["StuNo"].ToString();
				}
				if(row["StuName"]!=null)
				{
					model.StuName=row["StuName"].ToString();
				}
				if(row["Teacher_F"]!=null)
				{
					model.Teacher_F=row["Teacher_F"].ToString();
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
			strSql.Append("select StuNo,StuName,Teacher_F ");
			strSql.Append(" FROM Teacher_Flist ");
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
			strSql.Append(" StuNo,StuName,Teacher_F ");
			strSql.Append(" FROM Teacher_Flist ");
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
			strSql.Append("select count(1) FROM Teacher_Flist ");
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
				strSql.Append("order by T.StuNo desc");
			}
			strSql.Append(")AS Row, T.*  from Teacher_Flist T ");
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
			parameters[0].Value = "Teacher_Flist";
			parameters[1].Value = "StuNo";
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

